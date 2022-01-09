using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Model;
using Data;

namespace Servicios.Utilidades
{
    public class TrasladarDocumentos
    {
        public void deOfertaAVentas(Oferta Oferta)
        {
            if (Oferta == null) {
                MessageBox.Show("Se debe seleccionar un ítem para continuar con esta acción. Si continúa con problemas, " +
                    "por favor dirigase al administrador");
                return;
            }

            List<(int, string)> aObtener = new List<(int, string)>()
            {
                (Oferta.IdBU, "comercialOferta"),
                (Oferta.IdBU, "ventasOferta"),
                (Oferta.IdBU, "comercialPricing"),
                (Oferta.IdBU, "ventasPricing"),
                (Oferta.IdBU, "comercial"),
                (Oferta.IdBU, "ventas")
            };

            RepositorioCarpetas _repPasta = new RepositorioCarpetas();
            List<string> rutas = _repPasta.GetPathsAsync(aObtener).Result;

            string rtoafm = rutas[0];
            string rtopv = rutas[1];
            string rtpafm = rutas[2];
            string rtppv = rutas[3];

            rtoafm += $@"P_{Oferta.NCRM}-R{Oferta.Rev}_Consolidada";
            rtopv += $@"P_{Oferta.NCRM}-R{Oferta.Rev}_Consolidada";
            rtpafm += $@"R_{Oferta.NCRM}-R{Oferta.Rev}_Consolidado";
            rtppv += $@"R_{Oferta.NCRM}-R{Oferta.Rev}_Consolidado";

            int opdf = 0; int ppdf = 0; int pexl = 0;
            //if (File.Exists(rtoafm + ".docx") == true) { File.Copy(rtoafm + ".docx", rtopv + ".docx", true); odoc = 1; }
            if (File.Exists(rtoafm + ".pdf") == true) { File.Copy(rtoafm + ".pdf", rtopv + ".pdf", true); opdf = 1; }
            if (File.Exists(rtpafm + ".xlsm") == true) { File.Copy(rtpafm + ".xlsm", rtppv + ".xlsm", true); pexl = 1; }
            if (File.Exists(rtpafm + ".pdf") == true) { File.Copy(rtpafm + ".pdf", rtppv + ".pdf", true); ppdf = 1; }

            string Docs = $"Los siguientes documentos fueron trasladados desde {rutas[4]} hacia {rutas[5]}: \n";
            //Docs += (odoc == 1) ? "\n\t\u2023 Oferta en Word" : ""; 
            Docs += (opdf == 1) ? "\n\t\u2714 Oferta en PDF" : "\n\t\u2716 Oferta en PDF";
            Docs += (pexl == 1) ? "\n\t\u2714 Pricing en Excel" : "\n\t\u2716 Pricing en Excel";
            Docs += (ppdf == 1) ? "\n\t\u2714 Pricing en PDF" : "\n\t\u2716 Pricing en PDF";


            /// Mover otizacion proveedor, correos y otros archivos
            Docs += copiarArchivos(Oferta, Docs, "cotizaciones", rutas[4], rutas[5]);
            Docs += copiarArchivos(Oferta, Docs, "correos", rutas[4], rutas[5]);
            Docs += copiarArchivos(Oferta, Docs, "otros", rutas[4], rutas[5]);

            MessageBox.Show(Docs);
        }

        /// <summary>
        /// Copiar archivos de carpetas de Oferta en carpeta de PV
        /// </summary>
        /// <param name="Oferta"></param>
        /// <param name="Docs"></param>
        /// <param name="que"></param>
        /// <returns></returns>
        private string copiarArchivos(Oferta Oferta, string Docs, string que, string rutaComercial, string rutaVentas)
        {
            String directoryName = rutaVentas;
            String mensaje = "";
            String subPasta = "";

            if (Oferta.IdBU == (int)BUEnum.HCHL || Oferta.IdBU == (int)BUEnum.HPU)
            {
                switch (que)
                {
                    case "cotizaciones":
                        directoryName += @"\COMPRAS\Cotizaciones de la Fase de Propuesta\";
                        subPasta = @"\COTIZACIÓN\";
                        break;
                    case "correos":
                        directoryName += @"\COMERCIAL\Emails com Cliente\";
                        subPasta = @"\CLIENTE\Emails\";
                        break;
                    case "otros":
                        directoryName += @"\ING_APLICACION\Documentacion del Cliente\";
                        subPasta = @"\CLIENTE\Documentos\";
                        break;
                }

                DirectoryInfo dirInfo = new DirectoryInfo(directoryName);
                string comercial = rutaComercial;
                List<String> archivos = Directory.GetFiles(comercial + subPasta, "*.*", SearchOption.AllDirectories).ToList();

                if (que == "correos")
                {
                    archivos.AddRange(Directory.GetFiles(comercial + @"\CLIENTE\Solicitud de Cotización\", "*.*", SearchOption.AllDirectories).ToList());
                }
                else if (que == "otros")
                {
                    archivos.AddRange(Directory.GetFiles(comercial + @"\CLIENTE\Dibujos\", "*.*", SearchOption.AllDirectories).ToList());
                    archivos.AddRange(Directory.GetFiles(comercial + @"\CLIENTE\Fotos\", "*.*", SearchOption.AllDirectories).ToList());
                }


                if (archivos.Count > 0)
                {
                    foreach (string file in archivos)
                    {
                        FileInfo mFile = new FileInfo(file);
                        mFile.CopyTo(dirInfo + "\\" + mFile.Name, true);
                        if (que == "cotizaciones") { mensaje = "\n\t\u2714 Oferta Proveedor "; }
                        else if (que == "correos") { mensaje = "\n\t\u2714 Mail "; }
                        else if (que == "otros") { mensaje = "\n\t\u2714 Doc "; }

                        mensaje += mFile.Name;
                    }
                }
            }

            return mensaje;
        }
    }
}

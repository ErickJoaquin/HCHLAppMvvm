using System;
using System.Collections.Generic;
using Model;
using Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Servicios.Utilidades
{
    public class Directorio
    {
        private readonly RepositorioCarpetas _repPasta;
        public List<(int, string)> pastas;
        
        public Directorio(RepositorioCarpetas repPasta)
        {
            this._repPasta = repPasta;

            pastas = new List<(int, string)>();
        }

        public async void Abrir(int IdBU, string NCRM)
        {
            pastas.Add((IdBU, "comercial"));
            List<string> rutaPastas = await _repPasta.GetPathsAsync(pastas);
            string rutacarpeta = $@"{rutaPastas[0]}\{NCRM}";

            try
            {
                if (Directory.Exists(rutacarpeta)) { Process.Start(rutacarpeta); }
                else if (!Directory.Exists(rutacarpeta))
                {
                    if (IdBU == (int)BUEnum.HCHL || IdBU == (int)BUEnum.HPU)
                    {
                        Directory.CreateDirectory(rutacarpeta);
                        Directory.CreateDirectory(rutacarpeta + @"\ANÁLISIS_DE_CRÉDITO");
                        Directory.CreateDirectory(rutacarpeta + @"\ANÁLISIS_DE_CRÉDITO\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\COSTO_&_PRICING");
                        Directory.CreateDirectory(rutacarpeta + @"\COSTO_&_PRICING\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\COTIZACIÓN");
                        Directory.CreateDirectory(rutacarpeta + @"\COTIZACIÓN\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\EMAIL");
                        Directory.CreateDirectory(rutacarpeta + @"\EMAIL\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\ESTUDIOS");
                        Directory.CreateDirectory(rutacarpeta + @"\ESTUDIOS\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\PROPUESTA");
                        Directory.CreateDirectory(rutacarpeta + @"\PROPUESTA\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\REFERENCIAS_INTERNAS");
                        Directory.CreateDirectory(rutacarpeta + @"\REFERENCIAS_INTERNAS\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\SELECCIÓN");
                        Directory.CreateDirectory(rutacarpeta + @"\SELECCIÓN\00 Revisiones Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Dibujos");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Documentos");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Emails");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Fotos");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Solicitud de Cotización");
                    }
                    else if (IdBU == (int)BUEnum.HSA)
                    {
                        Directory.CreateDirectory(rutacarpeta);
                        Directory.CreateDirectory(rutacarpeta + @"\ANÁLISE_DE_CRÉDITO");
                        Directory.CreateDirectory(rutacarpeta + @"\ANÁLISE_DE_CRÉDITO\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\CUSTO_&_PRICING");
                        Directory.CreateDirectory(rutacarpeta + @"\CUSTO_&_PRICING\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\COTAÇÃO");
                        Directory.CreateDirectory(rutacarpeta + @"\COTAÇÃO\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\EMAIL");
                        Directory.CreateDirectory(rutacarpeta + @"\EMAIL\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\ESTUDOS");
                        Directory.CreateDirectory(rutacarpeta + @"\ESTUDOS\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\PROPOSTA");
                        Directory.CreateDirectory(rutacarpeta + @"\PROPOSTA\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\REFERÊNCIAS_INTERNAS");
                        Directory.CreateDirectory(rutacarpeta + @"\REFERÊNCIAS_INTERNAS\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\SELEÇÃO");
                        Directory.CreateDirectory(rutacarpeta + @"\SELEÇÃO\0_Revisões_Anteriores");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Desenhos");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Documentos");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Emails");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Fotos");
                        Directory.CreateDirectory(rutacarpeta + @"\CLIENTE\Solicitação_de_Cotação");
                    }

                    MessageBox.Show($"La carpeta {NCRM} ha sido creada en {rutacarpeta}");
                    Process.Start(rutacarpeta);
                }
            }
            catch (Exception ex) { MessageBox.Show("No se pudo crear ni encontrar la Carpeta de la oferta, comuniquese con el administrador. Error: " + ex); }
        }
    }
}

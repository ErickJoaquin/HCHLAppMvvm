using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Data;
using Model;

namespace Servicios.Correos.LiberacionAcepte
{
    public class DocumentosAComparar
    {
        private readonly RepositorioCarpetas _repPasta;

        public List<(int, string)> _pastasATraer;
        public DocumentosAComparar(RepositorioCarpetas repPasta)
        {
            this._repPasta = repPasta;

            _pastasATraer = new List<(int, string)>();
        }
        public void Abrir(Oferta Oferta, OC OC)
        {
            (int, string)[] aTraer = { (Oferta.IdBU, "comercialOferta"), (Oferta.IdBU, "ventas") };
            _pastasATraer.AddRange(aTraer);

            List<string> rutas = _repPasta.GetPathsAsync(_pastasATraer).Result;
            string rutaoferta = rutas[0];
            string rutaoc = rutas[1];

            rutaoferta += $"P_{Oferta.NCRM}-R{Oferta.Rev}_Consolidada.pdf";
            rutaoc += $@"\COMERCIAL\Contrato o Pedido de Compras del Cliente\{OC.Nombre}.pdf";

            try
            {
                Process.Start(rutaoferta);
            }
            catch (Exception g)
            {
                MessageBox.Show($"Al parecer, no se encontró ningún documento con el nombre: {Oferta.NCRM}-R en la siguiente ruta: {rutaoferta}. " +
                    $"Hablar con el administrador, error: " + g);
            }

            try
            {
                Process.Start(rutaoc);
            }
            catch (Exception f)
            {
                MessageBox.Show($"Al parecer, no se encontró ningún documento con el nombre: {OC.Nombre} en la siguiente ruta: {rutaoc}. " +
                    "Hablar con el administrador, error: " + f);
            }
        }

    }
}

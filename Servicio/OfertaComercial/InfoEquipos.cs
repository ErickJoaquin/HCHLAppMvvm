using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;

namespace Servicios.OfertaComercial
{
    public class InfoEquipos
    {
        public void Agregar(Oferta Oferta, Word.Document docof)
        {
            RepositorioEquiposLinkeados repEq = new RepositorioEquiposLinkeados();
            List<BaseInstalada> EquiposLinkeados = repEq.GetByOfferIdAsync(Oferta.Id).Result;

            Word.Bookmarks wBookmarks = docof.Bookmarks;
            Word.Bookmark wBookmark = wBookmarks["Equipos"];
            Word.Range wRange = wBookmark.Range;

            string cambio = crearString(EquiposLinkeados);

            wRange.Text = cambio;
        }

        public static string crearString(List<BaseInstalada> EquiposLinkeados)
        {
            string value = "";
            if (EquiposLinkeados.Count() <= 0)
            {
                value = "Esta oferta no está vinculada a ningún equipo.";
                return value;
            }

            for (int i = 0; i < EquiposLinkeados.Count(); i++)
            {
                if (EquiposLinkeados[i].seleccion == true)
                {
                    if (i == 0 || (i > 0 && EquiposLinkeados[i].Modelo != EquiposLinkeados[i - 1].Modelo))
                    {
                        value += $"{ EquiposLinkeados[i].Modelo} (N/S: { EquiposLinkeados[i].NSerie}";
                    }
                    else if (i > 0 && EquiposLinkeados[i].Modelo == EquiposLinkeados[i - 1].Modelo)
                    {
                        value += $"N/S: {EquiposLinkeados[i].NSerie}";
                    }

                    if (EquiposLinkeados[i].RefCliente != null && EquiposLinkeados[i].RefCliente != "") 
                    { value += $"/Tag cliente: {EquiposLinkeados[i].RefCliente}"; }
                    if (i < EquiposLinkeados.Count() - 1 && EquiposLinkeados[i].Modelo != EquiposLinkeados[i + 1].Modelo) 
                    { value += ")"; }
                }

                if (i == EquiposLinkeados.Count() - 1) { value += ")."; }
                else { value += "; "; }
            }

            return value;

        }
    }
}

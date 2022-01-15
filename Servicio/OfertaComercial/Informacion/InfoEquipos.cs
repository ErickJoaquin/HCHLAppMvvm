using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using Servicios.OfertaComercial.Utilidades;


namespace Servicios.OfertaComercial.Informacion
{
    public class InfoEquipos
    {
        private readonly ReemplazarEnWord _reemplazar;
        private readonly RepositorioEquiposLinkeados _repEq;
        public InfoEquipos(RepositorioEquiposLinkeados repEq, ReemplazarEnWord reemplazar)
        {
            this._repEq = repEq;
            this._reemplazar = reemplazar;
        }

        public void Agregar(Oferta Oferta, Word.Document docof)
        {
            List<BaseInstalada> EquiposLinkeados = _repEq.GetByOfferIdAsync(Oferta.Id).Result;

            string cambio = crearString(EquiposLinkeados);

            _reemplazar.TextoGeneral("Equipos", cambio, docof);
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

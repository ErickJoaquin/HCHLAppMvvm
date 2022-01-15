using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using Servicios.OfertaComercial.Utilidades;

namespace Servicios.OfertaComercial.Informacion
{
    public class InfoItems
    {
        private readonly ReemplazarEnWord _reemplazar;
        private readonly RepositorioItem _repItem;
        public InfoItems(RepositorioItem repItem, ReemplazarEnWord reemplazar)
        {
            this._repItem = repItem;
            this._reemplazar = reemplazar;
        }

        public void Agregar(Oferta Oferta, OfertaValores values, Word.Document docof, bool comoItem, bool prorratearDespacho, bool prorratearPackaging)
        {
            Word.Table tbl = docof.Tables[4];

            List<Item> itemsOrdenados = _repItem.GetByOffer(Oferta.Id).OrderBy(x => x.TipoItem).ThenBy(x => x.NSP).ToList();
            List<Item> ListaSP = itemsOrdenados.Where(x => x.TipoItem == TipoItemEnum.SP.ToString()).ToList();

            int ta = 0;
            double totalSP = 0;
            for (int i = 0; i < ListaSP.Count(); i++)
            {
                totalSP += ListaSP[i].VentaUnitaria * ListaSP[i].Qty;
            }


            int j = 0;
            foreach (Item item in itemsOrdenados)
            {
                docof.Tables[4].Rows.Add(docof.Tables[4].Rows[j + 4]);
                if (j % 2 != 0) { docof.Tables[4].Rows[j + 3].Shading.BackgroundPatternColor = Word.WdColor.wdColorGray10; }
                double ventaUnit = 0;

                if (item.TipoItem == TipoItemEnum.SV.ToString())
                {
                    Servicio SV = item as Servicio;
                    if (SV.TipoServicio == "TA" && SV.VentaUnitaria == 0) { ta++; continue; }
                    ventaUnit = SV.VentaUnitaria;
                }

                tbl.Cell(j + 3, 1).Range.Text = item.NSP.ToString("000");
                tbl.Cell(j + 3, 3).Range.Text = item.Descripcion;
                tbl.Cell(j + 3, 5).Range.Text = item.Qty.ToString();

                if (item.TipoItem == "SP")
                {
                    Repuesto SP = item as Repuesto;
                    tbl.Cell(j + 3, 2).Range.Text = SP.NParte;
                    if (!String.IsNullOrEmpty(SP.DrwItem) && !String.IsNullOrEmpty(SP.Drw)) { tbl.Cell(j + 3, 3).Range.Text += "Drawing " + SP.Drw + "  Drw.Item " + SP.DrwItem + " "; }
                    else if (!String.IsNullOrEmpty(SP.Drw)) { tbl.Cell(j + 3, 3).Range.Text += "Drawing " + SP.Drw; }
                    else if (!String.IsNullOrEmpty(SP.DrwItem)) { tbl.Cell(j + 3, 3).Range.Text += "Drw.Item " + SP.DrwItem; }                    
                    if (!String.IsNullOrEmpty(SP.HSCode)) { tbl.Cell(j + 3, 3).Range.Text += "HS-Code:             " + SP.HSCode + " "; }
                    if (!String.IsNullOrEmpty(SP.RefCliente)) { tbl.Cell(j + 3, 3).Range.Text += "Ref. Cliente: " + SP.RefCliente + " "; }
                    if (!String.IsNullOrEmpty(SP.Comentarios))  { tbl.Cell(j + 3, 3).Range.Text += "Comentarios: " + SP.Comentarios; }

                    tbl.Cell(j + 3, 4).Range.Text = SP.PlazoEntrega.ToString();

                    double partSP = (SP.VentaUnitaria * SP.Qty) / totalSP;
                    ventaUnit = SP.VentaUnitaria;
                    if (comoItem)
                    {
                        if (prorratearPackaging && prorratearDespacho) { ventaUnit += partSP * (values.PackagingV + values.AduanaV + values.TransporteV) / item.Qty; }
                        else if (!prorratearPackaging && !prorratearDespacho) { ventaUnit += partSP * values.PackagingV; }
                        else if (!prorratearPackaging && prorratearDespacho) { ventaUnit += partSP * (values.AduanaV + values.TransporteV); }
                    }
                }


                if (Oferta.IdBU == (int)BUEnum.HCHL && Oferta.Id == (int)MonedasEnum.CLP)
                {
                    tbl.Cell(j + 3, 6).Range.Text = ventaUnit.ToString("C");
                    tbl.Cell(j + 3, 7).Range.Text = (ventaUnit * item.Qty).ToString("C");
                }
                else
                {
                    tbl.Cell(j + 3, 6).Range.Text = ventaUnit.ToString("C2");
                    tbl.Cell(j + 3, 7).Range.Text = (ventaUnit * item.Qty).ToString("C2");
                }

                j++;
            }
            AgregarTotal(Oferta, docof);
            ReajustarTabla(itemsOrdenados, docof, ta);
        }

        private void AgregarTotal(Oferta Oferta, Word.Document docof)
        {
            if (Oferta.VLiquida == 0)
            {
                _reemplazar.TextoGeneral("Total", "", docof);
                return;
            }

            if (Oferta.IdBU == (int)BUEnum.HCHL && Oferta.Id == (int)MonedasEnum.CLP)
            {
                _reemplazar.TextoGeneral("Total", Oferta.VLiquida.ToString("C"), docof);
            }
            else
            {
                _reemplazar.TextoGeneral("Total", Oferta.VLiquida.ToString("C2"), docof);
            }
        }

        private void ReajustarTabla(List<Item> Lista, Word.Document docof, int ta)
        {
            // Eliminar primera y ultima fila de la tabla, despues de los repuestos
            docof.Tables[4].Rows[Lista.Count() + 3 - ta].Delete();
            docof.Tables[4].Rows[Lista.Count() + 3 - ta].Delete();
            docof.Tables[4].Rows[Lista.Count() + 3 - ta].Delete();
        }
    }
}

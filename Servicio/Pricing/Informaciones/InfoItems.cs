using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Model;

namespace Servicios.Pricing.Informaciones
{
    public class InfoItems
    {
        public void Agregar(Excel.Worksheet HojaCostos, Oferta Oferta, OfertaValores ofValores, List<Item> itemsOrdenados,
            bool comoItem, bool prorratearPackaging, bool prorratearDespacho)
        {            
            List<Item> ListaSP = itemsOrdenados.Where(x => x.TipoItem == TipoItemEnum.SP.ToString()).ToList();

            double ventaUnit = 0;

            int j = 0;
            foreach (Item item in itemsOrdenados)
            {
                HojaCostos.Cells[j + 5, 2].Value = item.Descripcion;                
                HojaCostos.Cells[j + 5, 5].Value = item.Qty;

                if(item.TipoItem == TipoItemEnum.SP.ToString())
                {
                    Repuesto sp = item as Repuesto;
                    HojaCostos.Cells[j + 5, 2].Value += (sp.DrwItem != "" && sp.DrwItem != null) ? 
                        $"{System.Environment.NewLine}Drawing {sp.Drw} Drw.Item {sp.DrwItem}" : "";
                    HojaCostos.Cells[j + 5, 2].Value += (sp.HSCode != "" && sp.HSCode != null) ? 
                        System.Environment.NewLine + "HS-Code: " + sp.HSCode : "";
                    HojaCostos.Cells[j + 5, 2].Value += (sp.Comentarios != "" && sp.Comentarios != null) 
                        ? System.Environment.NewLine + sp.Comentarios : "";
                    HojaCostos.Cells[j + 5, 3].Value = sp.NParte;
                    HojaCostos.Cells[j + 5, 4].Value = sp.PlazoEntrega;
                    HojaCostos.Cells[j + 5, 6].Value = item.CostoUnitario * (1 - ofValores.DescuentoProveedor / 100);

                    ventaUnit = item.VentaUnitaria;

                    if (comoItem)
                    {
                        if (prorratearPackaging && prorratearDespacho) { 
                            ventaUnit += sp.ParticipacionUnitaria * (ofValores.PackagingV + ofValores.AduanaV + ofValores.TransporteV) / item.Qty; 
                        }
                        else if (prorratearPackaging && !prorratearDespacho) { 
                            ventaUnit += sp.ParticipacionUnitaria * ofValores.PackagingV; 
                        }
                        else if (!prorratearPackaging && prorratearDespacho) { 
                            ventaUnit += sp.ParticipacionUnitaria * (ofValores.AduanaV + ofValores.TransporteV); 
                        }
                    }

                    HojaCostos.Cells[j + 5, 8].Value = ventaUnit;
                }
                else if (item.TipoItem == TipoItemEnum.SV.ToString()){
                    HojaCostos.Cells[j + 5, 6].Value = item.CostoUnitario;
                    HojaCostos.Cells[j + 5, 8].Value = item.VentaUnitaria;
                }
                j++;
            }

            HojaCostos.Cells[itemsOrdenados.Count() + 5, 2].Value = "Packaging";
            HojaCostos.Cells[itemsOrdenados.Count() + 5, 6].Value = ofValores.Packaging;
        }
    }
}

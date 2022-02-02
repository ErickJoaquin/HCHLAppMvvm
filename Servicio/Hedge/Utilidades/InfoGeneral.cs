using System;
using Model;
using Data;
using Servicios.Utilidades;
using Excel = Microsoft.Office.Interop.Excel;
using Data.Interfaces;

namespace Servicios.Hedge.Utilidades
{
    public class InfoGeneral
    {
        private readonly InformacionCliente _infoCliente;
        private readonly IRepositorioBase<Usuario> _repUser;
        public Usuario User;
        public Cliente Cliente;
        public InfoGeneral(InformacionCliente infoCliente, IRepositorioBase<Usuario> repUser)
        {
            this._infoCliente = infoCliente;
            this._repUser = repUser;

            Cliente = new Cliente();
            User = new Usuario();
        }

        public void Agregar(Excel.Worksheet HojaHedge, Oferta Oferta, OfertaClientes ofClientes, OC OC, double monto, string curr)
        {
            var entrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;

            Cliente = _infoCliente.Obtener(ofClientes);

            if (Oferta.IdBU == (int)BUEnum.HCHL)
            {
                HojaHedge.Range["C13"].Value = "E7340";
                HojaHedge.Range["E13"].Value = "Howden Chile SpA";
                HojaHedge.Range["H38"].Value = (Cliente.Pais == "CL" && Oferta.IdBU == (int)BUEnum.HCHL &&
                    (entrega.ToString() == TipoEntregaEnum.DDP.ToString() ||
                    entrega.ToString() == TipoEntregaEnum.CIF.ToString() ||
                    (entrega.ToString() == TipoEntregaEnum.ExW.ToString() && Oferta.DireccionEntrega.Contains("Chile")))) ?
                    curr + " " + (Convert.ToDouble(Oferta.VentaTotal) * 1.19).ToString("N2") :
                    curr + " " + (Convert.ToDouble(Oferta.VentaTotal)).ToString("N2");
                HojaHedge.Range["H39"].Value = (Cliente.Pais == "CL" && Oferta.IdBU == (int)BUEnum.HCHL &&
                    (entrega.ToString() == TipoEntregaEnum.DDP.ToString() ||
                    (entrega.ToString() == TipoEntregaEnum.ExW.ToString() && Oferta.DireccionEntrega.Contains("Chile")))) ?
                    curr + " " + (monto * 1.19).ToString("N2") :
                    curr + " " + (monto).ToString("N2");
                HojaHedge.Range["G46"].Value = MonedasEnum.CLP.ToString();
            }
            if (Oferta.IdBU == (int)BUEnum.HPU)
            {
                HojaHedge.Range["C13"].Value = "E7341";
                HojaHedge.Range["E13"].Value = "Howden Perú";
                HojaHedge.Range["H38"].Value = (Cliente.Pais == "PE" && Oferta.IdBU == (int)BUEnum.HPU &&
                    (entrega.ToString() == TipoEntregaEnum.DDP.ToString() ||
                    (entrega.ToString() == TipoEntregaEnum.ExW.ToString() &&
                    (Oferta.DireccionEntrega.Contains("Peru") || Oferta.DireccionEntrega.Contains("Perú"))))) ?
                    curr + " " + (Convert.ToDouble(Oferta.VentaTotal) * 1.18).ToString("N2") :
                    curr + " " + (Convert.ToDouble(Oferta.VentaTotal)).ToString("N2");
                HojaHedge.Range["H39"].Value = (Cliente.Pais == "PE" && Oferta.IdBU == (int)BUEnum.HPU &&
                    (entrega.ToString() == TipoEntregaEnum.DDP.ToString() ||
                    (entrega.ToString() == TipoEntregaEnum.ExW.ToString() &&
                    (Oferta.DireccionEntrega.Contains("Peru") || Oferta.DireccionEntrega.Contains("Perú"))))) ?
                    curr + " " + (monto * 1.18).ToString("N2") :
                    curr + " " + (monto).ToString("N2");
                HojaHedge.Range["G46"].Value = MonedasEnum.PEN.ToString();
            }

            HojaHedge.Range["J13"].Value = Oferta.NPV;
            HojaHedge.Range["J17"].Value = Oferta.NCRM;
            HojaHedge.Range["H30"].Value = Cliente.Nombre;
            HojaHedge.Range["H31"].Value = Oferta.NPV;
            HojaHedge.Range["H32"].Value = "Yes";
            HojaHedge.Range["H34"].Value = OC.FechaEmision;
            HojaHedge.Range["G45"].Value = curr;

            User = _repUser.GetByIdAsync(Oferta.IdAplicador).Result;

            HojaHedge.Range["B58"].Value = $"{User.NombreCompleto} - {DateTime.Now.ToString("dd-MM-yyyy")}";
        }
    }
}

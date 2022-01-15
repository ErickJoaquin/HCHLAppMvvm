using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Outlook = Microsoft.Office.Interop.Outlook;
using Servicios.Utilidades;
using Data.Interfaces;

namespace Utilidades.Correos.AprobacionGM.Utilidades
{
    public class Cuerpo
    {
        private readonly IRepositorioBase<BU> _repBU;
        private readonly IRepositorioBase<Pago> _repPago;
        private readonly IRepositorioBase<Vendor> _repVendor;

        public Cuerpo(IRepositorioBase<BU> repBU,IRepositorioBase<Pago> repPago, IRepositorioBase<Vendor> repVendor)
        {
            this._repBU = repBU;
            this._repPago = repPago;
            this._repVendor = repVendor;
        }

        public string Agregar(Oferta Oferta, OfertaClientes ofClientes, OfertaValores ofValores, Cliente Cliente, double Comisiones, bool Consolidando, OC OC = null)
        {
            string DestinoCliente = RepositorioPais.devolverNombrePais(Cliente.Pais);
            var enumTipoEntrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;
            var enumMoneda = (MonedasEnum)Oferta.IdMoneda;

            string AcronBU = _repBU.GetByIdAsync(Oferta.IdBU).Result.Acronimo;
            string tipoPago = _repPago.GetByIdAsync(Oferta.IdTipoPago).Result.Descripcion;

            Vendor Representante = (String.IsNullOrEmpty(ofClientes.IdRep1.ToString())) ? _repVendor.GetByIdAsync(ofClientes.IdRep1).Result : null;
            string datosRepresentante = "";
            if (Representante != null)
            {
                datosRepresentante = (Representante.Comision <= 0) ? "No aplica" : $"{Representante.Nombre}; comisión: {Representante.Comision.ToString("P2")}";
            }

            string body = "<HTML><BODY><FONT face=Arial color=#1F497D size=2>Edson, muy buenos días <br/> <br/>";
            body += $"Por favor, aprobar pricing y GM de para {Cliente.Nombre} <br/> <br/>";
            body += "Detalles:" + " <br/>";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      - Tipo: <b> Repuestos - AFM </b> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      - Comisiones: <b>{Comisiones.ToString("P2")} - Representante: {datosRepresentante} </b> <br/>";
            body += (Oferta.DetallesOferta != "") ? $"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      - Descripción Oferta: <b>{Oferta.DetallesOferta}</b> <br/>" : "";
            body += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      - Condición de Pago: <b>" + tipoPago + "</b> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      - Condición de Entrega: <b>{enumTipoEntrega.ToString()} - {Oferta.DireccionEntrega}</b> <br/>";
            body += $"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      - BU Origen/País Cliente: <b>{AcronBU} / {Cliente.Pais}</b> <br/> <br/>";

            if (Consolidando == true)
            {
                body += $"&nbsp;&nbsp;&nbsp; <FONT face=Arial color=#FF0000 size=2> <b> Oferta en consolidación, ya se recibió OC (" +
                $"{OC.Nombre}) - {Oferta.NPV} </b> <br/> <br/> <FONT face=Arial color=#1F497D size=2>";
            }

            body += "<TABLE align='center'><style> table, th, td, tr {border: 1px solid; border-collapse: collapse;} </style> <tr> <th Colspan = '2' style = 'background-color:rgb(0,100,140); text-align: center; font-face=Arial; color: white'> Resumen Pricing </th> </tr>";
            body += $"<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> Venta Total ({enumMoneda.ToString()}): </td> <td style='text-align: right'> {Oferta.VLiquida.ToString("C2")} </td> </tr>";
            body += "<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> Project Margin: </b> </td> <td style='text-align: right'> " + Oferta.GM.ToString("P2") + " </td> </tr>";
            body += "<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> Comisión: </b> </td> <td style='text-align: right'> " + Comisiones.ToString("P2") + " </td> </tr>";
            body += "<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> MN: </b> </td> <td style='text-align: right'> " + (ofValores.MN / 100).ToString("P2") + " </td> </tr>";
            body += "<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> Riesgo: </b> </td> <td style='text-align: right'> " + (ofValores.RAdicional / 100).ToString("P2") + " </td> </tr>";
            body += "<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> Financiero: </b> </td> <td style='text-align: right'> " + (ofValores.Fin / 100).ToString("P2") + " </td> </tr>";
            body += "<tr style=\"padding-left: 5px; padding-right: 5px\"> <td> <b> Ingeniería: </b> </td> <td style='text-align: right'> " + (ofValores.Ing / 100).ToString("P2") + " </td> </tr> </TABLE> <br/> <br/>";

            body += "Saludos, ";

            body += "</ FONT ></ BODY ></ HTML >"; ;

            return body;
        }
    }
}

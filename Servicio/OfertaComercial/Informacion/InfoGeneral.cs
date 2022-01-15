using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Word = Microsoft.Office.Interop.Word;
using Servicios.Utilidades;
using Servicios.OfertaComercial.Utilidades;
using Data.Interfaces;

namespace Servicios.OfertaComercial.Informacion
{
    public class InfoGeneral
    {
        private readonly ReemplazarEnWord _reemplazar;
        private readonly InformacionCliente _infoCliente;
        private readonly IRepositorioBase<ContactoCliente> _repCC;
        private readonly IRepositorioBase<Pago> _repPays;
        public InfoGeneral(ReemplazarEnWord reemplazar, InformacionCliente infoCliente, IRepositorioBase<ContactoCliente> repCC, IRepositorioBase<Pago> repPays)
        {
            this._reemplazar = reemplazar;
            this._infoCliente = infoCliente;
            this._repCC = repCC;
            this._repPays = repPays;
        }

        public void Agregar(Oferta Oferta, OfertaValores values, OfertaClientes ofClientes, List<Usuario> Usuarios, Word.Document docof)
        {
            var enumTipoEntrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;
            string Entrega = enumTipoEntrega.ToString();
            Cliente Cliente = _infoCliente.Obtener(ofClientes);
            Usuario User = Usuarios.Where(x => x.Id == Oferta.IdAplicador).FirstOrDefault();
            ContactoCliente ccto = _repCC.GetByIdAsync(ofClientes.IdContacto).Result;
            Pago pago = _repPays.GetByIdAsync(Oferta.IdTipoPago).Result;

            _reemplazar.TextoGeneral("NCRM", Oferta.NCRM.ToString(), docof, strPosterior: "-R" + Oferta.Rev.ToString());
            _reemplazar.TextoGeneral("NuestraRef", Oferta.NCRM.ToString(), docof, strPosterior: "-R" + Oferta.Rev.ToString());
            _reemplazar.TextoGeneral("Empresa", Cliente.Nombre, docof);
            _reemplazar.TextoGeneral("Cliente", Cliente.Nombre, docof);
            _reemplazar.TextoGeneral("Proyecto", Oferta.ReferenciaCliente.ToString(), docof);
            _reemplazar.TextoGeneral("Proyecto2", Oferta.ReferenciaCliente.ToString(), docof);
            _reemplazar.TextoGeneral("De_quien", User.NombreCompleto, docof);
            _reemplazar.TextoGeneral("Para_quien", ccto.NombreCompleto, docof);
            _reemplazar.TextoGeneral("Pago", pago.Descripcion, docof);
            _reemplazar.TextoGeneral("Validez", Oferta.Validez.ToString(), docof, strPosterior: " días");
            
            string imp1 = ""; string imp2 = "";
            if (Oferta.Nacional && Oferta.IdBU == 8) { imp1 = "+ IVA"; imp2 = "IVA"; }
            else if (Oferta.Nacional && Oferta.IdBU == 22) { imp1 = "+ IGV"; imp2 = "IGV"; }
            else if (Oferta.Idioma == "Ing") { imp1 = ""; imp2 = "Taxes"; }
            else { imp1 = ""; imp2 = "Impuestos"; }
            _reemplazar.TextoGeneral("IVA", imp1, docof, bold: 1);
            _reemplazar.TextoGeneral("IVA2", imp2, docof, bold: 1);

            if (String.IsNullOrEmpty(Oferta.DetallesOferta)) { docof.Tables[3].Rows[2].Delete(); }
            else { _reemplazar.TextoGeneral("Detalles", Oferta.DetallesOferta, docof); }                                  

            if (Oferta.IdBU == (int)BUEnum.HCHL)
            {
                _reemplazar.TextoGeneral("Entrega", Entrega, docof, strPosterior: " - " + Oferta.DireccionEntrega); 
                if (values.Packaging != 0 && (values.Transporte != 0 || values.Aduana != 0)) { _reemplazar.TextoGeneral("Packaging", Entrega, docof, strPrevio: " (Incluye packaging y gastos por movilización de repuestos, según Incoterm ", strPosterior: ")"); }
                else if (values.Packaging == 0 && (values.Transporte != 0 || values.Aduana != 0)) { _reemplazar.TextoGeneral("Packaging", Entrega, docof, strPrevio: " (Incluye gastos por movilización de repuestos, según Incoterm ", strPosterior: ")"); }
                else if (values.Packaging != 0 && values.Transporte == 0 && values.Aduana == 0) { _reemplazar.TextoGeneral("Packaging", "(Incluye packaging)", docof); }
                else if (values.Packaging == 0 && values.Transporte == 0 && values.Aduana == 0) { _reemplazar.TextoGeneral("Packaging", "(No incluye packaging, ni gastos por movilización)", docof); }
            }
            else if (Oferta.IdBU == (int)BUEnum.HPU)
            {
                _reemplazar.TextoGeneral("Entrega", Oferta.DireccionEntrega, docof); 
                if (values.Packaging != 0 && (values.Transporte != 0 || values.Aduana != 0)) { _reemplazar.TextoGeneral("Packaging", " (Incluye packaging y gastos por movilización de repuestos)", docof); }
                else if (values.Packaging == 0 && (values.Transporte != 0 || values.Aduana != 0)) { _reemplazar.TextoGeneral("Packaging", " (Incluye gastos por movilización de repuestos)", docof); }
                else if (values.Packaging != 0 && values.Transporte == 0 && values.Aduana == 0) { _reemplazar.TextoGeneral("Packaging", "(Incluye packaging)", docof); }
                else if (values.Packaging == 0 && values.Transporte == 0 && values.Aduana == 0) { _reemplazar.TextoGeneral("Packaging", "", docof); }
            }
        }
    }
}

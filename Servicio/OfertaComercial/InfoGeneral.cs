using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using Servicios.Utilidades;

namespace Servicios.OfertaComercial
{
    public class InfoGeneral
    {
        public void Agregar(Oferta Oferta, OfertaValores values, OfertaClientes clientes, List<Usuario> Usuarios, Word.Document docof)
        {
            var infoCliente = new InformacionCliente();
            var enumTipoEntrega = (TipoEntregaEnum)Oferta.IdTipoEntrega;
            string Entrega = enumTipoEntrega.ToString();
            Cliente Cliente = infoCliente.obtener(Oferta);
            Usuario User = Usuarios.Where(x => x.Id == Oferta.IdAplicador).FirstOrDefault();

            RepositorioBase<ContactoCliente> repCC = new RepositorioBase<ContactoCliente>();
            ContactoCliente ccto = repCC.GetByIdAsync(clientes.IdContacto).Result;

            RepositorioBase<Pago> repPays = new RepositorioBase<Pago>();
            Pago pago = repPays.GetByIdAsync(Oferta.IdTipoPago).Result;

            ReemplazarEnWord.textoGeneral("NCRM", Oferta.NCRM.ToString(), docof, strPosterior: "-R" + Oferta.Rev.ToString());
            ReemplazarEnWord.textoGeneral("NuestraRef", Oferta.NCRM.ToString(), docof, strPosterior: "-R" + Oferta.Rev.ToString());
            ReemplazarEnWord.textoGeneral("Empresa", Cliente.Nombre, docof);
            ReemplazarEnWord.textoGeneral("Cliente", Cliente.Nombre, docof);
            ReemplazarEnWord.textoGeneral("Proyecto", Oferta.ReferenciaCliente.ToString(), docof);
            ReemplazarEnWord.textoGeneral("Proyecto2", Oferta.ReferenciaCliente.ToString(), docof);
            ReemplazarEnWord.textoGeneral("De_quien", User.NombreCompleto, docof);
            ReemplazarEnWord.textoGeneral("Para_quien", ccto.NombreCompleto, docof);
            ReemplazarEnWord.textoGeneral("Pago", pago.Descripcion, docof);
            ReemplazarEnWord.textoGeneral("Validez", Oferta.Validez.ToString(), docof, strPosterior: " días");
            
            string imp1 = ""; string imp2 = "";
            if (Oferta.Nacional && Oferta.IdBU == 8) { imp1 = "+ IVA"; imp2 = "IVA"; }
            else if (Oferta.Nacional && Oferta.IdBU == 22) { imp1 = "+ IGV"; imp2 = "IGV"; }
            else if (Oferta.Idioma == "Ing") { imp1 = ""; imp2 = "Taxes"; }
            else { imp1 = ""; imp2 = "Impuestos"; }
            ReemplazarEnWord.textoGeneral("IVA", imp1, docof, bold: 1);
            ReemplazarEnWord.textoGeneral("IVA2", imp2, docof, bold: 1);


            if (String.IsNullOrEmpty(Oferta.DetallesOferta)) { docof.Tables[3].Rows[2].Delete(); }
            else {   ReemplazarEnWord.textoGeneral("Detalles", Oferta.DetallesOferta, docof); }
                                  

            if (Oferta.IdBU == (int)BUEnum.HCHL)
            {
                ReemplazarEnWord.textoGeneral("Entrega", Entrega, docof, strPosterior: " - " + Oferta.DireccionEntrega); 
                if (values.Packaging != 0 && (values.Transporte != 0 || values.Aduana != 0)) { ReemplazarEnWord.textoGeneral("Packaging", Entrega, docof, strPrevio: " (Incluye packaging y gastos por movilización de repuestos, según Incoterm ", strPosterior: ")"); }
                else if (values.Packaging == 0 && (values.Transporte != 0 || values.Aduana != 0)) { ReemplazarEnWord.textoGeneral("Packaging", Entrega, docof, strPrevio: " (Incluye gastos por movilización de repuestos, según Incoterm ", strPosterior: ")"); }
                else if (values.Packaging != 0 && values.Transporte == 0 && values.Aduana == 0) { ReemplazarEnWord.textoGeneral("Packaging", "(Incluye packaging)", docof); }
                else if (values.Packaging == 0 && values.Transporte == 0 && values.Aduana == 0) { ReemplazarEnWord.textoGeneral("Packaging", "(No incluye packaging, ni gastos por movilización)", docof); }
            }
            else if (Oferta.IdBU == (int)BUEnum.HPU)
            {
                ReemplazarEnWord.textoGeneral("Entrega", Oferta.DireccionEntrega, docof); 
                if (values.Packaging != 0 && (values.Transporte != 0 || values.Aduana != 0)) { ReemplazarEnWord.textoGeneral("Packaging", " (Incluye packaging y gastos por movilización de repuestos)", docof); }
                else if (values.Packaging == 0 && (values.Transporte != 0 || values.Aduana != 0)) { ReemplazarEnWord.textoGeneral("Packaging", " (Incluye gastos por movilización de repuestos)", docof); }
                else if (values.Packaging != 0 && values.Transporte == 0 && values.Aduana == 0) { ReemplazarEnWord.textoGeneral("Packaging", "(Incluye packaging)", docof); }
                else if (values.Packaging == 0 && values.Transporte == 0 && values.Aduana == 0) { ReemplazarEnWord.textoGeneral("Packaging", "", docof); }
            }
        }
    }
}

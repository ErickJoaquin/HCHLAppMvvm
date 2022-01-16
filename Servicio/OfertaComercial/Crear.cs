using System;
using System.Collections.Generic;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using Servicios.Utilidades;
using System.Windows.Forms;
using Servicios.OfertaComercial.Utilidades;
using Servicios.OfertaComercial.Informacion;
using Data.Interfaces;

namespace Servicios.OfertaComercial
{
    public class Crear
    {
        private readonly Guardar _guardar;
        private readonly MoverRevisiones _moverRevs;
        private readonly InfoGeneral _infoGrl;
        private readonly InfoContactos _infoCcto;
        private readonly InfoItems _infoItems;
        private readonly InfoBU _infoBU;
        private readonly InfoEquipos _infoEquipos;
        private readonly InfoBanco _infoBanco;
        private readonly InfoRepresentantes _infoRep;
        private readonly RepositorioCarpetas _repCarpeta;
        private readonly IRepositorioBase<BU> _repBU;
        private readonly IRepositorioBase<Usuario> _repUser;

        public Crear(InfoGeneral infoGrl, InfoContactos infoCcto, InfoItems infoItems, InfoBU infoBU, InfoEquipos infoEquipos, InfoBanco infoBanco, InfoRepresentantes infoRep,
            RepositorioCarpetas repCarpeta, IRepositorioBase<BU> repBU, IRepositorioBase<Usuario> repUser, MoverRevisiones moverRevs, Guardar guardar)
        {
            this._infoGrl = infoGrl;
            this._infoCcto = infoCcto;
            this._infoItems = infoItems;
            this._infoBU = infoBU;
            this._infoEquipos = infoEquipos;
            this._infoBanco = infoBanco;
            this._infoRep = infoRep;
            this._repCarpeta = repCarpeta;
            this._repBU = repBU;
            this._repUser = repUser;
            this._moverRevs = moverRevs;
            this._guardar = guardar;
        }

        public void Nueva(Oferta Oferta, OfertaValores ofValues, OfertaClientes ofClientes, bool Consolidando, 
            bool incluyeRep, bool comoItem, bool prorratearDespacho, bool prorratearPackaging)
        {
            if (Oferta.Idioma == "") { return; }

            try
            {
                BU Unidad = _repBU.GetByIdAsync(Oferta.IdBU).Result;
                List<Usuario> Usuarios = _repUser.GetAllAsync().Result;
                
                string carpetaPedida = _repCarpeta.GetPathAsync((int)BUEnum.HCHL, CarpetasEnum.templates.ToString()).Result;
                string rutaoftemplate = $"{carpetaPedida}\\{Oferta.Idioma}.dotm";
                
                Word.Application WrdDoc = new Word.Application();
                Word.Document docof = WrdDoc.Documents.Add(rutaoftemplate);

                _infoGrl.Agregar(Oferta, ofValues, ofClientes, Usuarios,  docof);
                _infoBU.Agregar(Oferta, Unidad, docof);
                _infoItems.Agregar(Oferta, ofValues, docof, comoItem, prorratearDespacho, prorratearPackaging);
                _infoEquipos.Agregar(Oferta, docof);
                _infoCcto.Agregar(Oferta, Usuarios, docof);
                _infoBanco.Agregar(Oferta, Unidad, docof);
                _infoRep.Agregar(ofClientes, Oferta.Idioma, incluyeRep, docof);
                
                WrdDoc.Visible = true;

                _guardar.WordPDF(Oferta, docof, Consolidando);
                _moverRevs.TrasladarAntiguas(Oferta, true);
            }
            catch (Exception ex) { MessageBox.Show("No se pudo crear la oferta, comuniquese con el administrador. Error: " + ex); }

        }        
    }
}

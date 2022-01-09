using System;
using System.Collections.Generic;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using Servicios.Utilidades;
using System.Windows.Forms;

namespace Servicios.OfertaComercial
{
    public class Crear
    {
        public void Nueva(Oferta Oferta, OfertaValores ofValues, OfertaClientes ofClientes, bool Consolidando, 
            bool incluyeRep, bool comoItem, bool prorratearDespacho, bool prorratearPackaging)
        {
            if (Oferta.Idioma == "") { return; }

            try
            {
                RepositorioBase<BU> repBU = new RepositorioBase<BU>();
                BU Unidad = repBU.GetByIdAsync(Oferta.IdBU).Result;

                RepositorioBase<Usuario> repUser = new RepositorioBase<Usuario>();
                List<Usuario> Usuarios = repUser.GetAllAsync().Result;

                RepositorioCarpetas repCarpeta = new RepositorioCarpetas();
                string carpetaPedida = repCarpeta.GetPathAsync((int)BUEnum.HCHL, CarpetasEnum.templates.ToString()).Result;
                string rutaoftemplate = $"{carpetaPedida}\\{Oferta.Idioma}.dotm";
                
                Word.Application WrdDoc = new Word.Application();
                Word.Document docof = WrdDoc.Documents.Add(rutaoftemplate);

                var infoGrl = new InfoGeneral();
                var infoCcto = new InfoContactos();
                var infoItems = new InfoItems();
                var infoBU = new InfoBU();
                var infoEquipos = new InfoEquipos();
                var infoContactos = new InfoContactos();
                var infoBanco = new InfoBanco();
                var infoRep = new InfoRepresentantes();                            

                infoGrl.Agregar(Oferta, ofValues, ofClientes, Usuarios,  docof);
                infoBU.Agregar(Oferta, Unidad, docof);
                infoItems.Agregar(Oferta, ofValues, docof, comoItem, prorratearDespacho, prorratearPackaging);
                infoEquipos.Agregar(Oferta, docof);
                infoContactos.Agregar(Oferta, Usuarios, docof);
                infoBanco.Agregar(Oferta, Unidad, docof);
                infoRep.Agregar(ofClientes, Oferta.Idioma, incluyeRep, docof);
                
                WrdDoc.Visible = true;

                Guardar.wordPDF(Oferta, docof, Consolidando);
                MoverRevisiones.trasladarAntiguas(Oferta, true);
            }
            catch (Exception ex) { MessageBox.Show("No se pudo crear la oferta, comuniquese con el administrador. Error: " + ex); }

        }        
    }
}

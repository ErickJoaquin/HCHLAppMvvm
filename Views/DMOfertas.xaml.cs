using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HCHLView.Views
{
    /// <summary>
    /// Lógica de interacción para DMOfertas.xaml
    /// </summary>
    public partial class DMOfertas : Window
    {
        public DMOfertas()
        {
            InitializeComponent();

            CbxOfertas.Items.Add("Editando");
            CbxOfertas.Items.Add("Enviadas");
            CbxOfertas.Items.Add("Consolidando");
            CbxOfertas.Items.Add("Vendidas");
            CbxOfertas.SelectedValue = "Editando";
        }



        /// <summary>
        /// DataGrid DGDM
        /// </summary>]

        /// <summary>
        /// Botones Dinamicos en Menu Boton derecho
        /// </summary>
        private void DGDM_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        /// <summary>
        /// Edita Revision Seleccionada
        /// </summary>
        private void BtnEditarRev_Click(object sender, MouseButtonEventArgs e)
        {

        }
        private void BtnEditarRev_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditarOferta()
        {

        }

        /// <summary>
        /// Crea proxima revision, a partir de la seleccionada
        /// </summary>
        private void BtnCrearRev_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Consolidar Oferta
        /// </summary>
        private void BtnConsolidar_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Abre carpeta de oferta seleccionada
        /// </summary>
        private void BtnAbrirCarpeta_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Drag and Drop de archivos en Carpeta d eoferta seleccionada
        /// </summary>
        private void BtnAgregarArchivos_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Elimina oferta seleccionada
        /// </summary>
        private void BtnEliminarOferta_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRevisiones_Click(object sender, RoutedEventArgs e)
        {
            
        }






        /// <summary>
        /// DataGrid DGConsolidado
        /// </summary>

        /// <summary>
        /// Cambia Botones en Menu del Boton derecho
        /// </summary>
        private void DGConsolidando_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {

        }

        /// <summary>
        /// Abre OSP para consolidar Oferta
        /// </summary>
        private void BtnConsolidarOf_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Evalua cuantos Hedges debe crear y llama a la funcion CrearHedge()
        /// </summary>
        private void BtnHedge_Click(object sender, RoutedEventArgs e)
        {

        }


        /// <summary>
        /// Cambia oferta y revisiones a "Activa"
        /// </summary>
        private void BtnDevolverOferta_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Mueve Oferta, Pricing //oferta proveedor, mails
        /// </summary>
        private void BtnTrasladarDocs_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Deja oferta como vendida
        /// </summary>
        private void BtnEnviarVentas_Click(object sender, RoutedEventArgs e)
        {

        }


        private void WindowActivated(object sender, EventArgs e)
        {

        }






        private void BtCambiarEstado_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Cambia las infos a mostrar segun lo que el cliente pida con el ToggleButton, llama a ActulizarVista
        /// </summary>
        private void CbxOfertas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Copiar oferta para otro cliente con dsitinto numero de CRM 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCopiarOferta_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Abre carpeta de Ventas
        /// </summary>
        private void BtnAbrirCarpetaVentas_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Abre carpeta de Oferta
        /// </summary>
        private void BtnAbrirCarpetaOferta_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Compara archivos en carpetas de PV y Oferta
        /// </summary>
        private void BtnCompararArchivosC_Click(object sender, RoutedEventArgs e)
        {

        }












        /// <summary>
        /// BOTONES SUPERIORES
        /// </summary>]

        /// <summary>
        /// Agregar Oferta Nueva, abre Ventana NCRM
        /// </summary>]
        private void BtAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Boton para solicitar cotizaciones
        /// </summary>
        private void Btncotizar_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Boton para actualizar Datagrid, llama a ActulizarVista
        /// </summary>
        private void BtActualizar_Click(object sender, RoutedEventArgs e)
        {

        }




        private void Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TbxBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}


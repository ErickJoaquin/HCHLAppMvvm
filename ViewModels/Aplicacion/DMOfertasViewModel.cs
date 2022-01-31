using System.Collections.ObjectModel;
using Model.ReadModel;
using Data.Repositorios;
using System.Windows;
using Prism.Mvvm;
using System.Collections.Generic;
using Prism.Regions;
using Data.Interfaces;
using System.Linq;
using System;
using Prism.Commands;
using Servicios.Utilidades;

namespace HCHLView.ViewModels.Aplicacion
{
    public class DMOfertasViewModel : ViewModelBase, INavigationAware
    {
        private List<string> _listaEstadosOferta;
        public List<string> ListaEstadosOferta
        {
            get
            {
                return _listaEstadosOferta;
            }
            set
            {
                _listaEstadosOferta = value;
            }
        }

        private string _estadoSeleccionado;
        public string EstadoSeleccionado
        {
            get
            {
                return _estadoSeleccionado;
            }

            set
            {
                if (value != null)
                    _estadoSeleccionado = value;
                    LoadData(_estadoSeleccionado);
            }
        }
        private ObservableCollection<OfertaCompleta> _listaOfertas { get; set; }

        public ObservableCollection<OfertaCompleta> ListaOfertas
        {
            get
            {
                return _listaOfertas;
            }
            private set
            {
                if (value != null)
                    _listaOfertas = value;
            }
        }
        private OfertaCompleta _ofertaSeleccionada { get; set; }

        public OfertaCompleta OfertaSeleccionada
        {
            get
            {
                return _ofertaSeleccionada;
            }
            set
            {
                if (value != null)
                    _ofertaSeleccionada = value;
                    AdaptarDMOfertasContextMenu();
            }
        }

        

        public decimal? VentaTotalOfertasVisibles { get; set; }
        public List<string> ListaClientes { get; private set; }
        public List<string> ListaProveedores { get; private set; }
        public List<string> ListaEquipos { get; private set; }
        public List<string> ListaMercados { get; private set; }
        public List<string> ListaResponsables { get; private set; }
        public Visibility IsLvDMVisible { get; set; }
        public Visibility IsLvVentasVisible { get; set; }
        public string BtnVerRevisionesHeader { get; set; }
        public string BtnEditarRevisionHeader { get; set; }
        public string BtnCrearRevisionHeader { get; set; }
        public string BtnConsolidarHeader { get; set; }
        public string BtnAbrirCarpetaHeader { get; set; }
        public string BtnCopiarOfertaHeader { get; set; }
        public string BtnEnviarAEdicionHeader { get; set; }
        public string BtnMarcarComoEnviadaHeader { get; set; }
        public string BtnMarcarComoPerdidaHeader { get; set; }
        public string BtnCancelarOfertaHeader { get; set; }
        public string BtnEliminarOfertaHeader { get; set; }
        public bool BtnVerRevisionesEnable { get; set; }
        public Visibility BtnEditarRevisionVisible { get; set; }
        public Visibility BtnCrearRevisionVisible { get; set; }
        public Visibility BtnConsolidarVisible { get; set; }
        public Visibility BtnCopiarOfertaVisible { get; set; }
        public Visibility BtnEnviarAEdicionVisible { get; set; }
        public Visibility BtnMarcarComoEnviadaVisible { get; set; }
        public Visibility BtnMarcarComoPerdidaVisible { get; set; }
        public Visibility BtnCancelarOfertaVisible { get; set; }
        public Visibility BtnEliminarOfertaVisible { get; set; }
        public DelegateCommand AbrirCarpetaCommand { get; private set; }

        private readonly IRepositorioOferta _repOferta; 
        private readonly IRepositorioRevisiones _repRevisiones; 
        private readonly Directorio _directorio; 

        public DMOfertasViewModel(IRepositorioOferta repOferta, IRepositorioRevisiones repRevisiones, Directorio directorio)
        {
            _listaOfertas = new ObservableCollection<OfertaCompleta>();
            _listaEstadosOferta = new List<string>() { "Editando", "Enviadas", "Consolidando", "Vendidas" };

            this._repOferta = repOferta;
            this._repRevisiones = repRevisiones;
            this._directorio = directorio;

            IsLvDMVisible = Visibility.Visible;
            IsLvVentasVisible = Visibility.Collapsed;

            AbrirCarpetaCommand = new DelegateCommand(AbrirCarpetaMethod);
        }

        private void AbrirCarpetaMethod()
        {
            _directorio.Abrir(_ofertaSeleccionada.IdBU, _ofertaSeleccionada.NCRM);
        }

        private async void LoadData(string estadoAMostrar)
        {
            _listaOfertas.Clear();
            IsLvDMVisible = Visibility.Collapsed;
            IsLvVentasVisible = Visibility.Collapsed;


            switch (estadoAMostrar)
            {
                case "Editando":
                    var ofertasEdicion = await _repOferta.GetAllByStateAsync("Edicion");
                    _listaOfertas.AddRange(ofertasEdicion);
                    IsLvDMVisible = Visibility.Visible;
                    break;
                case "Enviadas":
                    var ofertasEnviadas = await _repOferta.GetAllByStateAsync("Enviada");
                    _listaOfertas.AddRange(ofertasEnviadas);
                    IsLvDMVisible = Visibility.Visible;
                    break;
                case "Consolidando":
                    var ofertasConsolidando = await _repOferta.GetAllByStateAsync("Consolidando");
                    _listaOfertas.AddRange(ofertasConsolidando);
                    IsLvVentasVisible = Visibility.Visible;
                    break;
                case "Vendidas":
                    var ofertasVendidas = await _repOferta.GetAllByStateAsync("Vendida");
                    _listaOfertas.AddRange(ofertasVendidas);
                    IsLvVentasVisible = Visibility.Visible;
                    break;
                default:
                    MessageBox.Show("");
                    break;
            }

            VentaTotalOfertasVisibles = (decimal)_listaOfertas.Sum(x => x.VentaTotal); // Falta convertir monedas

            ListaClientes = _listaOfertas.Select(x => x.Cliente).Distinct().OrderBy(x => x).ToList();
            ListaProveedores = _listaOfertas.Select(x => x.Proveedor).Distinct().OrderBy(x => x).ToList();
            ListaEquipos = _listaOfertas.Select(x => x.TipoEquipo).Distinct().OrderBy(x => x).ToList();
            ListaMercados = _listaOfertas.Select(x => x.Segmento).Distinct().OrderBy(x => x).ToList();
            ListaResponsables = _listaOfertas.Select(x => x.Aplicador).Distinct().OrderBy(x => x).ToList();

            RaisePropertyChanged(nameof(ListaOfertas));
            RaisePropertyChanged(nameof(VentaTotalOfertasVisibles));
            RaisePropertyChanged(nameof(IsLvVentasVisible));
            RaisePropertyChanged(nameof(IsLvDMVisible));

            RaisePropertyChanged(nameof(ListaClientes));
            RaisePropertyChanged(nameof(ListaProveedores));
            RaisePropertyChanged(nameof(ListaEquipos));
            RaisePropertyChanged(nameof(ListaMercados));
            RaisePropertyChanged(nameof(ListaResponsables));
        }
        private async void AdaptarDMOfertasContextMenu()
        {
            List<int> revs = await _repRevisiones.GetRevisions(_ofertaSeleccionada.NCRM);

            ContexMenuDMOfertasHeaders(revs.Count());
            ContexMenuDMOfertasVisibility(revs.Count());
        }

        private void ContexMenuDMOfertasHeaders(int nRevs)
        {
            BtnVerRevisionesHeader = $"Ver revisiones de {_ofertaSeleccionada.NCRM}";
            BtnEditarRevisionHeader = $"Editar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev}";
            if (_estadoSeleccionado == "Enviadas")
            {
                BtnEditarRevisionHeader = $"Ver {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev}";
            }
            BtnCrearRevisionHeader = $"Crear revision {nRevs} a partir de {_ofertaSeleccionada.Rev}";
            BtnConsolidarHeader = $"Consolidar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev}";
            BtnAbrirCarpetaHeader = $"Abrir carpeta {_ofertaSeleccionada.NCRM}";
            BtnCopiarOfertaHeader = $"Copiar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev}";
            BtnEnviarAEdicionHeader = $"Enviar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev} a edición";
            BtnMarcarComoEnviadaHeader = $"Marcar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev} como enviada";
            BtnMarcarComoPerdidaHeader = $"Marcar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev} como perdida";
            BtnCancelarOfertaHeader = $"Cancelar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev}";
            BtnEliminarOfertaHeader = $"Eliminar {_ofertaSeleccionada.NCRM}-{_ofertaSeleccionada.Rev}";

            RaisePropertyChanged(nameof(BtnVerRevisionesHeader));
            RaisePropertyChanged(nameof(BtnAbrirCarpetaHeader));
            RaisePropertyChanged(nameof(BtnEditarRevisionHeader));
            RaisePropertyChanged(nameof(BtnCrearRevisionHeader));
            RaisePropertyChanged(nameof(BtnConsolidarHeader));
            RaisePropertyChanged(nameof(BtnCopiarOfertaHeader));
            RaisePropertyChanged(nameof(BtnEnviarAEdicionHeader));
            RaisePropertyChanged(nameof(BtnMarcarComoEnviadaHeader));
            RaisePropertyChanged(nameof(BtnMarcarComoPerdidaHeader));
            RaisePropertyChanged(nameof(BtnCancelarOfertaHeader));
            RaisePropertyChanged(nameof(BtnEliminarOfertaHeader));
        }

        private void ContexMenuDMOfertasVisibility(int nRevs)
        {
            BtnVerRevisionesEnable = false;
            BtnEditarRevisionVisible = Visibility.Collapsed;
            BtnCrearRevisionVisible = Visibility.Collapsed;
            BtnConsolidarVisible = Visibility.Collapsed;
            BtnCopiarOfertaVisible = Visibility.Collapsed;
            BtnEnviarAEdicionVisible = Visibility.Collapsed;
            BtnMarcarComoEnviadaVisible = Visibility.Collapsed;
            BtnMarcarComoPerdidaVisible = Visibility.Collapsed;
            BtnCancelarOfertaVisible = Visibility.Collapsed;
            BtnEliminarOfertaVisible = Visibility.Collapsed;

            if (_estadoSeleccionado == "Enviadas")
            {
                if (nRevs > 1) { BtnVerRevisionesEnable = true; }
                BtnEditarRevisionVisible = Visibility.Visible;
                BtnCrearRevisionVisible = Visibility.Collapsed;
                BtnConsolidarVisible = Visibility.Visible;
                BtnCopiarOfertaVisible = Visibility.Visible;
                BtnEnviarAEdicionVisible = Visibility.Visible;
                BtnMarcarComoEnviadaVisible = Visibility.Collapsed;
                BtnMarcarComoPerdidaVisible = Visibility.Visible;
                BtnCancelarOfertaVisible = Visibility.Visible;
                BtnEliminarOfertaVisible = Visibility.Collapsed;
                //BtnVerOfertaVisible = Visibility.Collapsed;
            }
            else
            {
                if (nRevs > 1) { BtnVerRevisionesEnable = true; }
                BtnEditarRevisionVisible = Visibility.Visible;
                BtnCrearRevisionVisible = Visibility.Visible;
                BtnConsolidarVisible = Visibility.Collapsed;
                BtnCopiarOfertaVisible = Visibility.Visible;
                BtnEnviarAEdicionVisible = Visibility.Collapsed;
                BtnMarcarComoEnviadaVisible = Visibility.Visible;
                BtnMarcarComoPerdidaVisible = Visibility.Collapsed;
                BtnCancelarOfertaVisible = Visibility.Visible;
                BtnEliminarOfertaVisible = Visibility.Collapsed;
            }

            RaisePropertyChanged(nameof(BtnVerRevisionesEnable));
            RaisePropertyChanged(nameof(BtnEditarRevisionVisible));
            RaisePropertyChanged(nameof(BtnCrearRevisionVisible));
            RaisePropertyChanged(nameof(BtnConsolidarVisible));
            RaisePropertyChanged(nameof(BtnCopiarOfertaVisible));
            RaisePropertyChanged(nameof(BtnEnviarAEdicionVisible));
            RaisePropertyChanged(nameof(BtnMarcarComoEnviadaVisible));
            RaisePropertyChanged(nameof(BtnMarcarComoPerdidaVisible));
            RaisePropertyChanged(nameof(BtnCancelarOfertaVisible));
            RaisePropertyChanged(nameof(BtnEliminarOfertaVisible));
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}

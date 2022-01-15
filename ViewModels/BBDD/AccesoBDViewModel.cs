using Data;
using Model;
using Model.ReadModel;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace HCHLView.ViewModels
{
    class AccesoBDViewModel : BindableBase, INavigationAware 
    {
        private TablasBD _seleccion;
        public TablasBD Seleccion
        {
            get
            {
                return _seleccion;
            }

            set
            {
                if (value != null)
                    _seleccion = value;
                    ListViewAMostrar(_seleccion.NombreEnBD);
                    LoadData(_seleccion.NombreEnBD);
            }
        }

        private Usuario _objSeleccionado;
        public Usuario ObjSeleccionado
        {
            get
            {
                return _objSeleccionado;
            }
            set
            {
                if (value != null)
                    _objSeleccionado = value;
            }
        }


        public string Buscador { get; set; }
        public List<TablasBD> ListaOpciones { get; }
        public ObservableCollection<Usuario> ListUsuarios { get; private set; }
        public ObservableCollection<BaseInstalada> ListBaseInstalada { get; private set; }
        public ObservableCollection<BU> ListBUs { get; private set; }
        public ObservableCollection<ContactoCliente> ListCctoCliente { get; private set; }
        public ObservableCollection<ContactoBU> ListCctoBU { get; private set; }
        public ObservableCollection<EndUser> ListEndUser { get; private set; }
        public ObservableCollection<Pago> ListPago { get; private set; }
        public ObservableCollection<Vendor> ListVendor { get; private set; }

        private readonly IRepositorioBase<Usuario> _repoUsuario;
        private readonly IRepositorioBase<BaseInstalada> _repoBaseInstalada;
        private readonly IRepositorioBase<BU> _repoBU;
        private readonly IRepositorioBase<ContactoCliente> _repoCctoCliente;
        private readonly IRepositorioBase<ContactoBU> _repoCctoBU;
        private readonly IRepositorioBase<EndUser> _repoEndUser;
        private readonly IRepositorioBase<Pago> _repoPago;
        private readonly IRepositorioBase<Vendor> _repoVendor;

        public AccesoBDViewModel(IRepositorioBase<Usuario> repoUsuario, IRepositorioBase<BaseInstalada> repoBaseInstalada, IRepositorioBase<BU> repoBU,
            IRepositorioBase<ContactoCliente> repoCctoCliente, IRepositorioBase<ContactoBU> repoCctoBU, IRepositorioBase<EndUser> repoEndUser,
            IRepositorioBase<Pago> repoPago, IRepositorioBase<Vendor> repoVendor, RepositorioTablasBD repositorioTablasBD)
        {
            ListaOpciones = new List<TablasBD>(repositorioTablasBD.GetAll());

            ListUsuarios = new ObservableCollection<Usuario>();
            ListBaseInstalada = new ObservableCollection<BaseInstalada>();
            ListBUs = new ObservableCollection<BU>();
            ListCctoCliente = new ObservableCollection<ContactoCliente>();
            ListCctoBU = new ObservableCollection<ContactoBU>();
            ListEndUser = new ObservableCollection<EndUser>();
            ListPago = new ObservableCollection<Pago>();
            ListVendor = new ObservableCollection<Vendor>();

            this._repoUsuario = repoUsuario;
            this._repoBaseInstalada = repoBaseInstalada;
            this._repoBU = repoBU;
            this._repoCctoCliente = repoCctoCliente;
            this._repoCctoBU = repoCctoBU;
            this._repoEndUser = repoEndUser;
            this._repoPago = repoPago;
            this._repoVendor = repoVendor;
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //
        }

        private async void LoadData(string TablaAMostrar)
        {
            switch (TablaAMostrar)
            {
                case "Usuario":
                    var usuarios = await _repoUsuario.GetAllAsync();
                    ListUsuarios.AddRange(usuarios);
                    break;
                case "BaseInstalada":
                    var bis = await _repoBaseInstalada.GetAllAsync();
                    ListBaseInstalada.AddRange(bis);
                    break;
                case "BU":
                    var bus = await _repoBU.GetAllAsync();
                    ListBUs.AddRange(bus); 
                    break;
                case "ContactoCliente":
                    var cctocls = await _repoCctoCliente.GetAllAsync();
                    ListCctoCliente.AddRange(cctocls); 
                    break;
                case "ContactoBU":
                    var cctobu = await _repoCctoBU.GetAllAsync();
                    ListCctoBU.AddRange(cctobu);
                    break;
                case "EndUser":
                    var eus = await _repoEndUser.GetAllAsync();
                    ListEndUser.AddRange(eus);
                    break;
                case "Pago":
                    var pagos = await _repoPago.GetAllAsync();
                    ListPago.AddRange(pagos);
                    break;
                case "Vendor":
                    var vendors = await _repoVendor.GetAllAsync();
                    ListVendor.AddRange(vendors);
                    break;
                default:
                    MessageBox.Show("");
                    break;
            }
        }

        public Visibility userVis { get; set; }
        public Visibility bisVis { get; set; }
        public Visibility buVis { get; set; }
        public Visibility cctosClienteVis { get; set; }
        public Visibility cctosBusVis { get; set; }
        public Visibility euVis { get; set; }
        public Visibility pagoVis { get; set; }
        public Visibility vendorVis { get; set; }

        private void ListViewAMostrar(string TablaAMostrar)
        {
            if (TablaAMostrar == "Usuario") { userVis = Visibility.Visible; }
            else { userVis = Visibility.Collapsed; }

            if (TablaAMostrar == "BaseInstalada") { bisVis = Visibility.Visible; }
            else { bisVis = Visibility.Collapsed; }

            if (TablaAMostrar == "BU") {buVis = Visibility.Visible; }
            else { buVis = Visibility.Collapsed; }

            if (TablaAMostrar == "ContactoCliente") { cctosClienteVis = Visibility.Visible; }
            else { cctosClienteVis = Visibility.Collapsed; }

            if (TablaAMostrar == "ContactoBU") { cctosBusVis = Visibility.Visible; }
            else { cctosBusVis = Visibility.Collapsed; }

            if (TablaAMostrar == "EndUser") { euVis = Visibility.Visible; }
            else { euVis = Visibility.Collapsed; }

            if (TablaAMostrar == "Pago") { pagoVis = Visibility.Visible; }
            else { pagoVis = Visibility.Collapsed; }

            if (TablaAMostrar == "Vendor") { vendorVis = Visibility.Visible; }
            else { vendorVis = Visibility.Collapsed; }
        }
    }
}

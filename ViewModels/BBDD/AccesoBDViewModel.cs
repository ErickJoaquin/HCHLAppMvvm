using Data.Interfaces;
using Model;
using Model.ReadModel;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Collections.Generic;
using Data.Repositorios;

namespace HCHLView.ViewModels.BBDD
{
    public class AccesoBDViewModel : ViewModelBase, INavigationAware
    {
        private TablasBD _tablaSeleccionada;
        public TablasBD TablaSeleccionada
        {
            get
            {
                return _tablaSeleccionada;
            }

            set
            {
                if (value != null)
                {
                    _tablaSeleccionada = value;
                    LoadData(_tablaSeleccionada.NombreEnBD);
                }
            }
        }

        private string _buscador;
        public string Buscador 
        {
            get
            {
                return _buscador;
            }

            set
            {
                if (value != null)
                {
                    _buscador = value;
                    FilterData(_buscador, _tablaSeleccionada.NombreEnBD);
                }
            }
        }
                
        public Visibility IsLvUsuariosVisible { get; set; }
        public Visibility IsLvBaseInstaladaVisible { get; set; }
        public Visibility IsLvEndUserVisible { get; set; }
        public Visibility IsLvCctoClienteVisible { get; set; }
        public Visibility IsLvCctoBUVisible { get; set; }
        public Visibility IsLvBUsVisible { get; set; }
        public Visibility IsLvVendorVisible { get; set; }
        public Visibility IsLvPagosVisible { get; set; }
        public List<TablasBD> ListaTablas { get; }
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
            ListaTablas = new List<TablasBD>(repositorioTablasBD.GetAll());

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

            IsLvUsuariosVisible = Visibility.Collapsed;
            IsLvBaseInstaladaVisible = Visibility.Collapsed;
            IsLvEndUserVisible = Visibility.Collapsed;
            IsLvCctoClienteVisible = Visibility.Collapsed;
            IsLvCctoBUVisible = Visibility.Collapsed;
            IsLvBUsVisible = Visibility.Collapsed;
            IsLvVendorVisible = Visibility.Collapsed;
            IsLvPagosVisible = Visibility.Collapsed;
        }


        private async void LoadData(string tablaAMostrar)
        {
            IsLvUsuariosVisible = Visibility.Collapsed;
            IsLvBaseInstaladaVisible = Visibility.Collapsed;
            IsLvEndUserVisible = Visibility.Collapsed;
            IsLvCctoClienteVisible = Visibility.Collapsed;
            IsLvCctoBUVisible = Visibility.Collapsed;
            IsLvBUsVisible = Visibility.Collapsed;
            IsLvVendorVisible = Visibility.Collapsed;
            IsLvPagosVisible = Visibility.Collapsed;

            switch (tablaAMostrar)
            {
                case "Usuario":
                    IsLvUsuariosVisible = Visibility.Visible;
                    var usuarios = await _repoUsuario.GetAllAsync();
                    ListUsuarios.Clear();
                    ListUsuarios.AddRange(usuarios);
                    break;
                case "BaseInstalada":
                    IsLvBaseInstaladaVisible = Visibility.Visible;
                    var bis = await _repoBaseInstalada.GetAllAsync();
                    ListBaseInstalada.Clear();
                    ListBaseInstalada.AddRange(bis);
                    break;
                case "BU":
                    IsLvBUsVisible = Visibility.Visible;
                    var bus = await _repoBU.GetAllAsync();
                    ListBUs.Clear();
                    ListBUs.AddRange(bus);
                    break;
                case "ContactoCliente":
                    IsLvCctoClienteVisible = Visibility.Visible;
                    var cctocls = await _repoCctoCliente.GetAllAsync();
                    ListCctoCliente.Clear();
                    ListCctoCliente.AddRange(cctocls);
                    break;
                case "ContactoBU":
                    IsLvCctoBUVisible = Visibility.Visible;
                    var cctobu = await _repoCctoBU.GetAllAsync();
                    ListCctoBU.Clear();
                    ListCctoBU.AddRange(cctobu);
                    break;
                case "EndUser":
                    IsLvEndUserVisible = Visibility.Visible;
                    var eus = await _repoEndUser.GetAllAsync();
                    ListEndUser.Clear();
                    ListEndUser.AddRange(eus);
                    break;
                case "Pago":
                    IsLvPagosVisible = Visibility.Visible;
                    var pagos = await _repoPago.GetAllAsync();
                    ListPago.Clear();
                    ListPago.AddRange(pagos);
                    break;
                case "Vendor":
                    IsLvVendorVisible = Visibility.Visible;
                    var vendors = await _repoVendor.GetAllAsync();
                    ListVendor.Clear();
                    ListVendor.AddRange(vendors);
                    break;
                default:
                    MessageBox.Show("");
                    break;
            }

            RaisePropertyChanged(nameof(IsLvUsuariosVisible));
            RaisePropertyChanged(nameof(IsLvVendorVisible));
            RaisePropertyChanged(nameof(IsLvPagosVisible));
            RaisePropertyChanged(nameof(IsLvEndUserVisible));
            RaisePropertyChanged(nameof(IsLvCctoClienteVisible));
            RaisePropertyChanged(nameof(IsLvBUsVisible));
            RaisePropertyChanged(nameof(IsLvBaseInstaladaVisible));
            RaisePropertyChanged(nameof(IsLvCctoBUVisible));
            RaisePropertyChanged(nameof(ListUsuarios));
            RaisePropertyChanged(nameof(ListBaseInstalada));
            RaisePropertyChanged(nameof(ListBUs));
            RaisePropertyChanged(nameof(ListCctoCliente));
            RaisePropertyChanged(nameof(ListCctoBU));
            RaisePropertyChanged(nameof(ListEndUser));
            RaisePropertyChanged(nameof(ListPago));
            RaisePropertyChanged(nameof(ListVendor));
        }

        private void FilterData(string buscador, string tablaAMostrar)
        {
            switch (tablaAMostrar)
            {
                case "Usuario":
                    ListUsuarios.Where(x => x.Apellidos.Contains(buscador)).ToList();
                    break;
                case "BaseInstalada":
                    break;
                case "BU":
                    ListBUs.Where(x => x.Acronimo.Contains(buscador)).ToList();
                    break;
                case "ContactoCliente":

                    break;
                case "ContactoBU":
                   
                    break;
                case "EndUser":
                  
                    break;
                case "Pago":

                    break;
                case "Vendor":
      
                    break;
                default:

                    break;
            }

            RaisePropertyChanged(nameof(ListUsuarios));
            RaisePropertyChanged(nameof(ListBaseInstalada));
            RaisePropertyChanged(nameof(ListBUs));
            RaisePropertyChanged(nameof(ListCctoCliente));
            RaisePropertyChanged(nameof(ListCctoBU));
            RaisePropertyChanged(nameof(ListEndUser));
            RaisePropertyChanged(nameof(ListPago));
            RaisePropertyChanged(nameof(ListVendor));
        }



        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //Seleccion = (TablasBD)navigationContext.Parameters["AMostrar"];
            //Buscador = (string)navigationContext.Parameters["Filtro"];
            //RaisePropertyChanged(nameof(Seleccion));
            //RaisePropertyChanged(nameof(Buscador));
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //
        }

    }
}

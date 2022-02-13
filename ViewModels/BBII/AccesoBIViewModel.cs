using Data.Interfaces;
using Model;
using Model.ReadModel;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace HCHLView.ViewModels.BBII
{
    public class AccesoBIViewModel : BindableBase, INavigationAware
    {
        private AccesoBIModel _equipoSelecionado;
        public AccesoBIModel EquipoSeleccionado
        {
            get
            {
                return _equipoSelecionado;
            }

            set
            {
                DetallesEquipoSeleccionado = Visibility.Collapsed;
                if (value != null)
                    SetProperty(ref _equipoSelecionado, value);
                DetallesEquipoSeleccionado = Visibility.Visible;

                RaisePropertyChanged(nameof(EquipoSeleccionado));
                RaisePropertyChanged(nameof(DetallesEquipoSeleccionado));
            }
        }

        private ObservableCollection<AccesoBIModel> _listaBaseInstalada;

        public ObservableCollection<AccesoBIModel> ListaBaseInstalada
        {
            get
            {
                return _listaBaseInstalada;
            }
            set
            {
                SetProperty(ref _listaBaseInstalada, value);
            }
        }
        public ObservableCollection<BaseInstalada> Equipos { get; private set; }
        public ObservableCollection<EndUser> EndUsers { get; private set; }
        public ObservableCollection<Proceso> Procesos { get; private set; }
        public ObservableCollection<Mercado> Mercados { get; private set; }
        public ObservableCollection<EquiposCRM> EquiposCRM { get; private set; }
        public ObservableCollection<BU> BUs { get; private set; }
        public List<string> ListaPaises { get; private set; }
        public List<string> ListaProveedores { get; private set; }
        public List<string> ListaModelos { get; private set; }
        public List<string> ListaEquipos { get; private set; }
        public List<string> ListaMercados { get; private set; }
        public List<string> ListaIndustrias { get; private set; }
        public Visibility DetallesEquipoSeleccionado { get; set; }
        private readonly IRepositorioBase<EndUser> _repoEndUser;
        private readonly IRepositorioBase<BaseInstalada> _repoBaseInstalada;
        private readonly IRepositorioEquipos _repoEquipos;
        private readonly IRepositorioBase<Proceso> _repoProceso;
        private readonly IRepositorioBase<Mercado> _repoMercado;
        private readonly IRepositorioBase<EquiposCRM> _repoCRM;
        private readonly IRepositorioBase<BU> _repoBU;

        public AccesoBIViewModel(IRepositorioBase<BaseInstalada> repoBaseInstalada, IRepositorioBase<EndUser> repoEndUser, IRepositorioBase<Mercado> repoMercado,
            IRepositorioBase<Proceso> repoProceso, IRepositorioBase<BU> repoBU, IRepositorioEquipos repoEquipos, IRepositorioBase<EquiposCRM> repoCRM)
        {
            this._repoBaseInstalada = repoBaseInstalada;
            this._repoProceso = repoProceso;
            this._repoBU = repoBU;
            this._repoEndUser = repoEndUser;
            this._repoEquipos = repoEquipos;
            this._repoMercado = repoMercado;
            this._repoCRM = repoCRM;

            ListaBaseInstalada = new ObservableCollection<AccesoBIModel>();
            Equipos = new ObservableCollection<BaseInstalada>();
            EndUsers = new ObservableCollection<EndUser>();
            Procesos = new ObservableCollection<Proceso>();
            Mercados = new ObservableCollection<Mercado>();
            EquiposCRM = new ObservableCollection<EquiposCRM>();
            BUs = new ObservableCollection<BU>();

            DetallesEquipoSeleccionado = Visibility.Collapsed;

            CargarInfoAsync();
            
        }

        
        private async void CargarInfoAsync()
        {
            var equipos = await _repoBaseInstalada.GetAllAsync();
            Equipos.Clear();
            Equipos.AddRange(equipos);

            var endusers = await _repoEndUser.GetAllAsync();
            EndUsers.Clear();
            EndUsers.AddRange(endusers);

            var procesos = await _repoProceso.GetAllAsync();
            Procesos.Clear();
            Procesos.AddRange(procesos);

            var mercados = await _repoMercado.GetAllAsync();
            Mercados.Clear();
            Mercados.AddRange(mercados);

            var crm = await _repoCRM.GetAllAsync();
            EquiposCRM.Clear();
            EquiposCRM.AddRange(crm);

            var bus = await _repoBU.GetAllAsync();
            BUs.Clear();
            BUs.AddRange(bus);

            CrearListaBaseInstalada();
            Agrupar();
            CargarCombobox();
        }

        private void CrearListaBaseInstalada()
        {
            var joinList = from equipo in Equipos
                           join enduser in EndUsers on equipo.IdEU equals enduser.Id into eu
                           from enduseri in eu.DefaultIfEmpty()
                           join proveedor in BUs on equipo.IdBU equals proveedor.Id into prov
                           from proveedori in prov.DefaultIfEmpty()
                           join mercado in Mercados on equipo.IdSubIndustria equals mercado.Id into merc
                           from mercadoi in merc.DefaultIfEmpty()
                           join proceso in Procesos on equipo.IdProceso equals proceso.Id into pro
                           from procesoi in pro.DefaultIfEmpty()
                           join eqcrm in EquiposCRM on equipo.IdEquiposCRM equals eqcrm.Id into ecrm
                           from crmi in ecrm.DefaultIfEmpty()
                           select new AccesoBIModel
                           {
                               EndUser = enduseri,
                               Equipo = equipo,
                               Proveedor = proveedori,
                               Mercado = mercadoi,
                               Proceso = procesoi,
                               CRM = crmi,
                               Nombre = enduseri.Nombre,
                               Planta = enduseri.Planta,
                               NSerie = equipo.NSerie,
                               Modelo = equipo.Modelo
                           };

            ListaBaseInstalada.Clear();
            ListaBaseInstalada.AddRange(joinList);

            RaisePropertyChanged(nameof(ListaBaseInstalada));
        }

        private void CargarCombobox()
        {
            ListaPaises = _listaBaseInstalada.Select(x => x.EndUser.Pais).Distinct().OrderBy(x => x).ToList();
            ListaProveedores = _listaBaseInstalada.Select(x => x.Proveedor.Acronimo).Distinct().OrderBy(x => x).ToList();
            ListaModelos = _listaBaseInstalada.Select(x => x.Equipo.Modelo).Distinct().OrderBy(x => x).ToList();
            ListaEquipos = _listaBaseInstalada.Select(x => x.CRM.Producto).Distinct().OrderBy(x => x).ToList();
            ListaMercados = _listaBaseInstalada.Where(m => m.Mercado != null).Select(x => x.Mercado.Segmento).Distinct().OrderBy(x => x).ToList();
            ListaIndustrias = _listaBaseInstalada.Where(m => m.Mercado != null).Select(x => x.Mercado.Referencia).Distinct().OrderBy(x => x).ToList();

            RaisePropertyChanged(nameof(ListaPaises));
            RaisePropertyChanged(nameof(ListaProveedores));
            RaisePropertyChanged(nameof(ListaEquipos));
            RaisePropertyChanged(nameof(ListaModelos));
            RaisePropertyChanged(nameof(ListaMercados));
            RaisePropertyChanged(nameof(ListaIndustrias));
        }

        private void Agrupar()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(ListaBaseInstalada);
            PropertyGroupDescription groupDescriptiona = new PropertyGroupDescription("Nombre");
            view.GroupDescriptions.Add(groupDescriptiona);
            PropertyGroupDescription groupDescriptionb = new PropertyGroupDescription("PlantaDisplay");
            view.GroupDescriptions.Add(groupDescriptionb);
            view.SortDescriptions.Add(new SortDescription("Nombre", ListSortDirection.Ascending));
            view.SortDescriptions.Add(new SortDescription("NSerie", ListSortDirection.Ascending));
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }
    }
}

using Data.Interfaces;
using Model;
using Model.ReadModel;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Linq;
using System.Collections.Generic;

namespace HCHLView.ViewModels.BBII
{
    public class AccesoBIViewModel : BindableBase, INavigationAware
    {
        public IEnumerable<AccesoBIModel> ListaBaseInstalada { get; private set; }
        public ObservableCollection<BaseInstalada> Equipos { get; private set; }
        public ObservableCollection<EndUser> EndUsers { get; private set; }
        public ObservableCollection<Proceso> Procesos { get; private set; }
        public ObservableCollection<BU> BUs { get; private set; }
        private readonly IRepositorioBase<EndUser> _repoEndUser;
        private readonly IRepositorioBase<BaseInstalada> _repoBaseInstalada;
        private readonly IRepositorioBase<Proceso> _repoProceso;
        private readonly IRepositorioBase<BU> _repoBU;

        public AccesoBIViewModel(IRepositorioBase<BaseInstalada> repoBaseInstalada, IRepositorioBase<EndUser> repoEndUser,
            IRepositorioBase<Proceso> repoProceso, IRepositorioBase<BU> repoBU)
        {
            this._repoBaseInstalada = repoBaseInstalada;
            this._repoProceso = repoProceso;
            this._repoBU = repoBU;
            this._repoEndUser = repoEndUser;

            Equipos = new ObservableCollection<BaseInstalada>();
            EndUsers = new ObservableCollection<EndUser>();
            Procesos = new ObservableCollection<Proceso>();
            BUs = new ObservableCollection<BU>();

            CargarInfoAsync();
        }

        private AccesoBIModel _equipoSelecionado;
        public AccesoBIModel EquipoSeleccionado
        {
            get
            {
                return _equipoSelecionado;
            }

            set
            {
                if (value != null)
                    _equipoSelecionado = value;

                RaisePropertyChanged(nameof(EquipoSeleccionado));
            }
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

            var bus = await _repoBU.GetAllAsync();
            BUs.Clear();
            BUs.AddRange(bus);

            ListaBaseInstalada = from equipo in Equipos
                                 join enduser in EndUsers on equipo.IdEU equals enduser.Id
                                 join proveedor in BUs on equipo.IdBU equals proveedor.Id
                                 join proceso in Procesos on equipo.IdSubIndustria equals proceso.Id
                                 select new AccesoBIModel
                                 {
                                     EndUser = enduser,
                                     Equipo = equipo,
                                     Proveedor = proveedor,
                                     Proceso = proceso,
                                     Nombre = enduser.Nombre,
                                     Planta = enduser.Planta,
                                     NSerie = equipo.NSerie,
                                     Modelo = equipo.Modelo
                                 };

            Agrupar();
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

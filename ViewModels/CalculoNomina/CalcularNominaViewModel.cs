using Data;
using Model;
using Model.ReadModel;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace HCHLView.ViewModels.CalculoNomina
{
    class CalcularNominaViewModel : BindableBase, INavigationAware
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
            }
        }

        public string Buscador { get; set; }
        public ObservableCollection<TablasBD> ListaOpciones { get; }
        public ObservableCollection<Usuario> List { get; private set; }

        public CalcularNominaViewModel(IRepositorioBase<Usuario> repoUsuario, RepositorioTablasBD repositorioTablasBD)
        {
            List = new ObservableCollection<Usuario>();
            ListaOpciones = new ObservableCollection<TablasBD>(repositorioTablasBD.GetAll());

            LoadUsers(repoUsuario);
        }

        private async void LoadUsers(IRepositorioBase<Usuario> repoUsuario)
        {
            var usuarios = await repoUsuario.GetAllAsync();

            List.AddRange(usuarios);
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
    }
}

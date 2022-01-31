using Data.Interfaces;
using Model;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace HCHLView.ViewModels.BBII
{
    public class AccesoBIViewModel : ViewModelBase, INavigationAware
    {
        public ObservableCollection<BaseInstalada> ListaEquiposInstalados { get; private set; }
        private readonly IRepositorioBase<BaseInstalada> _repoBaseInstalada;

        public AccesoBIViewModel(IRepositorioBase<BaseInstalada> repoBaseInstalada)
        {

            this._repoBaseInstalada = repoBaseInstalada;
        
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

using HCHLView.Views.BBDD;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace HCHLView.ViewModels
{
    public class MenuInicioViewModel : BindableBase
    {
        public Visibility Hide { get; set; }
        public DelegateCommand Navigate { get; private set; }

        private readonly IRegionManager regionManager;

        public MenuInicioViewModel(IRegionManager regionManager)
        {
            Hide = Visibility.Visible;
            this.regionManager = regionManager;

            Navigate = new DelegateCommand(NavigateMethod);
        }

        private void NavigateMethod()
        {
            regionManager.RequestNavigate("ContentRegion", nameof(AccesoBD));

            Hide = Visibility.Collapsed;
            RaisePropertyChanged(nameof(Hide));
        }
    }
}

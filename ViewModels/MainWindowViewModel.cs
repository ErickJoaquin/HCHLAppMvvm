using Data.Repositorios;
using HCHLView.Views.Aplicacion;
using HCHLView.Views.BBDD;
using HCHLView.Views.BBII;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace HCHLView.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private bool _isAppSelected { get; set; }
        public bool IsAppSelected
        {
            get
            {
                return _isAppSelected;
            }

            set
            {
                _isAppSelected = value;
                if (_isAppSelected)
                {
                    IsBIVisible = Visibility.Collapsed;
                    IsBDVisible = Visibility.Collapsed;
                    IsSpAplicacionVisible = Visibility.Visible;
                    IsBorderVisible = Visibility.Visible;

                    TbAppContent = "Ingeniería de Aplicación";
                }
                else
                {
                    IsBIVisible = Visibility.Visible;
                    IsBDVisible = Visibility.Visible;
                    IsSpAplicacionVisible = Visibility.Collapsed;
                    IsBorderVisible = Visibility.Collapsed;

                    TbAppContent = "Aplicación";
                }

                RaisePropertyChanged(nameof(IsBIVisible));
                RaisePropertyChanged(nameof(IsBDVisible));
                RaisePropertyChanged(nameof(IsSpAplicacionVisible));
                RaisePropertyChanged(nameof(IsBorderVisible));
                RaisePropertyChanged(nameof(TbAppContent));
            }
        }

        private bool _isBISelected { get; set; }
        public bool IsBISelected
        {
            get
            {
                return _isBISelected;
            }

            set
            {
                _isBISelected = value;
                if (_isBISelected)
                {
                    IsAppVisible = Visibility.Collapsed;
                    IsBDVisible = Visibility.Collapsed;
                }
                else
                {
                    IsAppVisible = Visibility.Visible;
                    IsBDVisible = Visibility.Visible;
                }

                RaisePropertyChanged(nameof(IsAppVisible));
                RaisePropertyChanged(nameof(IsBDVisible));
            }
        }

        private bool _isBDSelected { get; set; }
        public bool IsBDSelected
        {
            get
            {
                return _isBDSelected;
            }

            set
            {
                _isBDSelected = value;
                if (_isBDSelected)
                {
                    IsAppVisible = Visibility.Collapsed;
                    IsBIVisible = Visibility.Collapsed;
                }
                else
                {
                    IsAppVisible = Visibility.Visible;
                    IsBIVisible = Visibility.Visible;
                }

                RaisePropertyChanged(nameof(IsAppVisible));
                RaisePropertyChanged(nameof(IsBIVisible));
            }
        }

        private bool _isDMOfertasSelected { get; set; }
        public bool IsDMOfertasSelected
        {
            get
            {
                return _isDMOfertasSelected;
            }

            set
            {
                _isDMOfertasSelected = value;
                if (_isDMOfertasSelected)
                {
                    IsSpInicioVisible = Visibility.Collapsed;
                    IsBorderVisible = Visibility.Collapsed;
                }
                else
                {
                    IsSpInicioVisible = Visibility.Visible;
                    IsBorderVisible = Visibility.Visible;
                }

                RaisePropertyChanged(nameof(IsSpInicioVisible));
                RaisePropertyChanged(nameof(IsBorderVisible));
            }
        }

        public string Buscador { get; set; }
        public Visibility IsSpInicioVisible { get; set; }
        public Visibility IsSpAplicacionVisible { get; set; }
        public Visibility IsGvBDVisible { get; set; }
        public Visibility IsBorderVisible { get; set; }
        public Visibility IsBIVisible { get; set; }
        public Visibility IsAppVisible { get; set; }
        public Visibility IsBDVisible { get; set; }
        public string TbAppContent { get; set; }
        public DelegateCommand NavigateAccesoBD { get; private set; }
        public DelegateCommand NavigateAccesoBI { get; private set; }
        public DelegateCommand NavigateDMOfertas { get; private set; }

        private readonly IRegionManager regionManager;

        public MainWindowViewModel(IRegionManager regionManager, RepositorioTablasBD repositorioTablasBD)
        {
            IsBIVisible = Visibility.Visible;
            IsAppVisible = Visibility.Visible;
            IsBDVisible = Visibility.Visible;
            IsSpAplicacionVisible = Visibility.Collapsed;
            IsGvBDVisible = Visibility.Collapsed;
            IsBorderVisible = Visibility.Collapsed;
            TbAppContent = "Aplicación";

            this.regionManager = regionManager;

            NavigateAccesoBD = new DelegateCommand(NavigateAccesoBDMethod);
            NavigateAccesoBI = new DelegateCommand(NavigateAccesoBIMethod);
            NavigateDMOfertas = new DelegateCommand(NavigateDMOfertasMethod);
        }

        private void NavigateDMOfertasMethod()
        {
            regionManager.RequestNavigate("ContentRegion", nameof(DMOfertasView));

            RaisePropertyChanged(nameof(IsDMOfertasSelected));
        }

        private void NavigateAccesoBDMethod()
        {
            regionManager.RequestNavigate("ContentRegion", nameof(AccesoBDView));

            RaisePropertyChanged(nameof(IsBDSelected));
        }

        private void NavigateAccesoBIMethod()
        {
            regionManager.RequestNavigate("ContentRegion", nameof(AccesoBIView));

            RaisePropertyChanged(nameof(IsBISelected));
        }

    }
}

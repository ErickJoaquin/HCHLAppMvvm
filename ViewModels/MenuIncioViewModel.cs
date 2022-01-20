using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCHLView.ViewModels
{
    public class MenuIncioViewModel : BindableBase, INavigationAware
    {
        public MenuIncioViewModel()
        {
            IsAplicacionSelected = false;
        }

        private bool _isAplicacionSelected;
        public bool IsAplicacionSelected
        {
            get
            {
                return _isAplicacionSelected;
            }

            set
            {
                    _isAplicacionSelected = value;
            }
        }

        private Visibility _SpAplicacionVisibility;

        public Visibility SpAplicacionVisibility
        {
            get
            {
                return _SpAplicacionVisibility;
            }

            set
            {
                _SpAplicacionVisibility =  _isAplicacionSelected ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        private bool _isBIEnable;

        public bool IsBIEnable
        {
            get
            {
                return _isBIEnable;
            }

            set
            {
                _isBIEnable = !_isAplicacionSelected;
            }
        }

        private bool _isBDEnable;

        public bool IsBDEnable
        {
            get
            {
                return _isBDEnable;
            }

            set
            {
                _isBDEnable = !_isAplicacionSelected;
            }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }
    }
}

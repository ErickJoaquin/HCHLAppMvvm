using Prism.Mvvm;

namespace HCHLView.ViewModel
{
    class AccesoBDViewModel : BindableBase
    {
        private string _buscador;
        public string Buscador
        {
            get
            {
                return _buscador;
            }
            set
            {
                _buscador = value;
            }
        }

    }
}

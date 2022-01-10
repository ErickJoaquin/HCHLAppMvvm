using Prism.Mvvm;
using System.Collections.ObjectModel;
using Model.ReadModel;
using Data;
using System.Linq;
using Model;

namespace HCHLView.ViewModels
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

        private ObservableCollection<TablasBD> _listaOpciones;
        public ObservableCollection<TablasBD> ListaOpciones
        {
            get
            {
                RepositorioTablasBD repT = new RepositorioTablasBD();
                _listaOpciones = new ObservableCollection<TablasBD>(repT.GetAll());
                return _listaOpciones;
            }
        }

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

        private ObservableCollection<Usuario> _list;
        public ObservableCollection<Usuario> List
        {
            get
            {
                RepositorioBase<Usuario> repT = new RepositorioBase<Usuario>();
                _list = new ObservableCollection<Usuario>(repT.GetAllAsync().Result);
                return _list;
            }
        }
    }
}

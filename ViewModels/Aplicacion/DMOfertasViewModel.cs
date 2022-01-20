using System.Collections.ObjectModel;
using Model.ReadModel;
using Data.Repositorios;
using System.Windows;
using Prism.Mvvm;
using System.Collections.Generic;
using Prism.Regions;

namespace HCHLView.ViewModels.Aplicacion
{
    public class DMOfertasViewModel : BindableBase, INavigationAware
    {
        private readonly ObservableCollection<OfertaCompleta> ListaOfertas;
        private readonly RepositorioOferta _repOferta;

        public DMOfertasViewModel(RepositorioOferta repOferta)
        {
            ListaOfertas = new ObservableCollection<OfertaCompleta>();

            this._repOferta = repOferta;

            _seleccion = "Editando";
        }

        private string _seleccion;
        public string Seleccion
        {
            get
            {
                return _seleccion;
            }

            set
            {
                if (value != null)
                    _seleccion = value;
                    LoadData(_seleccion);
            }
        }

        private async void LoadData(string TablaAMostrar)
        {
            switch (TablaAMostrar)
            {
                case "Editando":
                    List<OfertaCompleta> ofertasEdicion = await _repOferta.GetAllAsync();
                    ListaOfertas.Clear();
                    ListaOfertas.AddRange(ofertasEdicion);
                    break;
                case "Enviadas":
                    var ofertas = await _repOferta.GetAllAsync();
                    ListaOfertas.Clear();
                    ListaOfertas.AddRange(ofertas);
                    break;
                case "Venta":
                case "Consolidando":
                    //var bis = await _repoBaseInstalada.GetAllAsync();
                    //ListBaseInstalada.AddRange(bis);
                    break;
                default:
                    MessageBox.Show("");
                    break;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}

using HCHLView.Views.BBDD;
using HCHLView.Views.Aplicacion;
using System.Windows;

namespace HCHLView.Views
{
    /// <summary>
    /// Lógica de interacción para MenuInicio.xaml
    /// </summary>
    public partial class MenuInicio : Window
    {
        public MenuInicio()
        {
            InitializeComponent();
        }

        private void BtBbii_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void BtBbdd_Click(object sender, RoutedEventArgs e)
        {
            Window wdw = new AccesoBD();
            wdw.Show();
            this.WindowState = WindowState.Minimized;
        }

        private void BtNueva_Click(object sender, RoutedEventArgs e)
        {
    
        }

        private void BtOfertas_Click(object sender, RoutedEventArgs e)
        {
            Window wdw = new DMOfertas();
            wdw.Show();
            this.WindowState = WindowState.Minimized;
        }

        private void BtCotizar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

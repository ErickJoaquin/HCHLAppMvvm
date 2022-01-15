using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HCHLView.Views
{
    /// <summary>
    /// Lógica de interacción para AccesoBD.xaml
    /// </summary>
    public partial class AccesoBD : Window
    {
        public AccesoBD()
        {
            InitializeComponent();
        }

        private void Cbx_SelectionChaned(object sender, SelectionChangedEventArgs e)
        {
            var cbx = sender as ComboBox; 
            var TablaAMostrar = cbx.SelectedValue.ToString(); 

            if (TablaAMostrar == "Usuario") { LvUsuarios.Visibility = Visibility.Visible; }
            else { LvUsuarios.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "BaseInstalada") { LvBaseInstalada.Visibility = Visibility.Visible; }
            else { LvBaseInstalada.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "BU") { LvBUs.Visibility = Visibility.Visible; }
            else { LvBUs.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "ContactoCliente") { LvCctoCliente.Visibility = Visibility.Visible; }
            else { LvCctoCliente.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "ContactoBU") { LvCctoBU.Visibility = Visibility.Visible; }
            else { LvCctoBU.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "EndUser") { LvEndUser.Visibility = Visibility.Visible; }
            else { LvEndUser.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "Pago") { LvPago.Visibility = Visibility.Visible; }
            else { LvPago.Visibility = Visibility.Collapsed; }

            if (TablaAMostrar == "Vendor") { LvVendor.Visibility = Visibility.Visible; }
            else { LvVendor.Visibility = Visibility.Collapsed; }
        }
    }
}

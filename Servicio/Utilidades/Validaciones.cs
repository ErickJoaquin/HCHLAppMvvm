using System.Windows.Forms;

namespace Servicios.Utilidades
{
    /// <summary>
    /// Validacion de input usuario
    /// </summary>
    public class Validaciones 
    {
        /// <summary>
        ///  Permite que solo ingresen numeros enteros, sin puntos ni decimales
        /// </summary>
        /// <param name="e"></param>
        public void soloInt(KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && 
                e.KeyCode <= Keys.D9) || 
                (e.KeyCode >= Keys.NumPad0 && 
                e.KeyCode <= Keys.NumPad9))
                e.Handled = false;
            else
                e.Handled = true;
        }

        /// <summary>
        /// Permite agregar doubles, con una "," como separador decimal
        /// </summary>
        /// <param name="e"></param>
        public void soloDouble(KeyEventArgs e)
        {
            if ((e.KeyCode >= Keys.D0 && 
                e.KeyCode <= Keys.D9) || 
                (e.KeyCode >= Keys.NumPad0 && 
                e.KeyCode <= Keys.NumPad9) || 
                e.KeyCode == Keys.OemPeriod ||
                e.KeyCode == Keys.Decimal ||
                e.KeyCode == Keys.Oemcomma)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}

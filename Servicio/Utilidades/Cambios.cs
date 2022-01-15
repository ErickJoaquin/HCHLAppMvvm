using Model;

namespace Servicios.Utilidades
{
    /// <summary>
    /// Clase para trabajar con conversiones de monedas
    /// </summary>
    public class Cambios
    {
        /// <summary>
        /// Convertir valor
        /// </summary>
        /// <param name="valor">Valor a convertir</param>
        /// <param name="currAntiguo">Moneda actual</param>
        /// <param name="currNuevo">Moneda a la que se quiere convertir</param>
        /// <param name="cambioAntiguo">Cambio moneda actual vs dolar</param>
        /// <param name="cambioNuevo">Cambio moneda nueva vs dolar</param>
        /// <returns></returns>
        public double Convertir(double valor, string currAntiguo, string currNuevo, double cambioAntiguo, double cambioNuevo)
        {
            if (currAntiguo != currNuevo)
            {
                if (currAntiguo == MonedasEnum.USD.ToString()) { valor = valor * cambioNuevo; }
                else
                {
                    if (currNuevo == MonedasEnum.USD.ToString()) {valor = valor / cambioAntiguo;  }
                    else { valor = valor * cambioNuevo / cambioAntiguo; }
                }
            }

            return valor;
        }

    }
}

using Model;
using System;
using Data;

namespace Servicios.Utilidades
{
    /// <summary>
    /// Clase para trabajar con conversiones de monedas
    /// </summary>
    public class Moneda
    {
        private readonly RepositorioBase<OfertaMonedas> _repOfMonedas;
        public Moneda(RepositorioBase<OfertaMonedas> repOfMonedas)
        {
            _repOfMonedas = repOfMonedas;
        }

        /// <summary>
        /// Convertir valor
        /// </summary>
        /// <param name="valueToConvert">Valor a convertir</param>
        /// <param name="oldCurrency">Moneda actual</param>
        /// <param name="newCurrency">Moneda a la que se quiere convertir</param>
        /// <param name="oldCurrencyToDolarValue">Cambio moneda actual a dolar</param>
        /// <param name="newCurrencyToDolarValue">Cambio moneda nueva a dolar</param>
        /// <returns></returns>
        public double Convert(double valueToConvert, string oldCurrency, string newCurrency, 
            double oldCurrencyToDolarValue = 0, double newCurrencyToDolarValue = 0)
        {
            double valueConverted;

            if(oldCurrencyToDolarValue == 0) { oldCurrencyToDolarValue = GetLast(oldCurrency); }
            if(newCurrencyToDolarValue == 0) { newCurrencyToDolarValue = GetLast(newCurrency); }

            if (oldCurrency != newCurrency)
            {
                valueConverted = ThenConvert(valueToConvert, oldCurrency, newCurrency, oldCurrencyToDolarValue, newCurrencyToDolarValue);
            }
            else
            {
                valueConverted = valueToConvert;
            }

            return valueConverted;
        }

        public double GetLast(string currency)
        {
            double currencyValue = 0;

            return currencyValue;
        }

        private double ThenConvert(double valueToConvert, string oldCurrency, string newCurrency,
            double oldCurrencyToDolarValue = 0, double newCurrencyToDolarValue = 0)
        {
            double valueConverted;

            if (oldCurrency == MonedasEnum.USD.ToString())
            {
                valueConverted = valueToConvert * newCurrencyToDolarValue;
            }
            else
            {
                if (newCurrency == MonedasEnum.USD.ToString())
                {
                    valueConverted = valueToConvert / oldCurrencyToDolarValue;
                }
                else
                {
                    valueConverted = valueToConvert * newCurrencyToDolarValue / oldCurrencyToDolarValue;
                }
            }

            return valueConverted;
        }
    }
}

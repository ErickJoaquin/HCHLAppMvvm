using System.Collections.Generic;
using Model;

namespace Servicios.Correos.EnvioOferta.Utilidades
{
    public class Vendedores
    {             
        public string Agregar(Oferta Oferta, string body, List<Usuario> vendedoresOferta)
        {
            int count = 0;
            foreach(Persona vendedor in vendedoresOferta)
            {
                body += $"<b> {vendedor.NombreCompleto}:</b> {vendedor.Telefono} / {vendedor.Celular} - {vendedor.Mail}.<br/>";
                count++;
            }
            
            if(count < 2)
            {
                body +=  "<b> Edson Luis Geraldini:</b> +55 11 4487 6252 / +55 11 98193 6392 - edson.geraldini@howden.com.<br/>";
            }
            
            body += "<br/>"; 

            return body;
        }
    }
}

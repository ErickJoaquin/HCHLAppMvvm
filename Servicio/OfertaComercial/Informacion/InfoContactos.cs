using System.Collections.Generic;
using System.Linq;
using Model;
using Data;
using Word = Microsoft.Office.Interop.Word;
using Servicios.OfertaComercial.Utilidades;

namespace Servicios.OfertaComercial.Informacion
{
    public class InfoContactos
    {
        private readonly ReemplazarEnWord _reemplazar;
        private readonly RepositorioPorOferta<Mercado> _repMer;
        public InfoContactos(RepositorioPorOferta<Mercado> repMer, ReemplazarEnWord reemplazar)
        {
            this._repMer = repMer;
            this._reemplazar = reemplazar;
        }

        public void Agregar(Oferta Oferta, List<Usuario> Usuarios, Word.Document docof)
        {;
            Mercado Mercado = _repMer.GetByOfferIdAsync(Oferta.Id).Result;

            List<Usuario> ListaVendedor = new List<Usuario>();
            ListaVendedor.Add(Usuarios.Where(n => n.Id.Equals(Mercado.IdVendedor1)).FirstOrDefault());
            ListaVendedor.Add(Usuarios.Where(n => n.Id.Equals(Mercado.IdVendedor2)).FirstOrDefault());
            ListaVendedor.Add(Usuarios.Where(n => n.Id.Equals(Mercado.IdVendedor3)).FirstOrDefault());
            ListaVendedor.Add(Usuarios.Where(n => n.Id.Equals(Mercado.IdKA)).FirstOrDefault());
            ListaVendedor.Add(Usuarios.Where(n => n.Id.Equals(Mercado.IdKAM)).FirstOrDefault());

            if(ListaVendedor.Count() <= 0) { return; }
            
            int uso = 0;
            foreach(Usuario ccto in ListaVendedor)
            {
                uso++;
                while (uso < 4)
                {
                    _reemplazar.Vendedores(uso, ccto, docof);
                }
            }

            Usuario Edson = ListaVendedor.Where(n => n.Apellidos.Equals("Geraldini")).ElementAt(0);
            ajustarTabla(Edson, docof, uso);
        }


        protected void ajustarTabla(Usuario Edson, Word.Document docof, int uso)
        {
            if (uso == 0)
            {
                _reemplazar.Vendedores(1, Edson, docof);
                docof.Tables[2].Columns[2].Delete();
                docof.Tables[2].Columns[2].Delete();
            }
            if (uso == 1)
            {
                _reemplazar.Vendedores(3, Edson, docof);
                docof.Tables[2].Columns[2].Delete();
            }
            if (uso == 2)
            {
                _reemplazar.Vendedores(3, Edson, docof);
            }
            docof.Tables[2].Columns.AutoFit();
        }
    }
}

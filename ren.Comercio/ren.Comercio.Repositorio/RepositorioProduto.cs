using ren.Comercio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ren.Comercio.Repositorio
{
    public class RepositorioProduto : RepositorioGenerico<Produto>
    {

        public override void Adicionar(Produto objeto)
        {
            var marcaOriginal = contexto.Set<Marca>().Find(objeto.marca.codigo);
            objeto.marca = marcaOriginal;
            contexto.Set<Produto>().Add(objeto);
            contexto.SaveChanges();
        }
    }
}

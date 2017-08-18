using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ren.Comercio.Model;
using System.Data.Entity;

namespace ren.Comercio.Repositorio
{
    public class RepositorioPadrao
    {

        Contexto contexto;

        public RepositorioPadrao() {
            contexto = new Contexto();
        }

        public void Adicionar(Marca marca) {
            contexto.Set<Marca>().Add(marca);
            contexto.SaveChanges();
        }

        public void Atualizar(Marca marca) {
            var origem = contexto.Set<Marca>().Find(marca.codigo);
            contexto.Entry(origem).CurrentValues.SetValues(marca);
            contexto.SaveChanges();
        }

        public void Excluir(Marca marca) {   
                var origem = contexto.Set<Marca>().Find(marca.codigo);
                contexto.Set<Marca>().Remove(origem);
                contexto.SaveChanges();
        }

        public List<Marca> Listar() {

            return contexto.Set<Marca>().ToList();
        }
    }
}

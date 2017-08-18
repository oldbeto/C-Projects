using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ren.Comercio.Model;

namespace ren.Comercio.Repositorio
{
    public abstract class RepositorioGenerico<T> where T : ClasseGenerica
    {
        Contexto contexto;

        public RepositorioGenerico()
        {
            contexto = new Contexto();
        }

        public void Adicionar(T objeto)
        {
            contexto.Set<T>().Add(objeto);
            contexto.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            var origem = contexto.Set<T>().Find(objeto.codigo);
            contexto.Entry(origem).CurrentValues.SetValues(objeto);
            contexto.SaveChanges();
        }

        public void Excluir(T objeto)
        {
            var origem = contexto.Set<T>().Find(objeto.codigo);
            contexto.Set<T>().Remove(origem);

            contexto.SaveChanges();
        }

        public List<T> Listar()
        {
            return contexto.Set<T>().ToList();
        }
    }
}

using ren.Comercio.Model;
using System.Data.Entity;

namespace ren.Comercio.Repositorio
{


    public class Contexto: DbContext
    {

        public Contexto() : base("DefaultConnection") { }



        public DbSet<Marca> Marca { get; set; }

    }
}

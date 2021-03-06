﻿using ren.Comercio.Model;
using System.Data.Entity;

namespace ren.Comercio.Repositorio
{
    public class Contexto: DbContext
    {
        public Contexto() : base("DefaultConnection") { }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }

    }
}

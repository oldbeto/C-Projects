using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ren.Comercio.Model
{
    public class Usuario : ClasseGenerica
    {
        public String nome { get; set; }

        public bool administrador { get; set; }

        public bool clientes { get; set; }

        public bool vendas { get; set; }

        public bool fornecedores { get; set; }

        public bool compras { get; set; }

    }
}

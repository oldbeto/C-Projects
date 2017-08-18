using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ren.Comercio.Model
{
    public class Produto
    {
        [Key]
        public int codigo { get; set; }

        public string nome { get; set; }

        public decimal valorCompra { get; set; }

        public decimal valorVenda { get; set; }

        public int qtdEstoque { get; set; }

        public int qtdMinimaEstoque { get; set; }

        public Marca marca { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ren.Comercio.Model
{
     public class Marca
    {
        [Key]
        public int codigo { get; set; }
        public string nome { get; set; }
    }
}

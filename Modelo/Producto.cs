using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Modelo
{
    public class Producto
    {

        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal mrp { get; set; }
        public int stock { get; set; }
        public int isPublished { get; set; }
    }
}

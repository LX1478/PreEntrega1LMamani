using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega1
{
    internal class Producto
    {
        private long Id;
        private string Descripciones;
        private decimal Costo;
        private decimal PrecioVenta;
        private int Stock;
        private long IdUsuario;

        public long Id1 { get => Id; set => Id = value; }
        public string Descripciones1 { get => Descripciones; set => Descripciones = value; }
        public decimal Costo1 { get => Costo; set => Costo = value; }
        public decimal PrecioVenta1 { get => PrecioVenta; set => PrecioVenta = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public long IdUsuario1 { get => IdUsuario; set => IdUsuario = value; }
    }
}

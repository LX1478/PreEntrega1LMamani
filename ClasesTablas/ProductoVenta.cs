using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preentrega1
{
    internal class ProductoVenta
    {
        private long Id;
        private int Stock;
        private long IdProducto;
        private long IdVenta;

        public long Id1 { get => Id; set => Id = value; }
        public int Stock1 { get => Stock; set => Stock = value; }
        public long IdProducto1 { get => IdProducto; set => IdProducto = value; }
        public long IdVenta1 { get => IdVenta; set => IdVenta = value; }
    }
}

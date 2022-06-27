using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.Common.DTO
{
    public class ProductoDTO
    {
        public string CodigoProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string EstadoProducto { get; set; }
        public string FechaFabricacionProducto { get; set; }
        public string FechaValidezProducto { get; set; }
        public string CodigoProveedor { get; set; }
        public string DescripcionProveedor { get; set; }
        public string TelefonoProveedor { get; set; }

    }
}

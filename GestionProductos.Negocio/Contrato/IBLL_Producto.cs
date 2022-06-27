
using GestionProductos.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.Negocio.Contratos
{
    public interface IBLL_Producto
    {

        IList<ProductoDTO> ConsultarProductos();

        ProductoDTO TraerProductoXCodigo(ProductoDTO producto);

        ProductoDTO InsertarProducto(ProductoDTO producto);

        ProductoDTO ModificarProducto(ProductoDTO producto);

        ProductoDTO BorrarProducto(ProductoDTO producto);

    }

}

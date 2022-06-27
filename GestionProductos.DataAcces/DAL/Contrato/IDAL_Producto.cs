
using GestionProductos.Common.DTO;
using GestionProductos.DataAcess.ConexionSQL.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.DataAcess.DAL.Contrato
{
    
    public interface IDAL_Producto
    {

        DataTable ConsultarProductos();

        DataTable TraerProductoXCodigo(String CodigoProducto);

        DataTable InsertarProducto(ProductoDTO producto);

        DataTable ModificarProducto(ProductoDTO producto);

        DataTable BorrarProducto(ProductoDTO producto);

    }
}

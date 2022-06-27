
using GestionProductos.Common.DTO;
using GestionProductos.DataAcces.ConexionSQL.Implementacion;
using GestionProductos.DataAcess.DAL.Contrato;
using System;
using System.Data;

namespace GestionProductosAPI.DataAcess.DAL.Implementacion
{
    public class DAL_Producto : META_DAL, IDAL_Producto
    {
        public DAL_Producto(CadenaDTO credenciales)
        {
            this._Conexion = new ConexionServer(credenciales);
        }


        public DataTable TraerProductoXCodigo(String CodigoProducto)
        {
            try
            {
                string sql = @"select * from dbo.Producto where codigo_producto=" + CodigoProducto + ";";

                DataTable vDataTable = this._Conexion.Consultar(sql);
                return vDataTable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ConsultarProductos()
        {
            try
            {
                string sql = @"select * from dbo.Producto";

                DataTable vDataTable = this._Conexion.Consultar(sql);

                return vDataTable;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DataTable InsertarProducto(ProductoDTO producto)
        {
            try
            {
                string sql = @"Insert into dbo.Producto (descripcion_producto,estado_producto,fecha_fabricacion_producto,
                 fecha_validez_producto,codigo_proveedor,descripcion_proveedor,telefono_proveedor)
                 values('" + producto.DescripcionProducto + "','" + producto.EstadoProducto + "','" + Convert.ToDateTime(producto.FechaFabricacionProducto) + "','" + Convert.ToDateTime(producto.FechaValidezProducto) + "','" + producto.CodigoProveedor + "','" + producto.DescripcionProveedor + "','" + producto.TelefonoProveedor + "')";

                DataTable data = this._Conexion.Consultar(sql);

                return data;

            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        public DataTable ModificarProducto(ProductoDTO producto)
        {
            try
            {
                string sql = @"update dbo.Producto 
                                 set descripcion_producto = '" + producto.DescripcionProducto + "'," +
                             " estado_producto = '" + producto.EstadoProducto + "'," +
                             "fecha_fabricacion_producto = '" + Convert.ToDateTime(producto.FechaFabricacionProducto) + "'," +
                             "fecha_validez_producto = '" + Convert.ToDateTime(producto.FechaValidezProducto) + "'," +
                             "codigo_proveedor = '" + producto.CodigoProveedor + "'," +
                             "descripcion_proveedor = '" + producto.DescripcionProveedor + "'," +
                             "telefono_proveedor = '" + producto.TelefonoProveedor + "' where codigo_producto = " + producto.CodigoProducto + ";";

                DataTable data = this._Conexion.Consultar(sql);
                return data;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable BorrarProducto(ProductoDTO producto)
        {
            try
            {
                string sql = @"update dbo.Producto 
                            set estado_producto = 'I' where codigo_producto = " + producto.CodigoProducto + ";";

                DataTable data=this._Conexion.Consultar(sql);
                return data;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }   
}

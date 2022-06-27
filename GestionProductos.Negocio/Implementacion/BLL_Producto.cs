
using GestionProductos.Common.DTO;
using GestionProductos.DataAcess.DAL.Contrato;
using GestionProductos.Negocio.Contratos;
using GestionProductosAPI.DataAcess.DAL.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;

namespace GestionProductos.Negocio.Implementacion
{
    public class BLL_Producto : IBLL_Producto
    {
        /// <summary>
        /// Atributo de DAL
        /// </summary>
        private IDAL_Producto _DAL;

        /// <summary>
        /// Constructor del Usuario
        /// </summary>
        /// <param name="credenciales">Credenciales de conexión</param>
        public BLL_Producto(CadenaDTO credenciales)
        {
            _DAL = new DAL_Producto(credenciales);
        }

        
        public IList<ProductoDTO> ConsultarProductos()
        {
            try
            {
                IList<ProductoDTO> vRetorno = new List<ProductoDTO>();
                DataTable vDR = _DAL.ConsultarProductos();
                if (vDR == null)
                {
                    return vRetorno;
                }

                foreach (DataRow itemRow in vDR.Rows)
                {

                    ProductoDTO vItem = new ProductoDTO();

                    vItem.CodigoProducto = itemRow[0].ToString();
                    vItem.DescripcionProducto = itemRow[1].ToString();
                    vItem.EstadoProducto = itemRow[2].ToString();
                    vItem.FechaFabricacionProducto = itemRow[3].ToString();
                    vItem.FechaValidezProducto = itemRow[4].ToString();
                    vItem.CodigoProveedor = itemRow[5].ToString();
                    vItem.DescripcionProveedor = itemRow[6].ToString();
                    vItem.TelefonoProveedor = itemRow[7].ToString();

                    vRetorno.Add(vItem);

                }
                return vRetorno;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ProductoDTO TraerProductoXCodigo(ProductoDTO producto)
        {
            try
            {
                ProductoDTO vRetorno = new ProductoDTO();
                DataTable dt = _DAL.TraerProductoXCodigo(producto.CodigoProducto);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        vRetorno.CodigoProducto = dr[0].ToString();
                        vRetorno.DescripcionProducto = dr[1].ToString();
                        vRetorno.EstadoProducto = dr[2].ToString();
                        vRetorno.FechaFabricacionProducto= dr[3].ToString();
                        vRetorno.FechaValidezProducto = dr[4].ToString();
                        vRetorno.CodigoProveedor = dr[5].ToString();
                        vRetorno.DescripcionProveedor = dr[6].ToString();
                        vRetorno.TelefonoProveedor = dr[7].ToString();
                    }
                    return vRetorno;
                }
                else
                {
                    return vRetorno;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductoDTO InsertarProducto(ProductoDTO producto)
        {
            try
            {
                DataTable dt = _DAL.InsertarProducto(producto);
                return producto;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductoDTO ModificarProducto(ProductoDTO producto)
        {
            try
            {
                DataTable dt = _DAL.ModificarProducto(producto);
                return producto;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProductoDTO BorrarProducto(ProductoDTO producto)
        {
            try
            {
                DataTable dt = _DAL.BorrarProducto(producto);
                return producto;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

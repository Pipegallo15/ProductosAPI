using GestionAPI.Conexion;
using GestionAPI.Models;
using GestionProductos.Common.DTO;
using GestionProductos.Negocio.Contratos;
using GestionProductos.Negocio.Implementacion;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using static GestionProductos.Common.CommonConstants;

namespace GestionAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("productos")]
        public IActionResult ConsultarProductos()
        {
            try
            {
                CadenaDTO vCredencialesSql = ConexionFacade.getCredencialesSqlServer();
                IBLL_Producto vBLL_Producto = new BLL_Producto(vCredencialesSql);
                IList<ProductoDTO> vDatos = vBLL_Producto.ConsultarProductos();
                dynamic vRetPro = new RespuestaDTO() { IsOk = ConstantesRetorno.OK, Data = vDatos };
                return Ok(vRetPro);
            }
            catch (Exception ex)
            {
                RespuestaDTO vRetPro = new RespuestaDTO() { IsOk = ConstantesRetorno.ERROR, Message = ex.Message };
                return Ok(vRetPro);
            }
        }


        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("productoXCodigo")]

        public IActionResult TraerProductoXCodigo(ProductoRq productoRq)
        {
            try
            {
                ProductoDTO producto = new ProductoDTO();

                producto.CodigoProducto = productoRq.CodigoProducto;

                if (producto.CodigoProducto.Equals(""))
                {
                    return Ok(new RespuestaDTO() { IsOk = ConstantesRetorno.ERROR, Message = "El codigo no ha sido ingresaddo" });
                }
                CadenaDTO vCredencialesSql = ConexionFacade.getCredencialesSqlServer();
                IBLL_Producto vBLL_Producto = new BLL_Producto(vCredencialesSql);
                ProductoDTO vProducto = vBLL_Producto.TraerProductoXCodigo(producto);
                dynamic respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.OK, Data = vProducto };
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                RespuestaDTO respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.ERROR, Message = ex.Message };
                return Ok(respuesta);
            }
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("")]

        public IActionResult InsertarProducto(ProductoRq productorq)
        {
            try 
            {
                productorq.CodigoProducto = "";
                if (Convert.ToDateTime(productorq.FechaFabricacionProducto) >= Convert.ToDateTime(productorq.FechaValidezProducto)) 
                {
                        return Ok(new RespuestaDTO { IsOk = ConstantesRetorno.ERROR, Message = "La fecha de frabricacion no puede ser igual o mayor a la fecha de validez  " });
                }

                ProductoDTO producto = new ProductoDTO();
                producto.DescripcionProducto = productorq.DescripcionProducto;
                producto.EstadoProducto = productorq.EstadoProducto.ToUpper();
                producto.FechaFabricacionProducto = productorq.FechaFabricacionProducto;
                producto.FechaValidezProducto = productorq.FechaValidezProducto;
                producto.CodigoProveedor = productorq.CodigoProveedor;
                producto.DescripcionProveedor = productorq.DescripcionProveedor;
                producto.TelefonoProveedor= productorq.TelefonoProveedor;

                CadenaDTO vCredencialesSql = ConexionFacade.getCredencialesSqlServer();
                IBLL_Producto vBLL_Producto = new BLL_Producto(vCredencialesSql);
                ProductoDTO vProducto = vBLL_Producto.InsertarProducto(producto);
                dynamic respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.OK, Data = producto, Message = "Informacion registrada" };
                return Ok(respuesta);
            }
            catch(Exception ex)
            {
                RespuestaDTO respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.ERROR, Message = ex.Message };
                return Ok(respuesta);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("modificarProducto")]
        public IActionResult ModificarProducto(ProductoRq productorq)
        {
            try
            {

                if(productorq.CodigoProducto.Equals(""))
                {
                    return Ok(new RespuestaDTO { IsOk = ConstantesRetorno.ERROR, Message = "debe ingresar el codigo de el producto a modificar" });

                }
                if (Convert.ToDateTime(productorq.FechaFabricacionProducto) >= Convert.ToDateTime(productorq.FechaValidezProducto))
                {
                    return Ok(new RespuestaDTO { IsOk = ConstantesRetorno.ERROR, Message = "La fecha de frabricacion no puede ser igual o mayor a la fecha de validez  " });
                }

                ProductoDTO producto = new ProductoDTO();
                producto.CodigoProducto = productorq.CodigoProducto;
                producto.DescripcionProducto = productorq.DescripcionProducto;
                producto.EstadoProducto = productorq.EstadoProducto.ToUpper();
                producto.FechaFabricacionProducto = productorq.FechaFabricacionProducto;
                producto.FechaValidezProducto = productorq.FechaValidezProducto;
                producto.CodigoProveedor = productorq.CodigoProveedor;
                producto.DescripcionProveedor = productorq.DescripcionProveedor;
                producto.TelefonoProveedor = productorq.TelefonoProveedor;

                CadenaDTO vCredencialesSql = ConexionFacade.getCredencialesSqlServer();
                IBLL_Producto vBLL_Producto = new BLL_Producto(vCredencialesSql);
                ProductoDTO vProducto = vBLL_Producto.ModificarProducto(producto);
                dynamic respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.OK, Data = producto, Message = "Producto modificado" };
                return Ok(respuesta);

            }
            catch (Exception ex)
            {
                RespuestaDTO respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.ERROR, Message = ex.Message };
                return Ok(respuesta);
            }
        }


        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("borrarProducto")]
        
        public IActionResult BorrarProducto(ProductoRq productorq)
        {
            try
            {

                if (productorq.CodigoProducto.Equals(""))
                {
                    return Ok(new RespuestaDTO { IsOk = ConstantesRetorno.ERROR, Message = "debe ingresar el codigo de el producto a borrar" });

                }


                ProductoDTO producto = new ProductoDTO();
                producto.CodigoProducto = productorq.CodigoProducto;

                CadenaDTO vCredencialesSql = ConexionFacade.getCredencialesSqlServer();
                IBLL_Producto vBLL_Producto = new BLL_Producto(vCredencialesSql);
                ProductoDTO vProducto = vBLL_Producto.BorrarProducto(producto);
                dynamic respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.OK, Data = producto, Message = "Producto borrado" };
                return Ok(respuesta);

            }
            catch(Exception ex)
            {
                RespuestaDTO respuesta = new RespuestaDTO() { IsOk = ConstantesRetorno.ERROR, Message = ex.Message };
                return Ok(respuesta);
            }
        }

    }
}

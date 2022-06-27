
using GestionProductos.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionAPI.Conexion
{
    public class ConexionFacade
    {

        public static CadenaDTO getCredencialesSqlServer()
        {
            string vHost = "15.0.2000.5";
            string vUsuario = "sa";
            string vClave = "1002800465";
            //string vDominio = ;
            string vServiceName = "gestion_productos";
            return new CadenaDTO() { Host = vHost,Usuario=vUsuario,Clave=vClave, NombreServicio = vServiceName };
        }
    }
}

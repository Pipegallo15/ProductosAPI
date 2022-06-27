using GestionProductos.DataAcess.ConexionSQL.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductosAPI.DataAcess.DAL
{
    public abstract class META_DAL
    {
        /// <summary>
        /// Atributo de conexión
        /// </summary>
        protected IConexion _Conexion;
    }
}

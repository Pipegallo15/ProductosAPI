
using GestionProductos.Common.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionProductos.DataAcess.ConexionSQL.Implementacion
{
    public abstract class ConexionBase
    {
        /// <summary>
        /// Credenciales de conexión
        /// </summary>
        protected CadenaDTO Credenciales;
        /// <summary>
        /// Tipo de conexion: Enumeración TIPO_ORACLE | TIPO_POSTGRES | TIPO_SQLSERVER
        /// </summary>
        public string TipoConexion;
        /// <summary>
        /// Conectar a base de datos
        /// </summary>
        public abstract void Conectar();
        /// <summary>
        /// Desconectar a base de datos
        /// </summary>
        /// <returns></returns>
        public abstract bool CerrarConexion();
        /// <summary>
        /// Consultar sin parametros
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public abstract DataTable Consultar(string sql);
        /// <summary>
        /// Consultar con parametros
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="Parametros">Arreglo de parametros</param>
        /// <returns>Data table con los datos de la consulta</returns>
        public abstract DataTable Consultar(string sql, IList<ParameterDTO> Parametros);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">Instrucción SQL de ejecución</param>
        /// <param name="Parametros">Arreglo de parametros</param>
        public abstract void Ejecutar(string sql, IList<ParameterDTO> Parametros);
    }
}

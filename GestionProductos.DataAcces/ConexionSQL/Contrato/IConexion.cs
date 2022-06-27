
using GestionProductos.Common.DTO;
using System;
using System.Collections.Generic;
using System.Data;


namespace GestionProductos.DataAcess.ConexionSQL.Contrato
{
    public interface IConexion
    {
        /// <summary>
        /// Conectar a Base de datos
        /// </summary>
        void Conectar();
        /// <summary>
        /// Cerrar conexión a base de datos
        /// </summary>
        /// <returns></returns>
        bool CerrarConexion();
        /// <summary>
        /// Consular en base de datos
        /// </summary>
        /// <param name="sql">Instrución SQL de consulta</param>
        /// <returns>Datos de la consulta</returns>
        DataTable Consultar(string sql);
        /// <summary>
        /// Consular en base de datos con parametros
        /// </summary>
        /// <param name="sql">Instrución SQL de consulta</param>
        /// <param name="Parametros">Lista de Parametros</param>
        /// <returns>Datos de la consulta</returns>
        DataTable Consultar(string sql, IList<ParameterDTO> Parametros);
        /// <summary>
        /// Ejecutar instrucción SQL
        /// </summary>
        /// <param name="sql">Instrucción SQL</param>
        /// <param name="Parametros">Lista de parametros</param>
        void Ejecutar(string sql, IList<ParameterDTO> Parametros);

    }
}

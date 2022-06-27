
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using GestionProductos.DataAcess.ConexionSQL.Contrato;
using GestionProductos.DataAcess.ConexionSQL.Implementacion;
using GestionProductos.Common.DTO;

namespace GestionProductos.DataAcces.ConexionSQL.Implementacion
{
    public class ConexionServer : ConexionBase, IConexion
    {

        private SqlConnection conexion;

        public ConexionServer(CadenaDTO Credenciales)
        {
            this.Credenciales = Credenciales;
        }

        public override void Conectar()
        {

            try
            {
                string CadenaConexion;
                CadenaConexion = "server=DESKTOP-DGVKLUR ; database=gestion_productos ; integrated security = true";

                this.conexion = new SqlConnection(CadenaConexion);

                this.conexion.ConnectionString = CadenaConexion;
                if (this.conexion.State.Equals(ConnectionState.Closed))
                {
                    this.conexion.Open();
                }
            }
            catch (Exception ex)
            {
                ex.GetHashCode();
            }
        }

        /// <summary>
        /// Cerrar la conexión 
        /// </summary>
        /// <returns></returns>
        public override bool CerrarConexion()
        {
            try
            {
                this.conexion.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Consultar en base de datos dada una instrución SQL
        /// </summary>
        /// <param name="sql">Instrucción SQL a ejecutar</param>
        /// <returns>DataTable con los datos</returns>
        public override DataTable Consultar(string sql)
        {
            DataTable datable = new DataTable();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this.conexion;

                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(datable);
                this.CerrarConexion();
                return datable;
            }
            catch (SqlException oe)
            {
                throw new Exception(oe.Message, oe.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.Replace('\'', '\"'));
            }
        }

        /// <summary>
        /// Consultar en base de datos con parametros dada una instrución SQL
        /// </summary>
        /// <param name="sql">Instrucción SQL a ejecutar</param>
        /// <param name="Parametros">Lista de Parametros</param>
        /// <returns></returns>
        public override DataTable Consultar(string sql, IList<ParameterDTO> Parametros)
        {
            DataTable datable = new DataTable();
            try
            {
                this.Conectar();
                //this.conexion.Open();
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this.conexion;

                foreach (ParameterDTO item in Parametros)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Nombre, item.Valor));
                }
                SqlDataAdapter oda = new SqlDataAdapter(cmd);
                oda.Fill(datable);
                this.CerrarConexion();
                return datable;
            }
            catch (SqlException oe)
            {
                throw new Exception(oe.Message, oe.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.Replace('\'', '\"'));
            }
        }

        /// <summary>
        /// Ejecutar SQL con parametros
        /// </summary>
        /// <param name="sql">Instrución de Parametros</param>
        /// <param name="Parametros">Lista de parametros</param>
        public override void Ejecutar(string sql, IList<ParameterDTO> Parametros)
        {
            
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = this.conexion;
                foreach (ParameterDTO item in Parametros)
                {
                    cmd.Parameters.Add(new SqlParameter(item.Nombre, item.Valor));
                }

                cmd.CommandType = CommandType.Text;
                cmd.Connection = this.conexion;
                cmd.ExecuteNonQuery();
                this.CerrarConexion();
            }
            catch (SqlException oe)
            {
                throw new Exception(oe.Message, oe.InnerException);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.Replace('\'', '\"'));
            }
        }
    }
}

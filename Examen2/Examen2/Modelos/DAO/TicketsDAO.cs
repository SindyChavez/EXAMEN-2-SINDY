using Examen2.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2.Modelos.DAO
{
    public class TicketsDAO:Conexion
    {
        SqlCommand comando = new SqlCommand();
        public bool InsertarNuevoTickets(Tickets tickets)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO TICKETS ");
                sql.Append(" VALUES (@NombreCliente, @Fecha, @NombreTipos, @NombreEstados); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, 50).Value = tickets.NombreCliente;
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = tickets.Fecha;
                comando.Parameters.Add("@NombreTipos", SqlDbType.NVarChar, 50).Value = tickets.NombreTipos;
                comando.Parameters.Add("@NombreEstados", SqlDbType.NVarChar, 50).Value = tickets.NombreEstados;

                comando.ExecuteNonQuery();
                MiConexion.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool ModificarTickets(Tickets tickets)
        {
            bool modifico = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE TICKETS ");
                sql.Append(" SET NOMBRECLIENTE  = @NombreCliente, FECHA= @Fecha, NOMBRETIPOS= @NombreTipos, NOMBREESTADOS= @NombreEstados ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = tickets.Id;
                comando.Parameters.Add("@NombreCliente", SqlDbType.NVarChar, 50).Value = tickets.NombreCliente;
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = tickets.Fecha;
                comando.Parameters.Add("@NombreTipos", SqlDbType.NVarChar, 50).Value = tickets.NombreTipos;
                comando.Parameters.Add("@NombreEstados", SqlDbType.NVarChar, 50).Value = tickets.NombreEstados;
                comando.ExecuteNonQuery();
                modifico = true;
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                return modifico;
            }
            return modifico;
        }

        public bool EliminarTickets(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM TICKETS ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.Parameters.Clear();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                comando.ExecuteNonQuery();
                elimino = true;
                MiConexion.Close();

            }
            catch (Exception ex)
            {
                return elimino;
            }
            return elimino;
        }

        public DataTable GetTickets()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM TICKETS ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
            }
            return dt;
        }



    }
}

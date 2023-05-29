using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using WSLogisticaEmpresa.Connection;
using WSLogisticaEmpresa.Models;

namespace WSLogisticaEmpresa.Services
{
    public class TipoProductoServices
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        ConnectionBd _connectionBd = null;
        TipoProductos resultado = null;

        /// <summary>
        ///  metodo para consultar las TipoProductos
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdCliente"></param>
        /// <param name="Identificacion"></param>
        /// <returns></returns>
        public List<TipoProductos> GetAll(int opcion, int IdTipoProducto, string? TipoProducto  = "", string? TipoLogistica = "")
        {
            _connectionBd = new ConnectionBd();
            List<TipoProductos> clienteList = new List<TipoProductos>();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[SelectTipoProductos]";
                    if (opcion != 0)
                    {
                        _command.Parameters.AddWithValue("@Opcion", SqlDbType.Int).Value = opcion;
                    }
                    if (IdTipoProducto != 0)
                    {
                        _command.Parameters.AddWithValue("@IdTipoProducto", SqlDbType.Int).Value = IdTipoProducto;
                    }
                    if (TipoProducto != "")
                    {
                        _command.Parameters.AddWithValue("@TipoProducto", SqlDbType.VarChar).Value = TipoProducto;
                    }
                    if (TipoLogistica != "")
                    {
                        _command.Parameters.AddWithValue("@TipoLogistica", SqlDbType.VarChar).Value = TipoLogistica;
                    }
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    while (dr.Read())
                    {
                        TipoProductos TipoProductos = new TipoProductos();
                        TipoProductos.IdTipoProducto = Convert.ToInt32(dr["IdTipoProducto"]);
                        TipoProductos.TipoProducto = dr["TipoProducto"].ToString()!;
                        TipoProductos.TipoLogistica = dr["TipoLogistica"].ToString()!;
                       
                        clienteList.Add(TipoProductos);
                    }
                    //se cierra conexión
                    _connection.Close();
                }
                return clienteList;
            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }


        /// <summary>
        /// metodo para crear nuevas TipoProductos
        /// </summary>
        /// <param name="TipoProductos"></param>
        /// <returns></returns>
        public TipoProductos AddTipoProductos(TipoProductos TipoProductos)
        {
            _connectionBd = new ConnectionBd();
            resultado = new TipoProductos();
            SqlDataReader dr = null;
            int id = 0;
            try
            {


                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[InsertTipoProductos]";
                    _command.Parameters.AddWithValue("@TipoProducto", SqlDbType.VarChar).Value = TipoProductos.TipoProducto;
                    _command.Parameters.AddWithValue("@TipoLogistica", SqlDbType.VarChar).Value = TipoProductos.TipoLogistica;

                    _connection.Open();
                    dr = _command.ExecuteReader();
                    foreach (DbDataRecord dbDR in dr)
                    {
                        id = dbDR.GetInt32(0);

                    }
                    //se cierra conexión
                    _connection.Close();
                }
                return resultado;

            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        /// <summary>
        /// metodo para actualizar TipoProductos
        /// </summary>
        /// <param name="TipoProductos"></param>
        /// <returns></returns>
        public TipoProductos UpdateTipoProductos(TipoProductos TipoProductos)
        {
            _connectionBd = new ConnectionBd();
            resultado = new TipoProductos();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[UpdateTipoProductos]";
                    _command.Parameters.AddWithValue("@IdTipoProducto", SqlDbType.Int).Value = TipoProductos.IdTipoProducto;
                    _command.Parameters.AddWithValue("@TipoProducto", SqlDbType.VarChar).Value = TipoProductos.TipoProducto;
                    _command.Parameters.AddWithValue("@TipoLogistica", SqlDbType.VarChar).Value = TipoProductos.TipoLogistica;
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    //se cierra conexión
                    _connection.Close();
                }
                return resultado;

            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        /// <summary>
        /// metodo para eliminar TipoProductos
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        public TipoProductos DeleteTipoProductos(int IdTipoProducto)
        {
            _connectionBd = new ConnectionBd();
            resultado = new TipoProductos();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[DeleteTipoProductos]";
                    _command.Parameters.AddWithValue("@IdTipoProducto", SqlDbType.Int).Value = IdTipoProducto;
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    //se cierra conexión
                    _connection.Close();
                }
                return resultado;

            }
            catch (Exception ex)
            {
                return null;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
    }
}

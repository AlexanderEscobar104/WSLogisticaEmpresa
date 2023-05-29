using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using WSLogisticaEmpresa.Connection;
using WSLogisticaEmpresa.Models;

namespace WSLogisticaEmpresa.Services
{
    public class PlanesServices
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        ConnectionBd _connectionBd = null;
        Planes resultado = null;

        /// <summary>
        ///  metodo para consultar las Planes
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdCliente"></param>
        /// <param name="Identificacion"></param>
        /// <returns></returns>
        public List<Planes> GetAll(int opcion, int IdPlanEntrega, string? IdCliente = "")
        {
            _connectionBd = new ConnectionBd();
            List<Planes> clienteList = new List<Planes>();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[SelectPlanes]";
                    if (opcion != 0)
                    {
                        _command.Parameters.AddWithValue("@Opcion", SqlDbType.Int).Value = opcion;
                    }
                    if (IdPlanEntrega != 0)
                    {
                        _command.Parameters.AddWithValue("@IdPlanEntrega", SqlDbType.Int).Value = IdPlanEntrega;
                    }
                    if (IdCliente != "")
                    {
                        _command.Parameters.AddWithValue("@IdCliente", SqlDbType.VarChar).Value = IdCliente;
                    }
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    while (dr.Read())
                    {
                        Planes Planes = new Planes();
                        Planes.IdPlanEntrega = Convert.ToInt32(dr["IdPlanEntrega"]);
                        Planes.IdCliente = Convert.ToInt32(dr["IdCliente"].ToString())!;
                        Planes.IdTipoProducto = Convert.ToInt32(dr["IdTipoProducto"].ToString())!;
                        Planes.Cantidad = Convert.ToInt32(dr["Cantidad"].ToString())!;
                        Planes.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())!;
                        Planes.FechaEntrega = Convert.ToDateTime(dr["FechaEntrega"].ToString())!;
                        Planes.PuertoEnvio = dr["PuertoEnvio"].ToString()!;
                        Planes.PrecioEnvio = Convert.ToInt32(dr["PrecioEnvio"].ToString())!;
                        Planes.Descuento = Convert.ToInt32(dr["Descuento"].ToString())!;
                        Planes.NumeroFlota = dr["NumeroFlota"].ToString()!;
                        Planes.NumeroGuia = dr["NumeroGuia"].ToString()!;
                        Planes.TipoLogistica = dr["TipoLogistica"].ToString()!;
                        Planes.Placa = dr["Placa"].ToString()!;
                        Planes.Nombres = dr["Nombres"].ToString()!;
                        Planes.TipoProducto = dr["TipoProducto"].ToString()!;

                        clienteList.Add(Planes);
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
        /// metodo para crear nuevas Planes
        /// </summary>
        /// <param name="Planes"></param>
        /// <returns></returns>
        public Planes AddPlanes(Planes Planes)
        {
            _connectionBd = new ConnectionBd();
            resultado = new Planes();
            SqlDataReader dr = null;
            Int64 id = 0;
            try
            {


                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[InsertPlanes]";
                    _command.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = Planes.IdCliente;
                    _command.Parameters.AddWithValue("@IdTipoProducto", SqlDbType.Int).Value = Planes.IdTipoProducto;
                    _command.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = Planes.Cantidad;
                    _command.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = Planes.FechaRegistro;
                    _command.Parameters.AddWithValue("@FechaEntrega", SqlDbType.DateTime).Value = Planes.FechaEntrega;
                    _command.Parameters.AddWithValue("@PuertoEnvio", SqlDbType.VarChar).Value = Planes.PuertoEnvio;
                    _command.Parameters.AddWithValue("@PrecioEnvio", SqlDbType.Int).Value = Planes.PrecioEnvio;
                    _command.Parameters.AddWithValue("@Descuento", SqlDbType.Int).Value = Planes.Descuento;
                    _command.Parameters.AddWithValue("@NumeroFlota", SqlDbType.VarChar).Value = Planes.NumeroFlota;
                    _command.Parameters.AddWithValue("@NumeroGuia", SqlDbType.VarChar).Value = Planes.NumeroGuia;
                    _command.Parameters.AddWithValue("@TipoLogistica", SqlDbType.VarChar).Value = Planes.TipoLogistica;
                    _command.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = Planes.Placa;
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    foreach (DbDataRecord dbDR in dr)
                    {
                        id = dbDR.GetInt64(0);
                      

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
        /// metodo para actualizar Planes
        /// </summary>
        /// <param name="Planes"></param>
        /// <returns></returns>
        public Planes UpdatePlanes(Planes Planes)
        {
            _connectionBd = new ConnectionBd();
            resultado = new Planes();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[UpdatePlanes]";
                    _command.Parameters.AddWithValue("@IdPlanEntrega", SqlDbType.Int).Value = Planes.IdPlanEntrega;
                    _command.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = Planes.IdCliente;
                    _command.Parameters.AddWithValue("@IdTipoProducto", SqlDbType.Int).Value = Planes.IdTipoProducto;
                    _command.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value = Planes.Cantidad;
                    _command.Parameters.AddWithValue("@FechaRegistro", SqlDbType.DateTime).Value = Planes.FechaRegistro;
                    _command.Parameters.AddWithValue("@FechaEntrega", SqlDbType.DateTime).Value = Planes.FechaEntrega;
                    _command.Parameters.AddWithValue("@PuertoEnvio", SqlDbType.VarChar).Value = Planes.PuertoEnvio;
                    _command.Parameters.AddWithValue("@PrecioEnvio", SqlDbType.Int).Value = Planes.PrecioEnvio;
                    _command.Parameters.AddWithValue("@Descuento", SqlDbType.Int).Value = Planes.Descuento;
                    _command.Parameters.AddWithValue("@NumeroFlota", SqlDbType.VarChar).Value = Planes.NumeroFlota;
                    _command.Parameters.AddWithValue("@NumeroGuia", SqlDbType.VarChar).Value = Planes.NumeroGuia;
                    _command.Parameters.AddWithValue("@TipoLogistica", SqlDbType.VarChar).Value = Planes.TipoLogistica;
                    _command.Parameters.AddWithValue("@Placa", SqlDbType.VarChar).Value = Planes.Placa;
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
        /// metodo para eliminar Planes
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        public Planes DeletePlanes(int IdPlanEntrega)
        {
            _connectionBd = new ConnectionBd();
            resultado = new Planes();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[DeletePlanes]";
                    _command.Parameters.AddWithValue("@IdPlanEntrega", SqlDbType.Int).Value = IdPlanEntrega;
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

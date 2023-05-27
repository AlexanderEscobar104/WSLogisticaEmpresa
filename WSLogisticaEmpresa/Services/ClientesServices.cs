using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Data;
using WSLogisticaEmpresa.Connection;
using WSLogisticaEmpresa.Models;

namespace WSLogisticaEmpresa.Services
{
    public class ClientesServices
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;
        ConnectionBd _connectionBd = null;
        Clientes resultado = null;

        /// <summary>
        ///  metodo para consultar las Clientes
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdCliente"></param>
        /// <param name="Identificacion"></param>
        /// <returns></returns>
        public List<Clientes> GetAll(int opcion, int IdCliente, string? Identificacion = "")
        {
            _connectionBd = new ConnectionBd();
            List<Clientes> clienteList = new List<Clientes>();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[SelectClientes]";
                    if (opcion != 0)
                    {
                        _command.Parameters.AddWithValue("@Opcion", SqlDbType.Int).Value = opcion;
                    }
                    if (IdCliente != 0)
                    {
                        _command.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = IdCliente;
                    }
                    if (Identificacion != "")
                    {
                        _command.Parameters.AddWithValue("@Identificacion", SqlDbType.VarChar).Value = Identificacion;
                    }
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    while (dr.Read())
                    {
                        Clientes Clientes = new Clientes();
                        Clientes.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        Clientes.Identificacion = dr["Identificacion"].ToString()!;
                        Clientes.Nombres = dr["Nombres"].ToString()!;
                        Clientes.Direccion = dr["Direccion"].ToString()!;
                        Clientes.Telefono = dr["Telefono"].ToString()!;
                        clienteList.Add(Clientes);
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
        /// metodo para crear nuevas Clientes
        /// </summary>
        /// <param name="Clientes"></param>
        /// <returns></returns>
        public string AddClientes(Clientes Clientes)
        {
            _connectionBd = new ConnectionBd();
            resultado = new Clientes();
            SqlDataReader dr = null;
            long id = 0;
            try
            {
              

                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[InsertClientes]";
                    _command.Parameters.AddWithValue("@Identificacion", SqlDbType.VarChar).Value = Clientes.Identificacion;
                    _command.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = Clientes.Nombres;
                    _command.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Clientes.Direccion;
                    _command.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = Clientes.Telefono;
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    foreach (DbDataRecord dbDR in dr)
                    {
                        id = dbDR.GetInt64(0);

                    }
                    //se cierra conexión
                    _connection.Close();
                }
                return "cliente Almacenado Id " + id;

            }
            catch (Exception ex)
            {
                return "Error cliente No Almacenado " + ex;

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
        /// metodo para actualizar Clientes
        /// </summary>
        /// <param name="Clientes"></param>
        /// <returns></returns>
        public string UpdateClientes(Clientes Clientes)
        {
            _connectionBd = new ConnectionBd();
            resultado = new Clientes();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[UpdateClientes]";
                    _command.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = Clientes.IdCliente;
                    _command.Parameters.AddWithValue("@Identificacion", SqlDbType.VarChar).Value = Clientes.Identificacion;
                    _command.Parameters.AddWithValue("@Nombres", SqlDbType.VarChar).Value = Clientes.Nombres;
                    _command.Parameters.AddWithValue("@Direccion", SqlDbType.VarChar).Value = Clientes.Direccion;
                    _command.Parameters.AddWithValue("@Telefono", SqlDbType.VarChar).Value = Clientes.Telefono;
                    dr = _command.ExecuteReader();
                    //se cierra conexión
                    _connection.Close();
                }
                return "cliente Actualizado";

            }
            catch (Exception ex)
            {
                return "Error cliente No Actualizado " + ex;

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
        /// metodo para eliminar Clientes
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        public string DeleteClientes(int IdCliente)
        {
            _connectionBd = new ConnectionBd();
            resultado = new Clientes();
            SqlDataReader dr = null;
            try
            {
                using (_connection = new SqlConnection(_connectionBd.GetConnectionString()))
                {
                    _command = _connection.CreateCommand();
                    _command.CommandType = System.Data.CommandType.StoredProcedure;
                    _command.CommandText = "[dbo].[DeleteClientes]";
                    _command.Parameters.AddWithValue("@IdCliente", SqlDbType.Int).Value = IdCliente;
                    _connection.Open();
                    dr = _command.ExecuteReader();
                    //se cierra conexión
                    _connection.Close();
                }
                return "cliente Eliminado";

            }
            catch (Exception ex)
            {
                return "Error cliente No Eliminado " + ex;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapper;
using Identity;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Data
{
    public class ClienteData
    {
        public List<Cliente> ObtenerTodosLosClientes()
        {
            List<Cliente> cliente = new List<Cliente>();
            try
            {
                using(SqlConnection conn = new SqlConnection(ConexionString.ObtenerConexion()))
                {
                    conn.Open();
                    string sql = "SELECT * FROM CLIENTE";
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader read = command.ExecuteReader())
                        {
                            while (read.Read())
                            {
                                Cliente Cliente = ClienteMapper.MapearCamposCliente(read);
                                cliente.Add(Cliente);
                            }
                        }
                    }
                }
                return cliente;
            
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString.ObtenerConexion()))
                {
                    conn.Open();
                    string sql = "INSERT INTO CLIENTE (NOMBRE, APELLIDO, CORREO_ELECTRONICO, TELEFONO) VALUES (@nombre, @apellido, @correo, @telefono)";
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@nombre", cliente.Nombre);
                        command.Parameters.AddWithValue("@apellido", cliente.Apellido);
                        command.Parameters.AddWithValue("@correo", cliente.Mail);
                        command.Parameters.AddWithValue("@telefono", cliente.Telefono);
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ModificarCliente(int idcliente, string Mail, string Telefono)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString.ObtenerConexion()))
                {
                    conn.Open();
                    string sql = "UPDATE CLIENTE SET CORREO_ELECTRONICO = @correo, TELEFONO = @telefono WHERE ID_CLIENTE = @idCliente";
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@idCliente", idcliente);
                        command.Parameters.AddWithValue("@correo", Mail);
                        command.Parameters.AddWithValue("@telefono", Telefono);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch (Exception ex)
            {
                throw;
            }
        }

            public void EliminarCLiente(int idCliente)
            {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString.ObtenerConexion()))
                {
                    conn.Open();
                    string sql = "DELETE FROM CLIENTE WHERE ID_CLIENTE = @idCliente";
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.AddWithValue("@idCliente", idCliente);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }
        public Cliente ObtenerClientePorID(int idCliente)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConexionString.ObtenerConexion()))
                {
                    conn.Open();
                    string sql = "SELECT ID_CLIENTE, NOMBRE, APELLIDO, CORREO_ELECTRONICO, TELEFONO FROM CLIENTE WHERE ID_CLIENTE = @idCliente";
                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        command.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return ClienteMapper.MapearCamposCliente(reader);
                            }
                        }
                    }
                }
                return null;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}

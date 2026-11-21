using Identity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public class ClienteMapper
    {
        public static Cliente MapearCamposCliente(SqlDataReader reader)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = Convert.ToInt32(reader["ID_CLIENTE"]);
            cliente.Nombre = Convert.ToString(reader["NOMBRE"]);
            cliente.Apellido = Convert.ToString(reader["APELLIDO"]);
            cliente.Mail = Convert.ToString(reader["CORREO_ELECTRONICO"]);
            cliente.Telefono = Convert.ToString(reader["TELEFONO"]);
            return cliente;
        }
    }
}

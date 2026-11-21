using Data;
using Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;


namespace Business
{
    public class ClienteBusiness
    {
        public List<Cliente> clientes = new List<Cliente>();

        ClienteData clienteData = new ClienteData();


        public List<Cliente> ObtenerClientes()
        {
            return clienteData.ObtenerTodosLosClientes();
        }


        public void AgregarCliente(Cliente cliente)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    ValidarApellido(cliente.Apellido);
                    ValidarNombre(cliente.Nombre);
                    ValidarMail(cliente.Mail);
                    ValidarTelefono(cliente.Telefono);
                    clienteData.AgregarCliente(cliente);
                    transaction.Complete();
                }

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void ModificarCliente(int idcliente, string mail, string telefono)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    ValidarIDCliente(idcliente);
                    ValidarMail(mail);
                    ValidarTelefono(telefono);
                    clienteData.ModificarCliente(idcliente, mail, telefono);
                    transaction.Complete();
                }

            }
            catch(Exception ex)
            {
                throw;
            }

        }
        public void EliminarCliente(int idcliente)
        {
            try
            {

                ValidarIDCliente(idcliente);
                clienteData.EliminarCLiente(idcliente);
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public void ValidarNombre(string nombre)
        {

            if (string.IsNullOrEmpty(nombre) || nombre.Trim().Length < 2)
            {
                throw new Exception("el nombre debe tener al menos 2 caracteres");
            }
        }

        public void ValidarApellido(string apellido)
        {
            if (string.IsNullOrEmpty(apellido) || apellido.Trim().Length < 2)
            {
                throw new Exception("el apellido debe tener al menos 2 caracteres");
            }
        }

        public void ValidarTelefono(string apellido)
        {
            if (!apellido.All(char.IsDigit))
                {
                throw new Exception("el telfono no puede contener letras");
            }

        }

        public void ValidarMail(string mail)
        {
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (string.IsNullOrEmpty(mail) || !Regex.IsMatch(mail.Trim(), patron))
            {
                throw new Exception("el correo electronico no tiene un formato valido");
            }
        }

        public void ValidarIDCliente(int idcliente)
        {
            Cliente Idcliente = clienteData.ObtenerClientePorID(idcliente);

            if(Idcliente == null || idcliente <= 0)
            {
                throw new Exception("el id ingresado no es valido");
            }
        }
    }
}

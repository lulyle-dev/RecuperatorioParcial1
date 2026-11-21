using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity
{
    public class Cliente
    {
        private int idCliente;
        private string nombre;
        private string apellido;
        private string mail;
        private string telefono;

        public int IdCliente
        {
            get => idCliente; set => idCliente = value;
        }

        public string Nombre
        {
            get => nombre; set => nombre = value;
        }

        public string   Apellido
        {
            get => apellido; set => apellido = value;
        }

        public string Mail
        {
            get => mail; set => mail = value;
        }

        public string Telefono
        {
            get => telefono; set => telefono = value;
        }
    }
}

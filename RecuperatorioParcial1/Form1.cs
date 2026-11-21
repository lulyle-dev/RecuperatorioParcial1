using Business;
using Identity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace RecuperatorioParcial1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClienteBusiness clienteBusiness = new ClienteBusiness();
        
        public void ActualizarDGV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = clienteBusiness.ObtenerClientes();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente clienteNuevo = MapearCampos();
                clienteNuevo.Mail = textBox9.Text;
                clienteNuevo.Telefono = textBoxTelefono.Text;
               clienteBusiness.AgregarCliente(clienteNuevo);
                MessageBox.Show("Se ha agregado el cliente a la base de datos");
                limpiarCampos();
                ActualizarDGV();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

            try
            {
                clienteBusiness.ModificarCliente(Convert.ToInt32(textBox10.Text), textBox11.Text, textBoxTelefonoMod.Text);
                MessageBox.Show("se han guardado las modificaciones");
                ActualizarDGV();
                limpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                clienteBusiness.EliminarCliente(Convert.ToInt32(textBox12.Text));
                MessageBox.Show("se ha eliminado la reserva");
                ActualizarDGV();
                limpiarCampos();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActualizarDGV();
        }


        public Cliente MapearCampos()
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = textBox7.Text;
            cliente.Apellido = textBox8.Text;
            return cliente;
        }

        public void limpiarCampos()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBoxTelefono.Clear();
            textBoxTelefonoMod.Clear();
            textBox12.Clear();
        }
    }
}

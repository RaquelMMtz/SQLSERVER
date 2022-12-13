using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Layout : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Layout()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Layout";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Layout");
            conexion.Close();
            dGVLayout.DataSource = ds.Tables["Layout"];
        }
        private void Layout_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string fechaEntrega = txtFechaEntrega.Text;
            string CD = txtCD.Text;
            string tipo = txtTipo.Text;
            consulta = "INSERT INTO Layout (fechaEntrega, correccionDibujo, tipo) values ('" + fechaEntrega + "','" + CD + "','" + tipo + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFechaEntrega.Clear();
            txtCD.Clear();
            txtTipo.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idLayout = (int)dGVLayout.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Layout SET ESTATUS = 0 WHERE idLayout =" + idLayout.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fechaEntrega = txtFechaEntrega.Text;
            string CD = txtCD.Text;
            string tipo = txtTipo.Text;
            int idLayout = (int)dGVLayout.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Layout SET fechaEntrega ='" + fechaEntrega + "',correccionDibujo='" + CD + "',tipo='" + tipo + "'WHERE idLayout = " + idLayout.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFechaEntrega.Clear();
            txtCD.Clear();
            txtTipo.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }

}
    

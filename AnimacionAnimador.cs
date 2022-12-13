using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class AnimacionAnimador : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public AnimacionAnimador()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM AnimacionAnimador";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "AnimacionAnimador");
            conexion.Close();
            dGVAA.DataSource = ds.Tables["AnimacionAnimador"];
        }
        private void AnimacionAnimador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Animacion = txtIDANI.Text;
            string Animador = txtIDAN.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO AnimacionAnimador (idAnimacion, idAnimador, numIntegrantes) values ('" + Animacion + "','" + Animador + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDANI.Clear();
            txtIDAN.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAnimacionAnimador = (int)dGVAA.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AnimacionAnimador SET ESTATUS = 0 WHERE idAnimacionAnimador =" + idAnimacionAnimador.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Animacion = txtIDANI.Text;
            string Animador = txtIDAN.Text;
            string numInt = txtNumIn.Text;
            int idAnimacionAnimador = (int)dGVAA.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE AnimacionAnimador SET idAnimacion ='" + Animacion + "',idAnimador='" + Animador + "',numIntegrantes='" + numInt + "'WHERE idAnimacionAnimador = " + idAnimacionAnimador.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDANI.Clear();
            txtIDAN.Clear();
            txtNumIn.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

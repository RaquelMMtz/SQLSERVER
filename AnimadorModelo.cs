using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class AnimadorModelo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public AnimadorModelo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM AnimadorModelo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "AnimadorModelo");
            conexion.Close();
            dGVAM.DataSource = ds.Tables["AnimadorModelo"];
        }
        private void AnimadorModelo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Animador = txtIDANIM.Text;
            string Modelo = txtIDM.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO AnimadorModelo (idAnimador,idModelo, numIntegrantes) values ('" + Animador + "','" + Modelo + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDANIM.Clear();
            txtIDM.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAnimadorModelo = (int)dGVAM.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE AnimadorModelo SET ESTATUS = 0 WHERE idAnimadorModelo =" + idAnimadorModelo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Animador = txtIDANIM.Text;
            string Modelo = txtIDM.Text;
            string numInt = txtNumIn.Text;
            int idAnimadorModelo = (int)dGVAM.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE AnimadorModelo SET idAnimador ='" + Animador + "',idModelo='" + Modelo + "',numIntegrantes ='" + numInt + "'WHERE idAnimadorModelo = " + idAnimadorModelo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDANIM.Clear();
            txtIDM.Clear();
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

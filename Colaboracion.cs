using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Colaboracion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Colaboracion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Colaboracion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Colaboracion");
            conexion.Close();
            dGVColaboracion.DataSource = ds.Tables["Colaboracion"];
        }

        private void Colaboracion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Estudio = txtEstudio.Text;
            string NumInt = txtNumIn.Text;
            string idJuntaDirectiva = txtIDJD.Text;
            consulta = "INSERT INTO Colaboracion (estudio, numIntegrantes, idJuntaDirectiva) values ('" + Estudio + "','" + NumInt + "','" + idJuntaDirectiva + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtEstudio.Clear();
            txtIDJD.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idColaboracion = (int)dGVColaboracion.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Colaboracion SET ESTATUS = 0 WHERE idColaboracion =" + idColaboracion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Estudio = txtEstudio.Text;
            string NumInt = txtNumIn.Text;
            string idJuntaDirectiva = txtIDJD.Text;
            int idColaboracion = (int)dGVColaboracion.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Colaboracion SET estudio ='" + Estudio + "',numIntegrantes='" + NumInt + "',idJuntaDirectiva='" + idJuntaDirectiva + "'WHERE idColaboracion = " + idColaboracion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtEstudio.Clear();
            txtIDJD.Clear();
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

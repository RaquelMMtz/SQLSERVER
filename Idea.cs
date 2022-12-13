using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Idea : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Idea()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Idea";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Idea" );
            conexion.Close();
            dGVIdea.DataSource = ds.Tables["Guion"];
        }
        private void Idea_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string propuesta = txtPro.Text;
            string fecha = txtFecha.Text;
            string idJuntaDirectiva = txtidJD.Text;
            consulta = "INSERT INTO Idea (propuesta, fechaEntrega, idJuntaDirectiva) values ('" + propuesta + "','" + fecha + "','" + idJuntaDirectiva + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPro.Clear();
            txtFecha.Clear();
            txtidJD.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idIdea = (int)dGVIdea.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Idea SET ESTATUS = 0 WHERE idIdea =" + idIdea.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string propuesta = txtPro.Text;
            string fecha = txtFecha.Text;
            string idJuntaDirectiva = txtidJD.Text;
            int idIdea = (int)dGVIdea.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Idea SET propuesta ='" + propuesta + "',fechaEntrega='" + fecha + "',idJuntaDirectiva='" + idJuntaDirectiva + "'WHERE idIdea = " + idIdea.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPro.Clear();
            txtFecha.Clear();
            txtidJD.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class DirectorGerente : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public DirectorGerente()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM DirectorGerente";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "DirectorGerente");
            conexion.Close();
            dGVDG.DataSource = ds.Tables["DirectorGerente"];
        }
        private void DirectorGerente_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Director = txtIDD.Text;
            string Gerente = txtIDG.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO AnimacionAnimador (idAnimacion, idAnimador, numIntegrantes) values ('" + Director + "','" + Gerente + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDD.Clear();
            txtIDG.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idDirectorGerente = (int)dGVDG.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DirectorGerenre SET ESTATUS = 0 WHERE idDirectorGerente =" + idDirectorGerente.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Director = txtIDD.Text;
            string Gerente = txtIDG.Text;
            string numInt = txtNumIn.Text;
            int idDirectorGerente = (int)dGVDG.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE DirectorGerente SET idDirector ='" + Director + "',idGerente='" + Gerente + "',numIntegrantes='" + numInt + "'WHERE idDirectorGerente = " + idDirectorGerente.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDD.Clear();
            txtIDG.Clear();
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

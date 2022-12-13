using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Actor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Actor()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Actor";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Actor");
            conexion.Close();
            dGVActor.DataSource = ds.Tables["Actor"];
        }
        private void Actor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string ap = txtAP.Text;
            string am = txtAM.Text;
            string personaje = txtPersonaje.Text;
            string idDirectorr = txtidD.Text;
            consulta = "INSERT INTO Actor (nombre, apellidoPaterno, apellidoMaterno, personaje, idDirector) values ('" + nombre + "','" + ap + "','" + am + "','" + personaje + "','" + idDirectorr + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtidD.Clear();
            txtPersonaje.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idActor = (int)dGVActor.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Actor SET ESTATUS = 0 WHERE idActor =" + idActor.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string ap = txtAP.Text;
            string am = txtAM.Text;
            string personaje = txtPersonaje.Text;
            string idDirectorr = txtidD.Text;
            int idActor = (int)dGVActor.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Actor SET nombre ='" + nombre + "',apellidoPaterno = '" + ap + "', apellidoMaterno = '" + am + "', personaje = '" + personaje + "',idDirector = '" + idDirectorr + "'WHERE idActor = " + idActor.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtidD.Clear();
            txtPersonaje.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

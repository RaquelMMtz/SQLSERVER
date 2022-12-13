using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Musico : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Musico()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Musico";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Musico");
            conexion.Close();
            dGVMusico.DataSource = ds.Tables["Musico"];
        }
        private void Musico_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string ap = txtAP.Text;
            string am = txtAM.Text;
            string tM = txtTM.Text;
            consulta = "INSERT INTO Musico (nombre, apellidoPaterno, apellidoMaterno, tipoMusica) values ('" + nombre + "','" + ap + "','" + am + "', '" + tM+ "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtTM.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMusico = (int)dGVMusico.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Musico SET ESTATUS = 0 WHERE idMusico =" + idMusico.ToString();
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
            string tM = txtTM.Text;
            int idMusico = (int)dGVMusico.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Musico SET nombre ='" + nombre + "',apellidoPaterno='" + ap + "',apellidoMaterno='" + am + "',tipoMusica='" + tM + "'WHERE idMusico = " + idMusico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtTM.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

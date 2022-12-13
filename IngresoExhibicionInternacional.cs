using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class IngresoExhibicionInternacional : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public IngresoExhibicionInternacional()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM IngresoExhibicionInternacional";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "IngresoExhibicionInternacional");
            conexion.Close();
            dGVIE.DataSource = ds.Tables["IngresoExhibicionInternacional"];
        }

        private void IngresoExhibicionInternacional_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Ingreso = txtIDI.Text;
            string ExInt = txtIDEI.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO IngresoExhibicionInternacional (idIngreso,idExhibicionInternacional, numIntegrantes) values ('" + Ingreso + "','" + ExInt + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDI.Clear();
            txtIDEI.Clear();
            txtNumIn.Clear();
        }
    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idIngresoExhibicionInternacional = (int)dGVIE.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE IngresoExhibicionInternacional SET ESTATUS = 0 WHERE idIngresoExhibicionInternacional =" + idIngresoExhibicionInternacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Ingreso = txtIDI.Text;
            string ExInt = txtIDEI.Text;
            string numInt = txtNumIn.Text;
            int idIngresoExhibicionInternacional = (int)dGVIE.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE IngresoExhibicionInternacional SET idIngreso ='" + Ingreso + "',idExhibicionInternacional='" + ExInt + "',numIntegrantes='" + numInt + "'WHERE idAExhibicionInternacional = " + idIngresoExhibicionInternacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDI.Clear();
            txtIDEI.Clear();
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

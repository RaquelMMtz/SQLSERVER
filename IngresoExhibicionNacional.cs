using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class IngresoExhibicionNacional : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public IngresoExhibicionNacional()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM IngresoExhibicionNacional";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "IngresoExhibicionNacional");
            conexion.Close();
            dGVIE.DataSource = ds.Tables["IngresoExhibicionNacional"];
        }
        private void IngresoExhibicionNacional_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            string Ingreso = txtIDI.Text;
            string ExNa = txtIDEN.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO IngresoExhibicionNacional (idIngreso,idExhibicionNacional, numIntegrantes) values ('" + Ingreso + "','" + ExNa + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDI.Clear();
            txtIDEN.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idIngresoExhibicionNacional = (int)dGVIE.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE IngresoExhibicionInternacional SET ESTATUS = 0 WHERE idIngresoExhibicionNacional =" + idIngresoExhibicionNacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Ingreso = txtIDI.Text;
            string ExNa = txtIDEN.Text;
            string numInt = txtNumIn.Text;
            int idIngresoExhibicionNacional = (int)dGVIE.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE IngresoExhibicionNacional SET idIngreso ='" + Ingreso + "',idExhibicionNacional='" + ExNa + "',numIntegrantes='" + numInt + "'WHERE idAExhibicionNacional = " + idIngresoExhibicionNacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDI.Clear();
            txtIDEN.Clear();
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

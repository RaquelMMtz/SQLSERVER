using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class CambioDirectivo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public CambioDirectivo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM CambioDirectivo";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "CambioDirectivo");
            conexion.Close();
            dGVCD.DataSource = ds.Tables["CambioDirectivo"];
        }
        private void CambioDirectivo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Directivo = txtIDD.Text;
            string Cambio = txtIDC.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO CambioDirectivo (idCambio, idDirectivo, numIntegrantes) values ('" + Cambio + "','" + Directivo + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDD.Clear();
            txtIDC.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idCambioDirectivo = (int)dGVCD.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE CambioDirectivo SET ESTATUS = 0 WHERE idCambioDirectivo =" + idCambioDirectivo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Directivo = txtIDD.Text;
            string Cambio = txtIDC.Text;
            string numInt = txtNumIn.Text;
            int idCambioDirectivo = (int)dGVCD.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE AnimacionAnimador SET idCambio ='" + Cambio + "',idDirectivo='" + Directivo + "',numIntegrantes='" + numInt + "'WHERE idCambioDirectivo = " + idCambioDirectivo.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDD.Clear();
            txtIDC.Clear();
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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class PulidoCamara : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public PulidoCamara()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM PulidoCamara";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "PulidoCamara");
            conexion.Close();
            dGVPC.DataSource = ds.Tables["PulidoCamara"];
        }
        private void PulidoCamara_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string detalles = txtDet.Text;
            string idTecnico = txtIDTecnico.Text;
            consulta = "INSERT INTO PulidoCamara (fechaEntrega, detalles, idTecnico) values ('" + fecha + "','" + detalles + "','" + idTecnico + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtDet.Clear();
            txtIDTecnico.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPulidoCamara = (int)dGVPC.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PulidoCamara SET ESTATUS = 0 WHERE idPulidoCamara =" + idPulidoCamara.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string detalles = txtDet.Text;
            string idTecnico = txtIDTecnico.Text;
            int idPulidoCamara = (int)dGVPC.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE PulidoCamara SET fechaEntrega ='" + fecha + "',detalles='" + detalles + "',idTecnico='" + idTecnico + "'WHERE idPulidoCamara = " + idPulidoCamara.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtDet.Clear();
            txtIDTecnico.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

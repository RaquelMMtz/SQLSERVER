using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class SFX : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public SFX()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM SFX";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "SFX");
            conexion.Close();
            dGVSFX.DataSource = ds.Tables["SFX"];
        }
        private void SFX_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string Tipo = txtTipo.Text;
            string idTecnico = txtIDTecnico.Text;
            consulta = "INSERT INTO SFX (tipo, fechaEntrega, idTecnico) values ('" + Tipo + "','" + fecha + "','" + idTecnico + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtTipo.Clear();
            txtIDTecnico.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSFX = (int)dGVSFX.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SFX SET ESTATUS = 0 WHERE idSFX =" + idSFX.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string Tipo = txtTipo.Text;
            string idTecnico = txtIDTecnico.Text;
            int idSFX = (int)dGVSFX.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE SFX SET tipo ='" + Tipo + "',fechaEntrega'" + fecha + "',idTecnico='" + idTecnico + "'WHERE idSFX = " + idSFX.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtTipo.Clear();
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

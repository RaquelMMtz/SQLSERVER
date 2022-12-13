using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class VFX : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public VFX()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM VFX";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "VFX");
            conexion.Close();
            dGVVFX.DataSource = ds.Tables["VFX"];
        }
        private void VFX_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fechaEntrega = txtFecha.Text;
            string Tipo = txtTipo.Text;
            consulta = "INSERT INTO VFX (fechaEntrega,tipo) values ('" + fechaEntrega + "','" + Tipo + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtTipo.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idVFX = (int)dGVVFX.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE VFX SET ESTATUS = 0 WHERE idVFX =" + idVFX.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fechaEntrega = txtFecha.Text;
            string Tipo = txtTipo.Text;
            int idVFX = (int)dGVVFX.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE VFX SET fechaEntrega ='" + fechaEntrega + "',tipo='" + Tipo + "'WHERE idVFX = " + idVFX.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtTipo.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

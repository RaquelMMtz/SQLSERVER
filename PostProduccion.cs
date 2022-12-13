using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class PostProduccion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public PostProduccion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM PostProduccion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "PostProduccion");
            conexion.Close();
            dGVPostP.DataSource = ds.Tables["PostProduccion"];
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fechaEntrega =txtFecha.Text;
            string CorreccionF = txtCF.Text;
            consulta = "INSERT INTO PostProduccion (fecha,CorreccionFinal) values ('" + fechaEntrega + "','" + CorreccionF + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtFecha.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idPostProduccion = (int)dGVPostP.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE PostProduccion SET ESTATUS = 0 WHERE idPostProduccion =" + idPostProduccion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string fechaEntrega = txtFecha.Text;
            string CorreccionF = txtCF.Text;
            int idPostProduccion = (int)dGVPostP.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE PostProduccion SET fechaEntrega ='" + fechaEntrega + "',correccionFinal='" + CorreccionF + "'WHERE idPostProduccion = " + idPostProduccion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtFecha.Clear();
        }

            private void button4_Click(object sender, EventArgs e)
           {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }

        private void PostProduccion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
    }
}

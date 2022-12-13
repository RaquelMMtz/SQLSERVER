using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Ingreso : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Ingreso()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Ingreso";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Ingreso");
            conexion.Close();
            dGVIngreso.DataSource = ds.Tables["Ingreso"];
        }
        private void Ingreso_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string ingreso = txtIngreso.Text;
            string descripcion = txtDescripcion.Text;
            consulta = "INSERT INTO Ingreso (ingreso, descripcion) values ('" + ingreso + "','" + descripcion + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIngreso.Clear();
            txtDescripcion.Clear(); 
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idIngreso = (int)dGVIngreso.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Ingreso SET ESTATUS = 0 WHERE idIngreso =" + idIngreso.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string ingreso = txtIngreso.Text;
            string descripcion = txtDescripcion.Text;
            int idIngreso = (int)dGVIngreso.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Ingreso SET ingreso ='" + ingreso + "',descripcion='" + descripcion + "'WHERE idIngreso = " + idIngreso.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIngreso.Clear();
            txtDescripcion.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

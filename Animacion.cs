using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Animacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Animacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Animacion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Animacion");
            conexion.Close();
            dGVAnimacion.DataSource = ds.Tables["Animacion"];
        }
        private void Animacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string fechaEntrega = txtFechaEntrega.Text;
            string idAsistenteAnimacion = txtidASA.Text;
            consulta = "INSERT INTO Animacion (nombre, fechaEntrega, idAsistenteAnimacion) values ('" + nombre + "','" + fechaEntrega + "','" + idAsistenteAnimacion + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtFechaEntrega.Clear();
            txtidASA.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAnimacion = (int)dGVAnimacion.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Animacion SET ESTATUS = 0 WHERE idAnimacion =" + idAnimacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string fechaEntrega = txtFechaEntrega.Text;
            string idAsistenteAnimacion = txtidASA.Text;
            int idAnimacion = (int)dGVAnimacion.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Animacion SET nombre ='" + nombre + "',fechaEntrega='" + fechaEntrega + "',idAsistenteAnimacion'" + idAsistenteAnimacion + "'WHERE idAnimacion = " + idAnimacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtFechaEntrega.Clear();
            txtidASA.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

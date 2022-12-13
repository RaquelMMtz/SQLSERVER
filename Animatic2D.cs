using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Animatic2D : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Animatic2D()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }

        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Animatic2D";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Animatic2D");
            conexion.Close();
            dGridVAnimatic2D.DataSource = ds.Tables["Animatic2D"];

        }
        private void Animatic2D_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fechaEntrega = txtfechaEntrega.Text;
            string personaje = txtPersonaje.Text;
            consulta = "INSERT INTO Animatic2D (fechaEntrega,personaje) values ('" + fechaEntrega + "','" + personaje + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtfechaEntrega.Clear();
            txtPersonaje.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idAnimaticD = (int)dGridVAnimatic2D.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Animatic2D SET ESTATUS = 0 WHERE idAnimatic2D =" + idAnimaticD.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fechaEntrega = txtfechaEntrega.Text;
            string personaje = txtPersonaje.Text;
            int idAnimatic2D = (int)dGridVAnimatic2D.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Animatic2D SET fechaEntrega ='" + fechaEntrega + "',personaje ='" + personaje + "','" + "'WHERE idAnimatic2D = " + idAnimatic2D.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPersonaje.Clear();
            txtfechaEntrega.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

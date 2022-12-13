using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class CorreccionColor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public CorreccionColor()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM CorreccionColor";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "CorreccionColor");
            conexion.Close();
            dGVCC.DataSource = ds.Tables["CorreccionColor"];
        }

        private void CorreccionColor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string fecha = txtFecha.Text;
            string idTecnico = txtIDTecnico.Text;
            consulta = "INSERT INTO ColeccionColor (descripcion, fecha, idTecnico) values ('" + descripcion + "','" + fecha + "','" + idTecnico + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
           txtDescripcion.Clear();
            txtFecha.Clear();
            txtIDTecnico.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idColeccionColor = (int)dGVCC.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ColeccionColor SET ESTATUS = 0 WHERE idColeccionColor =" + idColeccionColor.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string fecha = txtFecha.Text;
            string idTecnico = txtIDTecnico.Text;
            int idColeccionColor = (int)dGVCC.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE ColeccionColor SET descripcion ='" + descripcion + "',fechaEntrega='" + fecha + "',idTecnico='" + idTecnico + "'WHERE idColeccionColor = " + idColeccionColor.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtFecha.Clear();
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

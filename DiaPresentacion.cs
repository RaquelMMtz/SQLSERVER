using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class DiaPresentacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public DiaPresentacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM DiaPresentacion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "DiaPresentacion");
            conexion.Close();
            dGVDP.DataSource = ds.Tables["DiaPresentacion"];
        }
        private void DiaPresentacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcion.Text;
            string fecha = txtFecha.Text;
            string idJuntaDirectiva = txtIDJD.Text;
            consulta = "INSERT INTO DiaPresentacion (descripcion, fecha, id) values ('" + descripcion + "','" + fecha + "','" + idJuntaDirectiva + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtFecha.Clear();
            txtIDJD.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idDiaPresentacion = (int)dGVDP.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DiaPresentacion SET ESTATUS = 0 WHERE idDiaPresentacion =" + idDiaPresentacion.ToString();
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
            string idJuntaDirectiva = txtIDJD.Text;
            int idDiaPresentacion = (int)dGVDP.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE DiaPresentacion SET descripcion ='" + descripcion + "',fecha='" + fecha + "',idJuntaDirectiva='" + idJuntaDirectiva + "'WHERE idDiaPresentacion = " + idDiaPresentacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtDescripcion.Clear();
            txtFecha.Clear();
            txtIDJD.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

  

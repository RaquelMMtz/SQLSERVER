using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class LayoutTecnico : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public LayoutTecnico()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM LayoutTecnico";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "LayoutTecnico");
            conexion.Close();
            dGVLT.DataSource = ds.Tables["LayoutTecnico"];
        }
        private void LayoutTecnico_Load(object sender, EventArgs e)
        {
            MostrarDatos ();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Layout = txtIDL.Text;
            string Tecnico = txtIDT.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO LayoutTecnico (idLayout, idTecnico, numIntegrantes) values ('" + Layout + "','" + Tecnico + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDL.Clear();
            txtIDT.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idLayoutTecnico = (int)dGVLT.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE LayoutTecnico SET ESTATUS = 0 WHERE idLayoutTecnico =" + idLayoutTecnico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Layout = txtIDL.Text;
            string Tecnico = txtIDT.Text;
            string numInt = txtNumIn.Text;
            int idLayoutTecnico = (int)dGVLT.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE LayoutTecnico SET idLayout ='" + Layout + "',idTecnico='" + Tecnico + "',numIntegrantes='" + numInt + "'WHERE idLayoutTecnico = " + idLayoutTecnico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDL.Clear();
            txtIDT.Clear();
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

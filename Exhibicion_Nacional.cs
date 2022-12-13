using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Exhibicion_Nacional : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Exhibicion_Nacional()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ExhibicionNacional ";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ExhibicionNacional");
            conexion.Close();
            dGVExNa.DataSource = ds.Tables["ExhibicionNacional"];
        }
        private void Exhibicion_Nacional_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string calle = txtC.Text;
            string numero = txtNum.Text;
            string colonia = txtCol.Text;
            string ciudad = txtCiu.Text;
            string cp = txtCP.Text;
            string idGerente = txtIDG.Text;
            consulta = "INSERT INTO ExhibicionNacional (fecha, calle, numero, colonia, ciudad, codigoPostal, idGerente) values ('" + fecha + "','" + calle + "','" + numero + "','" + colonia + "','" + ciudad + "','" + cp + "','" + idGerente + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtC.Clear();
            txtNum.Clear();
            txtCol.Clear();
            txtCiu.Clear();
            txtCP.Clear();
            txtIDG.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idExhibicionNacional = (int)dGVExNa.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ExhibicionNacional SET ESTATUS = 0 WHERE idExhibicionNacional =" + idExhibicionNacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string calle = txtC.Text;
            string numero = txtNum.Text;
            string colonia = txtCol.Text;
            string ciudad = txtCiu.Text;
            string cp = txtCP.Text;
            string idGerente = txtIDG.Text;
            int idExhibicionNacional = (int)dGVExNa.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE ExhibicionNacional SET fecha ='" + fecha + "',calle='" + calle + "',numero='" + numero + "',colonia='" + colonia + "',ciudad='" + ciudad + "',codigoPostal='" + cp + "',idGerente='" + idGerente + "'WHERE idExhibicionNacional = " + idExhibicionNacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtC.Clear();
            txtNum.Clear();
            txtCol.Clear();
            txtCiu.Clear();
            txtCP.Clear();
            txtIDG.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Texturizado : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Texturizado()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Texturizado";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Texturizado");
            conexion.Close();
            dGVTex.DataSource = ds.Tables["Texturizado"];
        }
        private void Texturizado_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string Tipo = txtTipo.Text;
            string idTecnico = txtIDTecnico.Text;
            consulta = "INSERT INTO Txturizado (tipo, fechaEntrega, idTecnico) values ('" + Tipo + "','" + fecha + "','" + idTecnico + "')";
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
            int idTexturizado = (int)dGVTex.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Texturizado SET ESTATUS = 0 WHERE idTexturizado =" + idTexturizado.ToString();
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
            int idTexturizado = (int)dGVTex.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Texturizado SET tipo ='" + Tipo + "',fechaEntrega='" + fecha + "',idTecnico='" + idTecnico + "'WHERE idTexturizado = " + idTexturizado.ToString();
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

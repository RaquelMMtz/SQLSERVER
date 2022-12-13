using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Rediseño : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Rediseño()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Rediseño";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Rediseño");
            conexion.Close();
            dGVRD.DataSource = ds.Tables["Rediseño"];
        }
        private void dGVRD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string PRD =txtPRD.Text;
            string SRD = txtSRD.Text;
            string idDirector = txtIDD.Text;
            consulta = "INSERT INTO Rediseño (primerRediseño, segundoRediseño, idDirector) values ('" + PRD + "','" + SRD + "','" + idDirector + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPRD.Clear();
            txtSRD.Clear();
            txtIDD.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idRediseño = (int)dGVRD.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Redsieño SET ESTATUS = 0 WHERE idRediseño =" + idRediseño.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string PRD = txtPRD.Text;
            string SRD = txtSRD.Text;
            string idDirector = txtIDD.Text;
            int idRediseño = (int)dGVRD.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Rediseño SET primerRediseño ='" + PRD + "',segundoRediseño='" + SRD + "',idDirector='" + idDirector + "'WHERE idRediseño = " + idRediseño.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            MostrarDatos();
            txtPRD.Clear();
            txtSRD.Clear();
            txtIDD.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

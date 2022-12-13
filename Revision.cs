using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Revision : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Revision()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Revision";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Revision");
            conexion.Close();
            dGVR.DataSource = ds.Tables["Revision"];
        }
        private void Revision_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string PR = txtPR.Text;
            string SR = txtSR.Text;
            string idDirector = txtIDD.Text;
            consulta = "INSERT INTO Rediseño (primeraRevision, segundaRevision, idDirector) values ('" + PR + "','" + SR + "','" + idDirector + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtPR.Clear();
            txtSR.Clear();
            txtIDD.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idRevision = (int)dGVR.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Revision SET ESTATUS = 0 WHERE idRevision =" + idRevision.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string PR = txtPR.Text;
            string SR = txtSR.Text;
            string idDirector = txtIDD.Text;
            int idRevision = (int)dGVR.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Revision SET primeraRevision ='" + PR + "',segundRevision='" + SR + "',idDirector='" + idDirector + "'WHERE idRevision = " + idRevision.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            MostrarDatos();
            txtPR.Clear();
            txtSR.Clear();
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

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class ActorGrabacionVoz : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ActorGrabacionVoz()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ActorGrabacionVoz";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ActorGrabacionVoz");
            conexion.Close();
            dGVAGV.DataSource = ds.Tables["ActorGrabacionVoz"];
        }
        private void ActorGrabacionVoz_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Actor = txtIDA.Text;
            string GrabacionVoz = txtIDGV.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO ActorGrabacionVoz (idActor, idGrabacionVoz, numIntegrantes) values ('" + Actor + "','" + GrabacionVoz + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDA.Clear();
            txtIDGV.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idActorGrabacionVoz = (int)dGVAGV.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ActorGrabacionVoz SET ESTATUS = 0 WHERE idActorGrabacionVoz =" + idActorGrabacionVoz.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Actor = txtIDA.Text;
            string GrabacionVoz = txtIDGV.Text;
            string numInt = txtNumIn.Text;
            int idActorGrabacionVoz = (int)dGVAGV.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE ActorGrabacionVoz SET idActor ='" + Actor + "',idGrabacionVoz= '" + GrabacionVoz + "', numIntegrantes'" + numInt + "'WHERE idActorGrabacionVoz = " + idActorGrabacionVoz.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDA.Clear();
            txtIDGV.Clear();
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

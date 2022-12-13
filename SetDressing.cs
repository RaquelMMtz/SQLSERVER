using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class SetDressing : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public SetDressing()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM SetDrssing";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "SetDressing");
            conexion.Close();
            dGVSD.DataSource = ds.Tables["SetDressing"];
        }
        private void SetDressing_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string idFondista = txtIDF.Text;
            consulta = "INSERT INTO SetDressing (fechaEntrega, idFondista) values ('" + fecha + "','" + idFondista + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtIDF.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idSetDressing = (int)dGVSD.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SetDressing SET ESTATUS = 0 WHERE idSetDressing =" + idSetDressing.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string idFondista = txtIDF.Text;
            int idSetDressing = (int)dGVSD.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE SetDressing SET fechaEntrega ='" + fecha + "',idFondista='" + idFondista + "'WHERE idSetDressing = " + idSetDressing.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtIDF.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class MattePainting : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public MattePainting()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MattePainting";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MattePainting");
            conexion.Close();
            dGVMP.DataSource = ds.Tables["MattePainting"];
        }
        private void MattePainting_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string idFondista = txtIDFondista.Text;
            consulta = "INSERT INTO MattePainting (fechaEntrega, idFondista) values ('" + fecha + "','" + idFondista + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtIDFondista.Clear();
        }
    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMattePainting = (int)dGVMP.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MattePainting SET ESTATUS = 0 WHERE idMattePainting =" + idMattePainting.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string idFondista = txtIDFondista.Text;
            int idMattePainting = (int)dGVMP.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE MattePainting SET fechaEntrega ='" + fecha + "',idFondista='" + idFondista + "'WHERE idMattePainting = " + idMattePainting.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtIDFondista.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

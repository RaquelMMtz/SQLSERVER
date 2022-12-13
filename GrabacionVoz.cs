﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class GrabacionVoz : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public GrabacionVoz()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM GrabacionVoz";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "GrabacionVoz");
            conexion.Close();
            dGVGV.DataSource = ds.Tables["GrabacionVoz"];
        }
        private void GrabacionVoz_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string idTecnico = txtIDTecnico.Text;
            consulta = "INSERT INTO GrabacionVoz (fechaEntrega, idTecnico) values ('" + fecha + "','" + idTecnico + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtIDTecnico.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idGrabacionVoz = (int)dGVGV.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE GrabacionVoz SET ESTATUS = 0 WHERE idGrabacionVoz =" + idGrabacionVoz.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string idTecnico = txtIDTecnico.Text;
            int idGrabacionVoz = (int)dGVGV.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE GrabacionVoz SET fechaEntrega ='" + fecha + "',idTecnico='" + idTecnico + "'WHERE idGrabacionVoz = " + idGrabacionVoz.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
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

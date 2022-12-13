﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Guionista : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Guionista()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Guionista";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Guionista");
            conexion.Close();
            dGVG.DataSource = ds.Tables["Guionista"];
        }

        private void Guionista_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string ap = txtAP.Text;
            string am = txtAM.Text;
            string idGerente = txtidGer.Text;
            consulta = "INSERT INTO Fondista (nombre, apellidoPaterno, apellidoMaterno, idGerente) values ('" + nombre + "','" + ap + "','" + am + "','" + idGerente + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtidGer.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idGuionisa = (int)dGVG.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Guionista SET ESTATUS = 0 WHERE idGuionista =" + idGuionisa.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string ap = txtAP.Text;
            string am = txtAM.Text;
            string idGerente = txtidGer.Text;
            int idGuionista = (int)dGVG.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Guionista SET nombre ='" + nombre + "',apellidoPaterno='" + ap + "',apellidoMaterno='" + am + "',idGerente='" + idGerente + "'WHERE idGuionista = " + idGuionista.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtidGer.Clear();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

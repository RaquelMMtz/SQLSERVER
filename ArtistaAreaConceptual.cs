﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class ArtistaAreaConceptual : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ArtistaAreaConceptual()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ArtistaAreaConceptual";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ArtistaAreaConceptual");
            conexion.Close();
            dGVAAC.DataSource = ds.Tables["ArtistaAreaConceptual"];
        }

        private void ArtistaAreaConceptual_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Artista = txtIDART.Text;
            string AreaConceptual = txtIDAC.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO ArtistaAreaConceptual (idArtista, idAreaConceptual, numIntegrantes) values ('" + Artista + "','" + AreaConceptual + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDART.Clear();
            txtIDAC.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idArtistaAreaConceptual = (int)dGVAAC.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ArtistaAreaConceptual SET ESTATUS = 0 WHERE idArtistaAreaConceptual =" + idArtistaAreaConceptual.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Artista = txtIDART.Text;
            string AreaConceptual = txtIDAC.Text;
            string numInt = txtNumIn.Text;
            int idArtistaAreaConceptual = (int)dGVAAC.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE ArtistaAreaConceptual SET idArtista ='" + Artista + "',idArteConceptual='" + AreaConceptual + "',numIntegrantes='" + numInt + "'WHERE idArtistaAreaConceptual = " + idArtistaAreaConceptual.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDART.Clear();
            txtIDAC.Clear();
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

﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class MusicaMusico : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public MusicaMusico()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM MusicaMusico";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "MusicaMusico");
            conexion.Close();
            dGVMM.DataSource = ds.Tables["MusicaMusico"];
        }
        private void MusicaMusico_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string Musica = txtIDM.Text;
            string Musico = txtIDMu.Text;
            string numInt = txtNumIn.Text;
            consulta = "INSERT INTO MusicaMusico (idMusica, idMusico, numIntegrantes) values ('" + Musica + "','" + Musico + "','" + numInt + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDM.Clear();
            txtIDMu.Clear();
            txtNumIn.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMusicaMusico = (int)dGVMM.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE MusicaMusico SET ESTATUS = 0 WHERE idAMusicaMusico =" + idMusicaMusico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string Musica = txtIDM.Text;
            string Musico = txtIDMu.Text;
            string numInt = txtNumIn.Text;
            int idMusicaMusico = (int)dGVMM.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE MusicaMusico SET idMusica ='" + Musica + "',idMusico='" + Musico + "',numIntegrantes='" + numInt + "'WHERE idMusicaMusico = " + idMusicaMusico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtIDM.Clear();
            txtIDMu.Clear();
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

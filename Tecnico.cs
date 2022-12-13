﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Tecnico : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Tecnico()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Tecnico";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Tecnico");
            conexion.Close();
            dGVTecnico.DataSource = ds.Tables["Tecnico"];
        }
        private void Tecnico_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string ap = txtAP.Text;
            string am = txtAM.Text;
            string especializacion = txtEspe.Text;
            string idDirectorr = txtidD.Text;
            consulta = "INSERT INTO Tecnico (nombre, apellidoPaterno, apellidoMaterno, especializacion, idDirector) values ('" + nombre + "','" + ap + "','" + am + "','" + especializacion + "','" + idDirectorr + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtidD.Clear();
            txtEspe.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idTecnico = (int)dGVTecnico.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Tecnico SET ESTATUS = 0 WHERE idTecnico =" + idTecnico.ToString();
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
            string especializacion = txtEspe.Text;
            string idDirector = txtidD.Text;
            int idTecnico = (int)dGVTecnico.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Tecnico SET nombre ='" + nombre + "',apellidoPaterno='" + ap + "',apellidoMaterno='" + am + "',especializacion='" + especializacion + "',idDirector='" + idDirector + "'WHERE idTecnico = " + idTecnico.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtNombre.Clear();
            txtAP.Clear();
            txtAM.Clear();
            txtidD.Clear();
            txtEspe.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

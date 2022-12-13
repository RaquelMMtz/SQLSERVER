﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Masterizacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Masterizacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM Masterizacion";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "Masterizacion");
            conexion.Close();
            dGVMas.DataSource = ds.Tables["Masterizacion"];
        }
        private void Masterizacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string tipoAudio = txtTAu.Text;
            string idTecnico = txtIDTecnico.Text;
            consulta = "INSERT INTO Masterizacin (fechaEntrega, tipoAudio, idTecnico) values ('" + fecha + "','" + tipoAudio + "','" + idTecnico + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtTAu.Clear();
            txtIDTecnico.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idMasterizacion = (int)dGVMas.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Masterizacion SET ESTATUS = 0 WHERE idMasterizacion =" + idMasterizacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            string fecha = txtFecha.Text;
            string tipoAudio = txtTAu.Text;
            string idTecnico = txtIDTecnico.Text;
            int idMasterizacion = (int)dGVMas.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE Masterizacion SET fechaEntrega ='" + fecha + "',tipoAudio='" + tipoAudio + "',idTecnico='" + idTecnico + "'WHERE idMasterizacion = " + idMasterizacion.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtTAu.Clear();
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

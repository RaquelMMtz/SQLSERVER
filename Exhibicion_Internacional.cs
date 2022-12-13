﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalSQLSERVER
{
    public partial class Exhibicion_Internacional : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Exhibicion_Internacional()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=EstudiodeAnimacion;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
        }
        private void MostrarDatos()
        {
            consulta = "SELECT * FROM ExhibicionInternacional ";
            conexion.Open();
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, "ExhibicionInternacional");
            conexion.Close();
            dGVExIn.DataSource = ds.Tables["ExhibicionInternacional"];
        }
        private void Exhibicion_Internacional_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha  = txtFecha.Text;
            string calle = txtC.Text;
            string numero = txtNum.Text;
            string colonia = txtCol.Text;
            string ciudad = txtCiu.Text;
            string pais = txtP.Text;
            string idGerente = txtIDG.Text;
            consulta = "INSERT INTO ExhibicionInternacional (fecha, calle, numero, colonia, ciudad, pais, idGerente) values ('" + fecha + "','" + calle + "','" + numero + "','" + colonia + "','" + ciudad + "','" + pais + "','" + idGerente + "')";
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtC.Clear();
            txtNum.Clear();
            txtCol.Clear();
            txtCiu.Clear();
            txtP.Clear();
            txtIDG.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idExhibicionInternacional = (int)dGVExIn.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ExhibicionInternacional SET ESTATUS = 0 WHERE idExhibicionInternacional =" + idExhibicionInternacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string fecha = txtFecha.Text;
            string calle = txtC.Text;
            string numero = txtNum.Text;
            string colonia = txtCol.Text;
            string ciudad = txtCiu.Text;
            string pais = txtP.Text;
            string idGerente = txtIDG.Text;
            int idExhibicionInternacional = (int)dGVExIn.SelectedRows[0].Cells[0].Value;
            consulta = "  UPDATE ExhibicionInternacional SET fecha ='" + fecha + "',calle='" + calle + "',numero='" + numero + "',colonia='" + colonia + "',ciudad='" + ciudad + "',pais='" + pais + "',idGerente='" + idGerente + "'WHERE idExhibicionInternacional = " + idExhibicionInternacional.ToString();
            conexion.Open();
            comando = new SqlCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            MostrarDatos();
            txtFecha.Clear();
            txtC.Clear();
            txtNum.Clear();
            txtCol.Clear();
            txtCiu.Clear();
            txtP.Clear();
            txtIDG.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form1 frm = new Form1();

            frm.Show();
        }
    }
}

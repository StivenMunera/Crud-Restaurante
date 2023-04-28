using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CrudRestau
{
    public partial class Form1 : Form
    {
        cConexion cn;
        //Guardela consulta en una tabla
        DataTable dt = new DataTable();
        // Creamos  elementos 1 dataadapter
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
            cn = new cConexion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {   //Llamamos el procedimiento almacenado
            SqlCommand cmd = new SqlCommand("nuevo_empleado",cn.AbrirConexion());
            // le decimos a la variable que es tipo procedimiento
            cmd.CommandType = CommandType.StoredProcedure;
            //le mandamos cada uno de los parametros al procedimiento
            cmd.Parameters.AddWithValue("@id_empleado", txtIdEm.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
            cmd.Parameters.AddWithValue("@salario", Convert.ToInt32( txtSalario.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente Creado");
            cn.CerrarConexion();

        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
           
            //Llamamos el procedimiento almacenado
            SqlCommand cmd = new SqlCommand("consulta_Empleado", cn.AbrirConexion());
            // le decimos a la variable que es tipo procedimiento
            cmd.CommandType = CommandType.StoredProcedure;
            //le mandamos cada uno de los parametros al procedimiento
            cmd.Parameters.AddWithValue("@id_empleado", txtIdEm.Text);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            txtNombre.Text = dt.Rows[0][1].ToString();
            txtApellido.Text = dt.Rows[0][2].ToString();
            txtSalario.Text = dt.Rows[0][3].ToString();
            MessageBox.Show("Cliente Consultado");
            cn.CerrarConexion();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Llamamos el procedimiento almacenado
            SqlCommand cmd = new SqlCommand("modificar_Empleado", cn.AbrirConexion());
            // le decimos a la variable que es tipo procedimiento
            cmd.CommandType = CommandType.StoredProcedure;
            //le mandamos cada uno de los parametros al procedimiento
            cmd.Parameters.AddWithValue("@id_empleado", txtIdEm.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text);
            cmd.Parameters.AddWithValue("@salario", Convert.ToInt32(txtSalario.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente Modificado");
            cn.CerrarConexion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Llamamos el procedimiento almacenado
            SqlCommand cmd = new SqlCommand("eliminar_Empleado", cn.AbrirConexion());
            // le decimos a la variable que es tipo procedimiento
            cmd.CommandType = CommandType.StoredProcedure;
            //le mandamos cada uno de los parametros al procedimiento
            cmd.Parameters.AddWithValue("@id_empleado", txtIdEm.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Cliente Eliminado");
            cn.CerrarConexion();
        }

        private void btnConsultat_Click(object sender, EventArgs e)
        {
            //Llamamos el procedimiento almacenado
            SqlCommand cmd = new SqlCommand("consulta_todo", cn.AbrirConexion());
            // le decimos a la variable que es tipo procedimiento
            cmd.CommandType = CommandType.StoredProcedure;
            //le mandamos cada uno de los parametros al procedimiento
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dtgClientes.DataSource = dt;
            MessageBox.Show("Muestro todos los clientes");
            cn.CerrarConexion();

        }
    }
}

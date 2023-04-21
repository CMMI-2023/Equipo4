using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class Form_ajuste_cliente : Form
    {
        string idSel = " ";
        MySqlConnection myCon;
        public Form_ajuste_cliente()
        {
            InitializeComponent();
        }
         public void conectar()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "012345678";
            string bd = "sistema_usuarios";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;
            myCon = new MySqlConnection(cadenaConexion);
            myCon.Open();
            
        }

        private void llenartabla()
        {
            string query = " select id_cliente,Nombre,Apellido_PaternoCliente,Apellido_MaternoCliente,Domicilio_cliente from cliente;";
            MySqlCommand comandoDB =  new MySqlCommand(query,myCon);
            comandoDB.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                reader = comandoDB.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int n = dataGridView1.Rows.Add();
                        dataGridView1.Rows[n].Cells[0].Value = reader.GetString(0);
                        dataGridView1.Rows[n].Cells[1].Value = reader.GetString(1);
                        dataGridView1.Rows[n].Cells[2].Value = reader.GetString(2);
                        dataGridView1.Rows[n].Cells[3].Value = reader.GetString(3);
                        dataGridView1.Rows[n].Cells[4].Value = reader.GetString(4);
                    }
                }
                else
                {
                    Console.WriteLine("no hay clientes");
                }
                reader.Close();
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
        }
        private void Form_ajuste_cliente_Load(object sender, EventArgs e)
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "012345678";
            string bd = "sistema_usuarios";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;


            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            MySqlConnection co;
          
            DataTable data = new DataTable();
          
            MySqlDataReader res;

            try
            {
                co = new MySqlConnection(cadenaConexion);
                MySqlCommand comando = new MySqlCommand("SELECT * FROM cliente;", co);
                comando.CommandType = CommandType.Text;
                co.Open();
                res = comando.ExecuteReader();
                data.Load(res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sel = e.RowIndex;
            txt_id_cliente.Text = dataGridView1.Rows[sel].Cells[0].Value.ToString();
            txt_nombre_cliente.Text = dataGridView1.Rows[sel].Cells[1].Value.ToString();
            txt_apellidop_cliente.Text = dataGridView1.Rows[sel].Cells[2].Value.ToString();
            txt_apellidom_cliente.Text = dataGridView1.Rows[sel].Cells[3].Value.ToString();
            txt_domicilio_cliente.Text = dataGridView1.Rows[sel].Cells[4].Value.ToString();
            idSel = dataGridView1.Rows[sel].Cells[0].Value.ToString();
        }

        private void btn_editar_cliente_Click(object sender, EventArgs e)
        {
            string query = " ";
            string mesajeError = " ";

            if (txt_nombre_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El nombre no puede estar vacio";
            }
            if (txt_apellidop_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El apellido paterno no puede estar vacio";
            }
            if (txt_apellidom_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El apellido materno no puede estar vacio";
            }
            if (txt_domicilio_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El domicilio no puede estar vacio";
            }
            if (mesajeError == " ")
            {
                query = "update cliente set" +
                   "Nombre = '" + txt_nombre_cliente + "'," +
                    "Apellido_PaternoCliente = '" + txt_apellidop_cliente + "'," +
                     "Apellido_MaternoCliente = '" + txt_apellidom_cliente + "'" +
                      "Domicilio_cliente = '" + txt_domicilio_cliente +
                      "where id_cliente = '" + idSel + "';"; 

                MySqlCommand comando = new MySqlCommand(query,myCon);
                comando.CommandTimeout = 60;
                MySqlDataReader reader;
                try
                {
                    reader = comando.ExecuteReader();
                    reader.Close();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    llenartabla();
                }
                catch(Exception ex)
                {
                   Console.WriteLine(ex);
                }
            }
            else
            {
                MessageBox.Show(mesajeError);
            }
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {

            string query = "";
            string mesajeError = " ";

            if (txt_nombre_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El nombre no puede estar vacio";
            }
            if (txt_apellidop_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El apellido paterno no puede estar vacio";
            }
            if (txt_apellidom_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El apellido materno no puede estar vacio";
            }
            if (txt_domicilio_cliente.Text == " ")
            {
                mesajeError = mesajeError + "El domicilio no puede estar vacio";
            }
            if (mesajeError == " ")
            {
                query = "insert into cliente" +
                    "(id_cliente ,Nombre ,Apellido_PaternoCliente ,Apellido_MaternoCliente ,Domicilio_cliente) values" +
                    "('" + txt_id_cliente.Text+ "','" + txt_nombre_cliente.Text + "','" + txt_apellidop_cliente.Text + "','" + txt_apellidom_cliente + "','" + txt_domicilio_cliente + "')";

                MySqlCommand comando = new MySqlCommand(query,myCon);
                comando.CommandTimeout = 60;
                MySqlDataReader reader;
                try
                {
                    reader = comando.ExecuteReader();
                    reader.Close();
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    llenartabla();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                MessageBox.Show("ocurrio error");
            }
        }
    }
}

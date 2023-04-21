using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            txtNombre.Text = Session.nombre;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "012345678";
            string bd = "sistema_usuarios";

            string cadenaConexion = "server=" + servidor + "; port=" + puerto + "; user id=" + usuario + "; password=" + password + "; database=" + bd;


            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

            MySqlConnection co;
            MySqlConnection comand;
            DataTable data = new DataTable();
            DataTable datados = new DataTable();
            MySqlDataReader res;
            MySqlDataReader resp;

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

            try
            {
                comand = new MySqlConnection(cadenaConexion);
                MySqlCommand com = new MySqlCommand("SELECT * FROM veichulo;", comand);
                com.CommandType = CommandType.Text;
                comand.Open();
                resp = com.ExecuteReader();
                datados.Load(resp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView2.DataSource = datados;

        }

        private void btn_Editar_Cliente_Click(object sender, EventArgs e)
        {
            Form_ajuste_cliente frmcliente = new Form_ajuste_cliente();
            frmcliente.Visible = true;
            this.Visible = false;
        }
    }
}

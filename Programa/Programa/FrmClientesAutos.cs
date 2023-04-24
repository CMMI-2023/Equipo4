using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa
{
    public partial class FrmClientesAutos : Form
    {
        MySQLConnector connector = new MySQLConnector();

        public FrmClientesAutos()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Dictionary<string, object>[] clientes = connector.Select("clientes");
            for (int i = 0; i < clientes.Length; i++)
            {
                comboBox1.Items.Add(clientes[i]["nombre"].ToString());
            }
        }
        public string clienteAutoSelecionado
        {
            get { return comboBox1.SelectedItem.ToString() + "-" + comboBox2.SelectedItem.ToString();}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nombreClienteSeleccionado = comboBox1.SelectedItem.ToString();

            Dictionary<string, object>[] vehiculos = connector.Select("vehiculos");
            Dictionary<string, object>[] clientes = connector.Select("clientes");

            int idClienteSeleccionado = Convert.ToInt32(clientes.First(c => c["nombre"].ToString() == nombreClienteSeleccionado)["id"]);


            comboBox2.Items.Clear(); // limpiar los items anteriores
            foreach (var vehiculo in vehiculos)
            {
                if (Convert.ToInt32(vehiculo["cliente_id"]) == idClienteSeleccionado)
                {
                    comboBox2.Items.Add(vehiculo["nombre"].ToString());
                }
            }


            comboBox2.Enabled = true;
        }
    }
}

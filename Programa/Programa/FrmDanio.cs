using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Programa
{
    public partial class FrmDanio : Form
    {
        MySQLConnector connector = new MySQLConnector();
        public FrmDanio()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Dictionary<string, object>[] clientes = connector.Select("danio");
            for (int i = 0; i < clientes.Length; i++)
            {
                comboBox1.Items.Add(clientes[i]["tipo"].ToString());
            }
        }

        public string danioSelecionado
        {
            get { return comboBox1.SelectedItem.ToString(); } 
        }

        private void FrmDanio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

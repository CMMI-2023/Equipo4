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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string password = textBox2.Text;

            MySQLConnector db = new MySQLConnector();
            Dictionary<string, object>[] rows = db.Select("usuarios");

            Dictionary<string, object> user = null;
            foreach (Dictionary<string, object> row in rows)
            {
                bool match = true;
                foreach (KeyValuePair<string, object> kvp in row)
                {
                    if (kvp.Key == "tipo" && (string)kvp.Value != usuario)
                    {
                        match = false;
                        break;
                    }
                    if (kvp.Key == "contrasena" && (string)kvp.Value != password)
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    user = row;
                    break;
                }
            }

            if (user != null)
            {
                // Usuario válido, redirige a la página principal
                MessageBox.Show("Inicio de sesión exitoso");

                // Verifica el tipo de usuario y abre el formulario correspondiente
                if ((string)user["tipo"] == "ajustador")
                {
                    FormAjustador formAjustador = new FormAjustador();
                    formAjustador.Show();
                }
                else if ((string)user["tipo"] == "administrador")
                {
                    FormAdministrador formAdministrador = new FormAdministrador();
                    formAdministrador.Show();
                }
                else
                {
                    MessageBox.Show("Tipo de usuario no reconocido");
                }
            }
            else
            {
                // Usuario inválido, muestra mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}

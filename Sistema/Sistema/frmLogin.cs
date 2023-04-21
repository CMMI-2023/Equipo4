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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            try
            {
                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usuario, password);
                if(respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    if(usuario == "admin") {
                    frmPrincipal frm = new frmPrincipal();
                    frm.Visible = true;
                    this.Visible = false;
                    }
                    if(usuario == "ajustador")
                    {
                        Form2 frm2 = new Form2();
                        frm2.Visible = true;
                        this.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       // private void button1_Click(object sender, EventArgs e)
        //{
            // frmRegistro frmr = new frmRegistro();
            //frmr.Visible = true;
        //}
    }
}

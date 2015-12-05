using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Game1.DAO;

namespace Game1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DAO_Usuario.Instancia.Buscar_Usuario(txt_Usuario.Text, txt_Password.Text) > 0)
                {
                    MessageBox.Show("Bienvenido " + Global_Usuario.Instance.getUsuario());
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex + "", "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
            }

            //this.Dispose();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

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
    public partial class Frm_Pregunta : Form
    {   
        String puzzle1;
        int idpuzzle1;
        public Frm_Pregunta(string puzzle,int idpuzzle)
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("../Release/Content/Puzzles/"+puzzle+".png");
            Global_Resolviendo.Instance.setEstado(1);
            puzzle1 = puzzle;
            idpuzzle1 = idpuzzle;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(DAO_Pregunta.Instancia.enviar_pregunta(textBox1.Text,puzzle1,idpuzzle1,Global_Usuario.Instance.getid())>0)
                {   
                   MessageBox.Show("Respuesta Correcta!!", "Wuuu",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Asterisk,
                   MessageBoxDefaultButton.Button1);
                   Global_Resolviendo.Instance.setEstado(0);
                   this.Dispose();
                }
                else
                {
                   MessageBox.Show("Respuesta Incorrecta :c ", "Sigue intentando",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                
               MessageBox.Show(ex + "", "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error,
               MessageBoxDefaultButton.Button1);
          
            }
        }

        private void Frm_Pregunta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global_Resolviendo.Instance.setEstado(0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

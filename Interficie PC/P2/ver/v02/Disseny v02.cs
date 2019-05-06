using TFG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using TFG.ver.v02;

namespace TFG
{
    public partial class Disseny : Form
    {

        public string dadesEnviar;

        public Disseny()
        {
            InitializeComponent();
            //Principal.SerialPortClass.serialPort1.DataReceived += port_DataReceived;
            
        }

        public void button14_Click(object sender, EventArgs e)
        {
            ControlManual controlmanual = new ControlManual();
            controlmanual.ShowDialog();
            Close();
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(listBox1.SelectedIndex+10);
            enviarDades(listBox1.SelectedIndex+10);
            switch (listBox1.SelectedIndex) {
                case 0: //QUADRAT
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                    break;
                case 1: //TRIANGLE
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                    break;
            }
        }

        public void groupBox2_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int formulariDisseny = 2;
            int figura = listBox1.SelectedIndex;
            string dadesEnviar = Convert.ToString(formulariDisseny + "," + figura);

  

            label6.Text = dadesEnviar;
        }
        

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void enviarDades(int figura)
        {
            try
            {

                dadesEnviar = 2 + "," + figura;
                Principal.SerialPortClass.serialPort1.Write(dadesEnviar);
                Principal.SerialPortClass.serialPort1.Write("\n");
            }
            catch
            {
                MessageBox.Show("No s'ha pogut enviar, revisa l'apartat de comunicacions");
            }
        }
    }
}

using P2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace TFG
{
    public partial class Disseny : Form
    {
        public Disseny()
        {
            InitializeComponent();

            SerialPortClass.serialPort1.Close();

            if (SerialPortClass.serialPort1.IsOpen == false) {
                SerialPortClass.serialPort1.Open();
            }
            //SerialPortClass.serialPort1.DataReceived += port_DataReceived;

            WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void Disseny_Load(object sender, EventArgs e)
        {

        }



        public void button14_Click(object sender, EventArgs e)
        {
            ControlManual controlmanual = new ControlManual();
            controlmanual.ShowDialog();
            Close();
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(listBox1.SelectedIndex);
            if (listBox1.SelectedIndex == 0)
            {
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
            else if (listBox1.SelectedIndex == 1)
            {
                groupBox2.Visible = false;
                groupBox3.Visible = true;
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

            if (!SerialPortClass.serialPort1.IsOpen) {
                SerialPortClass.serialPort1.Open();
            }
            SerialPortClass.serialPort1.Write(dadesEnviar);

            label6.Text = dadesEnviar;
        }
        

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}

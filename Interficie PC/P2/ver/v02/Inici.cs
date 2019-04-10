
using P2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TFG
{
    public partial class Inici : Form
    {

        public string dato_reciv;


        public Inici()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
            WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;

            if (SerialPortClass.serialPort1.IsOpen)
            {
                
            }
            else
            {
                try
                {
                    SerialPortClass.serialPort1.Open();
                }
                catch
                {
                    MessageBox.Show("No s'ha pogut conectar");
                }
            }

            //SerialPortClass.serialPort1.DataReceived += port_DataReceived;
        }

        //////////public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //////////{
        //////////    label1.Text = SerialPortClass.serialPort1.ReadLine();
        //////////}

        private void Inici_Load(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            ControlManual controlmanual = new ControlManual();
            controlmanual.ShowDialog();
            Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Disseny disseny = new Disseny();
            disseny.ShowDialog();
            Close();
        }
    }
}

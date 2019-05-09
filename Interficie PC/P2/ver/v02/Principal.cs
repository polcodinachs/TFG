using System;
using System.IO.Ports;
using System.Windows.Forms;
namespace TFG.ver.v02
{
    public partial class Principal : Form
    {
        public static string portName;

        public static class SerialPortClass
        {
            public static SerialPort serialPort1 { get; set; } = new SerialPort(portName);
        }

        public Principal()
        {
            InitializeComponent();
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem2.Enabled = false;

            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }            
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ControlManual newMDIChild = new ControlManual();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            toolStripMenuItem1.Enabled = false;
            toolStripMenuItem2.Enabled = true;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Disseny newMDIChild = new Disseny();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            toolStripMenuItem2.Enabled = false;
            toolStripMenuItem1.Enabled = true;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            canvas newMDIChild = new canvas();
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
            toolStripMenuItem2.Enabled = true;
            toolStripMenuItem1.Enabled = true;
        }

        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            portName = comboBox1.Text;
            label1.Text = portName;
        }

        public void button1_Click(object sender, EventArgs e)
        {
            SerialPortClass.serialPort1.Open();
            if (SerialPortClass.serialPort1.IsOpen == true)
            {
                label2.Text = "OK";
                toolStripMenuItem1.Enabled = true;
                toolStripMenuItem2.Enabled = true;
                button1.Enabled = false;
                comboBox1.Enabled = false;
            }
            else
            {
                label2.Text = "Desconnectat";
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}

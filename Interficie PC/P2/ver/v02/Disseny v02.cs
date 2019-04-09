using P2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TFG
{
    public partial class Disseny : Form
    {
        public Disseny()
        {
            InitializeComponent();
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
            ControlManual controlmanual = new ControlManual(Convert.ToString(listBox1.SelectedIndex));
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
            ControlManual controlmanual = new ControlManual(Convert.ToString(listBox1.SelectedIndex));
        }
    }
}

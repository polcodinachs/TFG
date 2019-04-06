
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
    public partial class Inici : Form
    {
        public Inici()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.ShowInTaskbar = false;
        }

        private void Inici_Load(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ControlManual controlmanual = new ControlManual();
            controlmanual.ShowDialog();
            Close();
        }
    }
}

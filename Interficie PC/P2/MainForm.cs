/*
 * Created by SharpDevelop.
 * User: estudiant
 * Date: 14/03/2018
 * Time: 10:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace P2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        public string dato_reciv;
        public string[] namesArray;
        public List<string> namesList;
        public int moviment = 0;
        public double inputVelocitat = 0;
        public string dadesEnviar;

        public MainForm()
		{
			InitializeComponent();
            checkBox1.Checked = true;
			Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }

		}
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			serialPort1.Close();
		}
		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			serialPort1.PortName = comboBox1.Text;
			try
			{
				serialPort1.Open();
			}
			catch 
			{
				MessageBox.Show("Puerto no válido");
				return;
			}
			comboBox1.Enabled = false;
		}
		
		public void SerialPort1DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
		{
            try
            {
                dato_reciv = serialPort1.ReadLine();

                namesArray = dato_reciv.Split(',');

                namesList = new List<string>(namesArray.Length);


                namesList.AddRange(namesArray);
                namesList.Reverse();

                int sizeArray = namesArray.Length;
                int size = namesList.Count;


                //label2.Text = Convert.ToString(size);

                label2.Text = dato_reciv;
                label4.Text = Convert.ToString(namesList[3]); //Sensor
                label6.Text = Convert.ToString(namesList[2]); //Encoder
                int velocitat = Convert.ToInt16(namesList[1]);

                if (velocitat > 100)
                {
                    velocitat = velocitat - 256;
                }

                label8.Text = Convert.ToString(velocitat); //Velocitat

                int posicio = Convert.ToInt16(namesList[2]);

            }
            
            catch
            {
                label14.Text = "NO";
            }
			
        }
		
		void Label3Click(object sender, EventArgs e)
		{
			
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            moviment = 1; //Posicio Inicial
            
            try
            {
                enviarDades(moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            moviment = 2; //Endavant

            try
            {
                enviarDades(moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moviment = 3; //Endarrera

            try
            {
                //serialPort1.Write(Convert.ToString(dadesEnviar));
                enviarDades(moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moviment = 4; //STOP

            try
            {
                //serialPort1.Write(Convert.ToString(dadesEnviar));
                enviarDades(moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                inputVelocitat = Convert.ToDouble(textBox1.Text);
                label12.Text = Convert.ToString(inputVelocitat);
                enviarDades(moviment, inputVelocitat);
            }
            catch
            {
                label12.Text = "Introdueix un valor vàlid";
            }
            
        }

        public void enviarDades(int moviment, double velocitat) {
            dadesEnviar = moviment + "," + velocitat;
            label13.Text = dadesEnviar;
            serialPort1.Write(dadesEnviar);
            serialPort1.Write("\n");
        }

        public void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

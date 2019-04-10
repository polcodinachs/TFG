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

        public string[] numeroMotor;

        public string[] namesArrayA;
        public string[] namesArrayB;
        public string[] namesArrayC;
        public List<string> namesListA;
        public List<string> namesListB;
        public List<string> namesListC;

        public int motor;

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

                dato_reciv = serialPort1.ReadLine();
                numeroMotor = dato_reciv.Split(',');

                label22.Text = numeroMotor[0];

                switch (numeroMotor[0]) {
                    case "1":
                        namesArrayA = numeroMotor;
                        namesListA = new List<string>(namesArrayA.Length);
                        namesListA.AddRange(namesArrayA);
                        namesListA.Reverse();
                        label2.Text = Convert.ToString(namesArrayA[0] + "," + namesArrayA[1] + "," + namesArrayA[2] + "," + namesArrayA[3]);
                        label4.Text = Convert.ToString(namesListA[3]); //Sensor
                        label6.Text = Convert.ToString(namesListA[2]); //Encoder
                        int velocitatA = Convert.ToInt16(namesListA[1]);
                        if (velocitatA > 100) {
                            velocitatA = velocitatA - 256;
                        }
                        label8.Text = Convert.ToString(velocitatA);
                        break;

                    case "2":
                        namesArrayB = numeroMotor;
                        namesListB = new List<string>(namesArrayB.Length);
                        namesListB.AddRange(namesArrayB);
                        namesListB.Reverse();
                        //label21.Text = Convert.ToString(namesArrayB[0] + "," + namesArrayB[1] + "," + namesArrayB[2] + "," + namesArrayB[3]);
                        label20.Text = Convert.ToString(namesListB[1]); //Sensor
                        label18.Text = Convert.ToString(namesListB[2]); //Encoder
                        int velocitatB = Convert.ToInt16(namesListB[1]);
                        if (velocitatB > 100)
                        {
                            velocitatB = velocitatB - 256;
                        }
                        label16.Text = Convert.ToString(velocitatB);
                        break;

                    case "3":
                        namesArrayC = numeroMotor;
                        namesListC = new List<string>(namesArrayC.Length);
                        namesListC.AddRange(namesArrayC);
                        namesListC.Reverse();
                        //label31.Text = Convert.ToString(namesArrayC[0] + "," + namesArrayC[1] + "," + namesArrayC[2] + "," + namesArrayC[3]);
                        int velocitatC = Convert.ToInt16(namesListC[1]);
                        if (velocitatC > 100)
                        {
                            velocitatC = velocitatC - 256;
                        }
                        label26.Text = Convert.ToString(velocitatC);
                        break;
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
            motor = 1;
            try
            {
                enviarDades(motor, moviment, inputVelocitat);
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
            motor = 1;

            try
            {
                enviarDades(motor, moviment, inputVelocitat);
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
            motor = 1;

            try
            {
                //serialPort1.Write(Convert.ToString(dadesEnviar));
                enviarDades(motor, moviment, inputVelocitat);
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
            motor = 1;

            try
            {
                //serialPort1.Write(Convert.ToString(dadesEnviar));
                enviarDades(motor, moviment, inputVelocitat);
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
            motor = 1;
            try
            {
                inputVelocitat = Convert.ToDouble(textBox1.Text);
                label12.Text = Convert.ToString(inputVelocitat);
                enviarDades(motor, moviment, inputVelocitat);
            }
            catch
            {
                label12.Text = "Introdueix un valor vàlid";
            }
            
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            moviment = 1; //Posicio inicial
            motor = 2;

            try
            {
                enviarDades(motor, moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            moviment = 2; //Endavant
            motor = 2;

            try
            {
                enviarDades(motor, moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            moviment = 3; //Endarrera
            motor = 2;

            try
            {
                enviarDades(motor, moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            moviment = 4; //STOP
            motor = 2;

            try
            {
                enviarDades(motor, moviment, inputVelocitat);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void enviarDades(int motor, int moviment, double velocitat)
        {
            dadesEnviar = motor + "," + moviment + "," + velocitat;
            label13.Text = dadesEnviar;
            serialPort1.Write(dadesEnviar);
            serialPort1.Write("\n");
        }
    }
}

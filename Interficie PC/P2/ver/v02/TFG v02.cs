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
    public partial class ControlManual : Form
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
        public double inputVelocitatA = 0;
        public double inputVelocitatB = 0;
        public double inputVelocitatC = 0;
        public string dadesEnviar;

        public ControlManual()
        {
            InitializeComponent();
            checkBox1.Checked = true;
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }

            textBox4.KeyDown += TextBox4_KeyDown;

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

        //LECTURA I INTERPRETACIO DE DADES
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

        //MOTOR A
        private void button1_Click(object sender, EventArgs e)
        {
            moviment = 1; //Posicio Inicial
            motor = 1; //Motor A
            try
            {
                enviarDades(motor, moviment, inputVelocitatA);
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
            motor = 1; //Motor A

            try
            {
                enviarDades(motor, moviment, inputVelocitatA);
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
            motor = 1; //Motor A

            try
            {
                enviarDades(motor, moviment, inputVelocitatA);
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
            motor = 1; //Motor A

            try
            {
                enviarDades(motor, moviment, inputVelocitatA);
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
                inputVelocitatA = Convert.ToDouble(textBox1.Text);
                label12.Text = Convert.ToString(inputVelocitatA);
                enviarDades(motor, moviment, inputVelocitatA);
            }
            catch
            {
                label12.Text = "Introdueix un valor vàlid";
            }
            
        }


        //MOTOR B
        private void button8_Click(object sender, EventArgs e)
        {
            moviment = 1; //Posicio inicial
            motor = 2; //Motor B

            try
            {
                enviarDades(motor, moviment, inputVelocitatB);
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
            motor = 2; //Motor B

            try
            {
                enviarDades(motor, moviment, inputVelocitatB);
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
            motor = 2; //Motor B

            try
            {
                enviarDades(motor, moviment, inputVelocitatB);
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
            motor = 2; //Motor B

            try
            {
                enviarDades(motor, moviment, inputVelocitatB);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            motor = 2;
            try
            {
                inputVelocitatB = Convert.ToDouble(textBox2.Text);
                label11.Text = Convert.ToString(inputVelocitatB);
                enviarDades(motor, moviment, inputVelocitatB);
            }
            catch
            {
                label12.Text = "Introdueix un valor vàlid";
            }
        }


        //MOTOR C
        private void button12_Click(object sender, EventArgs e)
        {
            moviment = 1; //Posicio inicial
            motor = 3; //Motor C

            try
            {
                enviarDades(motor, moviment, inputVelocitatC);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            moviment = 2; //Endavant
            motor = 3; //Motor C

            try
            {
                enviarDades(motor, moviment, inputVelocitatC);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            moviment = 3; //Endarrere
            motor = 3; //Motor C

            try
            {
                enviarDades(motor, moviment, inputVelocitatC);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            moviment = 4; //STOP
            motor = 3; //Motor C

            try
            {
                enviarDades(motor, moviment, inputVelocitatC);
            }
            catch
            {
                MessageBox.Show("Puerto no seleccionado");
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            motor = 3;
            try
            {
                inputVelocitatC = Convert.ToDouble(textBox3.Text);
                label24.Text = Convert.ToString(inputVelocitatC);
                enviarDades(motor, moviment, inputVelocitatC);
            }
            catch
            {
                label24.Text = "Introdueix un valor vàlid";
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Enabled = true;
            }
            else
            {
                textBox3.Enabled = false;
            }
        }

        private void TextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                motor = 1;
                moviment = 3;
                enviarDades(motor, moviment, inputVelocitatA);
            }
            else if (e.KeyCode == Keys.Left) {
                motor = 1;
                moviment = 2;
                enviarDades(motor, moviment, inputVelocitatA);
            }
        }

        private void TextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                motor = 2;
                moviment = 3;
                enviarDades(motor, moviment, inputVelocitatA);
            }
            else if (e.KeyCode == Keys.Down)
            {
                motor = 2;
                moviment = 2;
                enviarDades(motor, moviment, inputVelocitatA);
            }
        }



        public void enviarDades(int motor, int moviment, double velocitat)
        {
            try
            {
                dadesEnviar = motor + "," + moviment + "," + velocitat;
                label13.Text = dadesEnviar;
                serialPort1.Write(dadesEnviar);
                serialPort1.Write("\n");
            }
            catch
            {
                MessageBox.Show("No s'ha pogut enviar, revisa l'apartat de comunicacions");
            }
        }
    }
}

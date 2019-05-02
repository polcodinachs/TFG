using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace TFG.ver.v02
{
    public partial class canvas : Form
    {
        public canvas()
        {
            InitializeComponent();
        }

        public int contadorPunts = 0;
        public int contadorLinies = 0;

        private char mov;

        List<double> puntX = new List<double>();
        List<double> puntY = new List<double>();

        double inicialX, inicialY;

        private void Building_Load(object sender, EventArgs e)
        {

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //x[contador] = Convert.ToInt16(textBox1.Text);
            }
            catch
            {
                //MessageBox.Show("Valor");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //y[contador] = Convert.ToInt16(textBox2.Text);
            }
            catch
            {
                //MessageBox.Show("Valor");
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            inicialX = Convert.ToDouble(textBox3.Text);
            inicialY = Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 3);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                contadorPunts++;
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                puntX.Add(Convert.ToDouble(textBox1.Text));
                puntY.Add(Convert.ToDouble(textBox2.Text));
                contadorPunts++;
                Point point1 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(inicialY));
                Point point2 = new Point(Convert.ToInt32(puntX[contadorPunts]), Convert.ToInt32(puntY[contadorPunts]));
                gObject.DrawLine(blackPen, point1, point2); 
                contadorLinies++;
            }
            else
            {
                puntX.Add(Convert.ToDouble(textBox1.Text));
                puntY.Add(Convert.ToDouble(textBox2.Text));
                Point point1 = new Point(Convert.ToInt32(puntX[contadorPunts - 1]), Convert.ToInt32(puntY[contadorPunts - 1]));
                Point point2 = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                gObject.DrawLine(blackPen, point1, point2);
                contadorPunts++;
                contadorPunts++;
                contadorLinies++;
            }

            //richTextBox1.AppendText(Convert.ToString(puntX[contador]) + "," + Convert.ToString(puntY[contador]) + "\n");

            label1.Text = Convert.ToString(contadorPunts);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //building();
        }

        //public void building() {
        //    for (int j = 0; j <= x.Count; j++) {
        //        if (j != 0) {
        //            int distanciaX = x.ElementAt(j);
        //            int distanciaY = y.ElementAt(j);
        //            if (distanciaX == 0)
        //            {
        //                string mov = "moveMotorTarget(motorB," + distanciaY + ",35);";
        //            }
        //            else if (distanciaY == 0)
        //            {
        //                string mov = "moveMotorTarget(motorA," + distanciaX + ",35);";
        //            }
        //            else if ((distanciaY & distanciaX) > 0)
        //            {
        //                string mov = "moveMotorTarget(motorA," + distanciaX + ", 35);\n moveMotorTarget(motorB," + distanciaY + ", 35);\n";
        //            }
        //        }
        //        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\p.codinachs.la.torre\source\repos\prva\prova", true))
        //        {
        //            file.WriteLine(mov);
        //        }
        //    }
        //}

    }
}

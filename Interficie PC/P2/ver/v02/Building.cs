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
using System.IO;

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

        public string movA, movB;

        List<double> puntX = new List<double>();
        List<double> puntY = new List<double>();

        double inicialX, inicialY;

        private void Building_Load(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();
            
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //AMUNT
        public void button1_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            Pen redPen = new Pen(Color.Red, 3);
            gObject.DrawRectangle(redPen, 100, 100, 500, 500);

            inicialX = Convert.ToDouble(textBox3.Text);
            inicialY = Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                puntX.Add(inicialX);
                puntY.Add(inicialY - Convert.ToDouble(textBox1.Text));
                richTextBox1.AppendText(Convert.ToString(puntX[1]) + "," + Convert.ToString(puntY[1]) + "\n");
                contadorPunts++;
                Point point1 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(inicialY));
                Point point2 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(puntY[contadorPunts]));
                gObject.DrawLine(blackPen, point1, point2); 
                contadorLinies++;
            }
            else
            {
                contadorPunts++;
                puntX.Add(puntX[contadorPunts - 1]);
                puntY.Add(puntY[contadorPunts - 1] - Convert.ToDouble(textBox1.Text));
                Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                gObject.DrawLine(blackPen, point1, point2);
                richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                contadorLinies++;
            }
            label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
            label4.Text = Convert.ToString(contadorPunts);
        }

        //AVALL
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            Pen redPen = new Pen(Color.Red, 3);
            gObject.DrawRectangle(redPen, 100, 100, 500, 500);

            inicialX = Convert.ToDouble(textBox3.Text);
            inicialY = Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                puntX.Add(inicialX);
                puntY.Add(inicialY + Convert.ToDouble(textBox1.Text));
                richTextBox1.AppendText(Convert.ToString(puntX[1]) + "," + Convert.ToString(puntY[1]) + "\n");
                contadorPunts++;
                Point point1 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(inicialY));
                Point point2 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(puntY[contadorPunts]));
                gObject.DrawLine(blackPen, point1, point2);
                contadorLinies++;
            }
            else
            {
                contadorPunts++;
                puntX.Add(puntX[contadorPunts - 1]);
                puntY.Add(puntY[contadorPunts - 1] + Convert.ToDouble(textBox1.Text));
                Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                gObject.DrawLine(blackPen, point1, point2);
                richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                contadorLinies++;
            }
            label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
            label4.Text = Convert.ToString(contadorPunts);
        }

        //DRETA
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            Pen redPen = new Pen(Color.Red, 3);
            gObject.DrawRectangle(redPen, 100, 100, 500, 500);

            inicialX = Convert.ToDouble(textBox3.Text);
            inicialY = Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                puntX.Add(inicialX + Convert.ToDouble(textBox1.Text));
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[1]) + "," + Convert.ToString(puntY[1]) + "\n");
                contadorPunts++;
                Point point1 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(inicialY));
                Point point2 = new Point(Convert.ToInt32(puntX[contadorPunts]), Convert.ToInt32(inicialY));
                gObject.DrawLine(blackPen, point1, point2);
                contadorLinies++;
            }
            else
            {
                contadorPunts++;
                puntX.Add(puntX[contadorPunts - 1] + Convert.ToDouble(textBox1.Text));
                puntY.Add(puntY[contadorPunts - 1]);
                Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                gObject.DrawLine(blackPen, point1, point2);
                richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                contadorLinies++;
            }
            label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
            label4.Text = Convert.ToString(contadorPunts);
        }

        //ESQUERRA
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            Pen redPen = new Pen(Color.Red, 3);
            gObject.DrawRectangle(redPen, 100, 100, 500, 500);

            inicialX = Convert.ToDouble(textBox3.Text);
            inicialY = Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                puntX.Add(inicialX - Convert.ToDouble(textBox1.Text));
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[1]) + "," + Convert.ToString(puntY[1]) + "\n");
                contadorPunts++;
                Point point1 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(inicialY));
                Point point2 = new Point(Convert.ToInt32(puntX[contadorPunts]), Convert.ToInt32(inicialY));
                gObject.DrawLine(blackPen, point1, point2);
                contadorLinies++;
            }
            else
            {
                contadorPunts++;
                puntX.Add(puntX[contadorPunts - 1] - Convert.ToDouble(textBox1.Text));
                puntY.Add(puntY[contadorPunts - 1]);
                Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                gObject.DrawLine(blackPen, point1, point2);
                richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                contadorLinies++;
            }
            label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
            label4.Text = Convert.ToString(contadorPunts);
        }

        //ANGLES
        private void button6_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            Pen redPen = new Pen(Color.Red, 3);
            gObject.DrawRectangle(redPen, 100, 100, 500, 500);

            inicialX = Convert.ToDouble(textBox3.Text);
            inicialY = Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                puntX.Add(inicialX + Convert.ToDouble(textBox2.Text));
                puntY.Add(inicialY - Convert.ToDouble(textBox5.Text));
                richTextBox1.AppendText(Convert.ToString(puntX[1]) + "," + Convert.ToString(puntY[1]) + "\n");
                contadorPunts++;
                Point point1 = new Point(Convert.ToInt32(inicialX), Convert.ToInt32(inicialY));
                Point point2 = new Point(Convert.ToInt32(puntX[contadorPunts]), Convert.ToInt32(puntY[contadorPunts]));
                gObject.DrawLine(blackPen, point1, point2);
                contadorLinies++;
            }
            else
            {
                contadorPunts++;
                puntX.Add(puntX[contadorPunts - 1] + Convert.ToDouble(textBox2.Text));
                puntY.Add(puntY[contadorPunts - 1] - Convert.ToDouble(textBox5.Text));
                Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                gObject.DrawLine(blackPen, point1, point2);
                richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                contadorLinies++;
            }
            label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
            label4.Text = Convert.ToString(contadorPunts);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            building();
        }

        public void building()
        {
            for (int i = 0; i <= puntX.Count - 1; i++)
            {
                double distanciaX = puntX[i];
                double distanciaY = puntY[i] * -1;

                //Posició inicial del punter
                if (i == 0)
                {
                    if (distanciaX == 100 && distanciaY == -600) {
                        distanciaX = 0;
                        distanciaY = 0;
                    }
                    movA = "moveMotorTarget(motorA," + distanciaX + ", 35); \n moveMotorTarget(motorB," + distanciaY + ", 35);\n";
                }
                //Moviments després del primer
                else
                {
                    movA = "moveMotorTarget(motorA," + ((distanciaX - puntX[i - 1])*37/3) + ", 35); \n moveMotorTarget(motorB," + ((distanciaY - puntY[i - 1])*37/3) + ", 35);\n";
                }
              
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"\\Mac\Home\Desktop\TFG Interficies\prova", true))
                {
                    file.WriteLine(movA);
                }
            }
        }

    }
}

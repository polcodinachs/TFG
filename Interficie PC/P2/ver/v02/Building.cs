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
using Microsoft.WindowsAPICodePack.Dialogs;

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
        public int contadorCercles = 0;
        public int afegirCercles = 0;

        public string movA, movB;
        public string path, filename;
        public int capes;

        public float distanciaX, distanciaY;

        public string signeX, signeY;

        List<string> mov = new List<string>();

        List<double> puntX = new List<double>();
        List<double> puntY = new List<double>();

        List<double> radi = new List<double>();
        List<double> angleInici = new List<double>();
        List<double> angleFinal = new List<double>();
        List<int> sentit = new List<int>();
        List<int> moviments = new List<int>();

        double inicialX = 50;
        double inicialY = 750;

        public double xRectangle, yRectangle;

        private void button7_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                MessageBox.Show("You selected: " + dialog.FileName);
            }
            path = dialog.FileName;
            filename = textBox10.Text + ".c";
            File.WriteAllText(path + filename, String.Empty);
            label12.Text = path + filename;
        }

        //GRID
        private void button9_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();
            Pen grayPen = new Pen(Color.LightGray, 1);
            Pen redPen = new Pen(Color.Red, 2);
            gObject.DrawRectangle(redPen, 10, 10, 800, 790);
            for (int i = 1; i <= 16; i++)
            {
                gObject.DrawLine(grayPen, 10, 10 * 5 * i, 810, 10 * 5 * i);
            }

            for (int i = 1; i <= 16; i++)
            {
                gObject.DrawLine(grayPen, 10 * 5 * i, 10, 10 * 5 * i, 800);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        //AMUNT
        public void button1_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();
            

            inicialX = inicialX + Convert.ToDouble(textBox3.Text);
            inicialY = inicialY - Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {

                    puntX.Add(inicialX);
                    puntY.Add(inicialY);
                    esCercle.Add(0);
                    esAngle.Add(0);
                    richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                    //richTextBox2.AppendText(Convert.ToString(esCercle[contadorPunts]) + "\n");
                    puntX.Add(inicialX );
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

                if ((puntX[contadorPunts - 1] - Convert.ToDouble(textBox1.Text) > 500) || (puntY[contadorPunts - 1] - Convert.ToDouble(textBox1.Text)) < 20)
                {
                    MessageBox.Show("Punt fora de rang!");
                }
                else {
                    puntX.Add(puntX[contadorPunts - 1]);
                    puntY.Add(puntY[contadorPunts - 1] - Convert.ToDouble(textBox1.Text));
                    esCercle.Add(0);
                    esAngle.Add(0);
                    Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                    PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                    PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                    gObject.DrawLine(blackPen, point1, point2);
                    richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                    //richTextBox2.AppendText(Convert.ToString(esCercle[contadorPunts]) + "\n");
                    contadorLinies++;
                }
            }
            try
            {
                label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
                label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
                label4.Text = Convert.ToString(contadorPunts);
            }
            catch
            {

            }

            moviments.Add(1);
            
        }

        //AVALL
        private void button3_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            inicialX = inicialX + Convert.ToDouble(textBox3.Text);
            inicialY = inicialY - Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                esCercle.Add(0);
                esAngle.Add(0);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                //richTextBox2.AppendText(Convert.ToString(esCercle[contadorPunts]) + "\n");
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
                esCercle.Add(0);
                esAngle.Add(0);
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

            moviments.Add(2);
        }

        //DRETA
        private void button4_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            inicialX = inicialX + Convert.ToDouble(textBox3.Text);
            inicialY = inicialY - Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                esCercle.Add(0);
                esAngle.Add(0);
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
                esCercle.Add(0);
                esAngle.Add(0);
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

            moviments.Add(3);
        }

        private void canvas_Load(object sender, EventArgs e)
        {

        }

        //ESQUERRA
        private void button5_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            inicialX = inicialX + Convert.ToDouble(textBox3.Text);
            inicialY = inicialY - Convert.ToDouble(textBox4.Text);

            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                esCercle.Add(0);
                esAngle.Add(0);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                //richTextBox2.AppendText(Convert.ToString(esCercle[contadorPunts]) + "\n");
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
                esCercle.Add(0);
                esAngle.Add(0);
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

            moviments.Add(4);
        }

        //ANGLES
        private void button6_Click(object sender, EventArgs e)
        {
            Graphics gObject = CreateGraphics();

            inicialX = inicialX + Convert.ToDouble(textBox3.Text);
            inicialY = inicialY - Convert.ToDouble(textBox4.Text);


            Pen blackPen = new Pen(Color.Black, 8);
            if (contadorPunts == 0)
            {
                puntX.Add(inicialX);
                puntY.Add(inicialY);
                esCercle.Add(0);
                esAngle.Add(1);
                richTextBox1.AppendText(Convert.ToString(puntX[0]) + "," + Convert.ToString(puntY[0]) + "\n");
                //richTextBox2.AppendText(Convert.ToString(esCercle[contadorPunts]) + "\n");
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
                esCercle.Add(0);
                esAngle.Add(1);
                Console.WriteLine(puntX[contadorPunts] + "," + puntY[contadorPunts]);
                PointF point1 = new PointF((float)(puntX[contadorPunts - 1]), (float)(puntY[contadorPunts - 1]));
                PointF point2 = new PointF((float)(puntX[contadorPunts]), (float)((puntY[contadorPunts])));
                gObject.DrawLine(blackPen, point1, point2);
                richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");
                contadorLinies++;
            }

            double angle = Math.Atan((Convert.ToDouble(textBox5.Text) / Convert.ToDouble(textBox2.Text))) * 180 / Math.PI;
            label9.Text = Convert.ToString(angle);
            label1.Text = Convert.ToString(puntX[contadorPunts - 1] + "," + puntY[contadorPunts - 1] + "///" + puntX[contadorPunts] + "," + puntY[contadorPunts]);
            label3.Text = Convert.ToString(puntX.Count + "," + puntY.Count);
            label4.Text = Convert.ToString(contadorPunts);

            moviments.Add(5);
        }


        //CERCLE
        private void button8_Click(object sender, EventArgs e)
        {
            contadorPunts++;
            contadorCercles++;

            esCercle.Add(1);
            esAngle.Add(0);

            Graphics gObject = CreateGraphics();
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 8);

            // Create coordinates of rectangle to bound ellipse.
            double width = Convert.ToDouble(textBox8.Text) * 2;
            double height = Convert.ToDouble(textBox8.Text) * 2;
            double radius = Convert.ToDouble(textBox8.Text);

            // Create start and sweep angles on ellipse.
            int startAngle = Convert.ToInt32(textBox6.Text);
            int sweepAngle = Convert.ToInt32(textBox7.Text);

            //a
            if (radioButton1.Checked) {
                xRectangle = puntX[contadorPunts - 1] - width / 2;
                yRectangle = puntY[contadorPunts - 1];

                if (sweepAngle == 90)
                {
                    puntX.Add((radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1]);
                    puntY.Add((radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1] + radius);
                }
                else if (sweepAngle == -90)
                {
                    puntX.Add((radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1]);
                    puntY.Add((radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1] + radius);
                }
                else if (Math.Abs(sweepAngle) != 90)
                {
                    puntX.Add((radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1]);
                    puntY.Add(-(radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1] + radius);
                }

            } else if (radioButton2.Checked) {
                xRectangle = puntX[contadorPunts - 1] - width;
                yRectangle = puntY[contadorPunts - 1] - height / 2;

                if (Math.Abs(sweepAngle) == 90)
                {
                    puntX.Add((radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1] - radius);
                    puntY.Add((radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1]);
                } else if (Math.Abs(sweepAngle) != 90) {
                    puntX.Add((radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1] - radius);
                    puntY.Add((radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1]);
                }
            } else if (radioButton3.Checked) {
                xRectangle = puntX[contadorPunts - 1] - width / 2;
                yRectangle = puntY[contadorPunts - 1] - height;

                if (sweepAngle == 90)
                {
                    puntX.Add(-(radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1] - radius);
                    puntY.Add(-(radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1]);
                }
                else if (sweepAngle == -90)
                {
                    puntX.Add(-(radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1] + radius);
                    puntY.Add((radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1]);
                }
                else if (sweepAngle != 90)
                {
                    puntX.Add((-radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1]);
                    puntY.Add((radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1] - radius);
                }

                
            } else if(radioButton4.Checked) {
                xRectangle = puntX[contadorPunts - 1];
                yRectangle = puntY[contadorPunts - 1] - height / 2;

                if (Math.Abs(sweepAngle) == 90)
                {
                    puntX.Add((radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1] + radius);
                    puntY.Add(-(radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1]);
                }
                else if (Math.Abs(sweepAngle) != 90)
                {
                    puntX.Add(-(radius * Math.Cos(sweepAngle * Math.PI / 180)) + puntX[contadorPunts - 1] + radius);
                    puntY.Add(-(radius * Math.Sin(sweepAngle * Math.PI / 180)) + puntY[contadorPunts - 1]);
                }
            }



            //Enganyem al programa per tenir les llistes plenes
            //for (int i = 0; i <= contadorPunts - 1; i++) {
            //    angleInici.Insert(i, 0);
            //    angleFinal.Insert(i, 0);
            //    radi.Insert(i, 0);
            //    sentit.Insert(i, 0);
            //}

            //Paràmetres del cercle
            angleInici.Insert(contadorCercles - 1, startAngle);
            angleFinal.Insert(contadorCercles - 1, sweepAngle);
            radi.Insert(contadorCercles - 1, radius);
            if (sweepAngle > 0) { sentit.Insert(contadorCercles - 1, 1); } else if (sweepAngle < 0) { sentit.Insert(contadorCercles - 1, -1); };

            // Draw arc to screen.
            gObject.DrawArc(blackPen, (float)xRectangle, (float)yRectangle, (float)width, (float)height, startAngle, sweepAngle);
            richTextBox1.AppendText(Convert.ToString(puntX[contadorPunts]) + "," + Convert.ToString(puntY[contadorPunts]) + "\n");

            moviments.Add(6);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            building();
        }

        public void building()
        {
            Console.WriteLine(esCercle);
            Console.WriteLine(esAngle);
            
                if (true)
                {
                    capes = Convert.ToInt32(textBox11.Text);
                    File.WriteAllText(path + filename, String.Empty);
                    movA = "moveMotorTarget(motorA," + (0 + Convert.ToDouble(textBox3.Text)) * 10 + ", 35); \n moveMotorTarget(motorB," + (0 + Convert.ToDouble(textBox4.Text)) * 10 + ", 35);\n";
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path + filename + ".c", true))
                {
                    file.WriteLine("#pragma config(Motor,  motorA,          MotorA,        tmotorEV3_Medium, PIDControl, encoder)");
                    file.WriteLine("#pragma config(Motor,  motorB,          MotorB,        tmotorEV3_Medium, PIDControl, encoder)");
                    file.WriteLine("#pragma config(Motor,  motorC,          MotorC,        tmotorEV3_Large, PIDControl, encoder)");
                    file.WriteLine("#include <cercle.h>");
                    file.WriteLine("task main() {");
                    file.WriteLine(movA);
                    file.WriteLine("waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);");
                    file.WriteLine("for (int i = 1; i <= " + capes + "; i ++) {");
                }
                    for (int i = 0; i <= moviments.Count - 1; i++)
                    {
                        //Cercle
                        if (moviments[i] == 6)
                        {
                            
                            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path + filename + ".c", true))
                            {
                                file.WriteLine("long parRadi"+ afegirCercles +"= " + radi[afegirCercles] * 10 + ";");
                                file.WriteLine("long parAngleFinal" + afegirCercles + " = " + angleFinal[afegirCercles] + ";");
                                file.WriteLine("int parAngleInici" + afegirCercles + " = " + angleInici[afegirCercles] + ";");
                            }
                        afegirCercles++;
                        }

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path + filename + ".c", true))
                    {
                        //Cercle
                        if (moviments[i] == 6) {
                            
                                movA = "cercle(parRadi" + (afegirCercles-1) + ", parAngleFinal" + (afegirCercles-1) + ", parAngleInici" + (afegirCercles-1) + ");";
                                file.WriteLine(movA);
                        }
                        //Angle
                        else if (moviments[i] == 5)
                        {
                            distanciaX = (float)(puntX[i + 1] - puntX[i]) * (float)10;
                            distanciaY = (float)(puntY[i + 1] - puntY[i]) * (float)10;
                            if (puntX[i - 1] > puntX[i]) { signeX = "-"; } else { signeX = ""; }

                            if (puntY[i] > puntY[i - 1]) { signeY = "-"; } else { signeY = ""; }
                            double angle = (Math.Atan((Convert.ToDouble(textBox5.Text) / Convert.ToDouble(textBox2.Text)))) * (180 / Math.PI);
                            float velocitatX = (float)Math.Cos(angle * Math.PI / 180) * 35;
                            float velocitatY = (float)Math.Sin(angle * Math.PI / 180) * 35;
                            movA = "moveMotorTarget(motorA," + Math.Abs(distanciaX) + "," + signeX + Math.Abs(velocitatX) + "); \n moveMotorTarget(motorB," + Math.Abs(distanciaY) + "," + signeY + Math.Abs(velocitatY) + ");\n";
                        }
                        //Recta
                        else
                        {
                                distanciaX = (float)(puntX[i + 1] - puntX[i]) * (float)10;
                                distanciaY = (float)(puntY[i + 1] - puntY[i]) * (float)10;
                                if (puntX[i + 1] > puntX[i]) { signeX = ""; } else { signeX = "-"; }
                                if (puntY[i + 1] > puntY[i]) { signeY = "-"; } else { signeY = ""; }

                                movA = "moveMotorTarget(motorA," + Math.Abs(distanciaX) + ", " + signeX + "35); \n moveMotorTarget(motorB," + Math.Abs(distanciaY) + ", " + signeY + "35);\n";
                                file.WriteLine(movA);
                                file.WriteLine("waitUntilMotorStop(motorA); waitUntilMotorStop(motorB);");
                            
                        }
                    }

                    }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@path + filename + ".c", true))
                {
                    file.WriteLine("} }");
                }

                    for(int i = 0; i <= moviments.Count - 1; i++)
                    {
                        //richTextBox2.AppendText(Convert.ToString(esAngle[i]));
                        richTextBox2.AppendText(Convert.ToString(moviments[i]));
                    } 
                
                }
                else if (textBox11.Text == "")
                {
                    MessageBox.Show("Introdueix un nombre de capes.");
                }
                else if (textBox10.Text.Length == 1)
                {
                    MessageBox.Show("Introdueix un nom vàlid per al fitxer a exportar.");
                }
        }
    }
}

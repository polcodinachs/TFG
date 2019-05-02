using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;


namespace TFG
{
    public class SerialPortClass
    {
        public static string nombrePuerto;
        public static void puerto(string name)
        {
            nombrePuerto = name;
        }
        //public static SerialPort serialPort1 { get; set; } = new SerialPort("COM5");
    }
}
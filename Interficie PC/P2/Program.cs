using System;
using System.Windows.Forms;
using System.IO.Ports;
using TFG;

namespace P2
{

	internal sealed class Program
	{
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inici());
        }
	}
}

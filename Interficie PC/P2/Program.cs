using System;
using System.Windows.Forms;
using TFG.ver.v02;

namespace TFG
{

    internal sealed class Program
	{
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal());
        }
	}
}

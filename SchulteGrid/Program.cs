using System;
using System.Windows.Forms;

namespace SchulteGrid
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBHelper.Init();
            Application.Run(new MainForm());
        }
    }
}

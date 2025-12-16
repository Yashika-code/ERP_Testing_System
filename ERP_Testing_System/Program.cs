using System;
using System.Windows.Forms;
using ERP_Testing_System.Forms;

namespace ERP_Testing_System
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // MainForm: Master Selector
            Application.Run(new MasterSelectorForm());
        }
    }
}

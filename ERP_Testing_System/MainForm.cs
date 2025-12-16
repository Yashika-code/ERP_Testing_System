using System.Windows.Forms;
using ERP_Testing_System.Forms;

namespace ERP_Testing_System
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "ERP Testing System";
            Width = 1200;
            Height = 700;

            var btnTest = new Button
            {
                Text = "Test",
                Left = 20,
                Top = 30,
                Width = 200
            };

            var btnAdmin = new Button
            {
                Text = "Admin Panel",
                Left = 20,
                Top = 80,
                Width = 200
            };

            btnTest.Click += (s, e) => new TestingForm().ShowDialog();
            btnAdmin.Click += (s, e) => new MasterSelectorForm().ShowDialog();

            Controls.Add(btnTest);
            Controls.Add(btnAdmin);
        }
    }
}

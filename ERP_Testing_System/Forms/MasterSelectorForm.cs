using System.Windows.Forms;

namespace ERP_Testing_System.Forms
{
    public class MasterSelectorForm : Form
    {
        public MasterSelectorForm()
        {
            Text = "ERP - Admin Panel";
            Width = 300; Height = 400;
            string[] masters = { "Part Code", "Party", "IEC Standard", "Model", "Class", "VA", "Label", "Testing Screen" };
            int top = 20;

            foreach (var m in masters)
            {
                var btn = new Button { Text = m, Width = 200, Top = top, Left = 40 };
                btn.Click += (s, e) =>
                {
                    if (m == "Testing Screen") new TestingForm().ShowDialog();
                    else new MasterForm(m).ShowDialog();
                };
                Controls.Add(btn); top += 40;
            }
        }
    }
}

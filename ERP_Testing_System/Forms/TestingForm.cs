using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ERP_Testing_System.Forms
{
    public class TestingForm : Form
    {
        TextBox txtPoints = new();
        TextBox txtSet = new();
        Label lblQuantity = new();
        DataGridView grid = new();
        Chart chart = new();

        public TestingForm()
        {
            Text = "Testing Screen"; Width = 1200; Height = 800;
            InitSidebar(); InitTopInputs(); InitRightPanel(); InitGrid(); InitChart();
        }

        void InitSidebar()
        {
            int x = 0, y = 20;
            string[] buttons = { "Test", "Pending JC", "Report", "Admin Panel", "JC Manipulation", "Label Master", "Range Master" };
            foreach (var b in buttons)
            {
                var btn = new Button { Text = b, Width = 140, Left = x, Top = y };
                btn.Click += (s, e) => MessageBox.Show($"{b} clicked");
                Controls.Add(btn); y += 40;
            }
        }

        void InitTopInputs()
        {
            int x = 160, y = 20;
            Controls.Add(new Label { Text = "Points", Left = x, Top = y });
            txtPoints.SetBounds(x + 60, y, 80, 25); Controls.Add(txtPoints);
            Controls.Add(new Label { Text = "Set", Left = x + 160, Top = y });
            txtSet.SetBounds(x + 200, y, 80, 25); Controls.Add(txtSet);
            lblQuantity.SetBounds(x + 300, y, 150, 25); lblQuantity.Text = "Quantity: 0"; Controls.Add(lblQuantity);
            txtPoints.TextChanged += CalcQuantity; txtSet.TextChanged += CalcQuantity;
        }

        void InitRightPanel()
        {
            int x = 900, y = 20;
            var btnSave = new Button { Text = "Save", Left = x, Top = y, Width = 100 };
            var btnNew = new Button { Text = "New", Left = x + 110, Top = y, Width = 100 };
            var btnExport = new Button { Text = "Export to Excel", Left = x, Top = y + 40, Width = 120 };
            btnSave.Click += (s, e) => MessageBox.Show("Saved in memory (placeholder)");
            btnNew.Click += (s, e) => { grid.Rows.Clear(); txtPoints.Clear(); txtSet.Clear(); lblQuantity.Text = "Quantity: 0"; };
            btnExport.Click += ExportGrid;
            Controls.AddRange(new Control[] { btnSave, btnNew, btnExport });
        }

        void InitGrid()
        {
            grid.SetBounds(160, 80, 700, 500); grid.ColumnCount = 8;
            string[] cols = { "Sr.No","BD %","Pri.Vol %","Excitation %","Ratio Error %","Phase Error (MIN)","Class","Status" };
            for(int i=0;i<8;i++) grid.Columns[i].Name = cols[i];
            grid.AllowUserToAddRows = true; Controls.Add(grid);
            grid.CellValueChanged += (s,e)=>UpdateChart(); grid.RowsAdded += (s,e)=>UpdateChart(); grid.RowsRemoved += (s,e)=>UpdateChart();
        }

        void CalcQuantity(object? sender, EventArgs e)
        {
            int points = int.TryParse(txtPoints.Text, out var pv)? pv:0;
            int set = int.TryParse(txtSet.Text, out var sv)? sv:0;
            lblQuantity.Text = $"Quantity: {points*set}";
        }

        void InitChart()
        {
            chart.SetBounds(160,600,700,200); chart.ChartAreas.Add(new ChartArea("MainArea"));
            chart.Series.Add(new Series("BD%"){ ChartType = SeriesChartType.Column });
            Controls.Add(chart);
        }

        void UpdateChart()
        {
            var series = chart.Series["BD%"];
            series.Points.Clear();
            int srNo = 1;
            foreach(DataGridViewRow row in grid.Rows)
            {
                if(!row.IsNewRow)
                {
                    double val = double.TryParse(row.Cells["BD %"].Value?.ToString(),out var v)?v:0;
                    series.Points.AddXY(srNo++,val);
                }
            }
        }

        void ExportGrid(object? sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory,"TestingExport.csv");
                using var writer = new StreamWriter(path);
                writer.WriteLine(string.Join(",", grid.Columns.Cast<DataGridViewColumn>().Select(c=>c.HeaderText)));
                foreach(DataGridViewRow row in grid.Rows)
                {
                    if(!row.IsNewRow)
                    {
                        writer.WriteLine(string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(c=>c.Value?.ToString()??"")));
                    }
                }
                MessageBox.Show($"Exported to {path}");
            }
            catch(Exception ex){ MessageBox.Show($"Export failed: {ex.Message}"); }
        }
    }
}

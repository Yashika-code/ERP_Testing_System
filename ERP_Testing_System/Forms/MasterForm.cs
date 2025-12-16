using System;
using System.Windows.Forms;
using ERP_Testing_System.Data;
using ERP_Testing_System.Models;

namespace ERP_Testing_System.Forms
{
    public class MasterForm : Form
    {
        ListBox list = new();
        TextBox txt = new();
        Button btnAdd = new();
        Button btnEdit = new();
        Button btnDelete = new();
        string master;

        public MasterForm(string masterName)
        {
            master = masterName;
            Text = masterName + " Master";
            Width = 400;
            Height = 400;

            txt.SetBounds(20, 20, 200, 25);
            btnAdd.SetBounds(240, 20, 100, 25); btnAdd.Text = "Add"; btnAdd.Click += AddItem;
            btnEdit.SetBounds(240, 60, 100, 25); btnEdit.Text = "Edit"; btnEdit.Click += EditItem;
            btnDelete.SetBounds(240, 100, 100, 25); btnDelete.Text = "Delete"; btnDelete.Click += DeleteItem;
            list.SetBounds(20, 60, 200, 280);

            Controls.AddRange(new Control[] { txt, btnAdd, btnEdit, btnDelete, list });
            RefreshList();
        }

        void AddItem(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt.Text)) return;
            switch (master)
            {
                case "Part Code": AppData.PartCodes.Add(new PartCode { PartCodeValue = txt.Text }); break;
                case "Party": AppData.Parties.Add(new Party { PartyName = txt.Text }); break;
                case "IEC Standard": AppData.IECStandards.Add(new IECStandard { StandardName = txt.Text }); break;
                case "Model": AppData.Models.Add(new ModelMaster { ModelName = txt.Text }); break;
                case "Class": AppData.Classes.Add(new ClassMaster { ClassName = txt.Text }); break;
                case "VA": AppData.VAs.Add(new VAMaster { VAName = txt.Text }); break;
                case "Label": AppData.Labels.Add(new LabelMaster { LabelType = txt.Text }); break;
            }
            txt.Clear(); RefreshList();
        }

        void EditItem(object? sender, EventArgs e)
        {
            if (list.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txt.Text)) return;
            switch (master)
            {
                case "Part Code": AppData.PartCodes[list.SelectedIndex].PartCodeValue = txt.Text; break;
                case "Party": AppData.Parties[list.SelectedIndex].PartyName = txt.Text; break;
                case "IEC Standard": AppData.IECStandards[list.SelectedIndex].StandardName = txt.Text; break;
                case "Model": AppData.Models[list.SelectedIndex].ModelName = txt.Text; break;
                case "Class": AppData.Classes[list.SelectedIndex].ClassName = txt.Text; break;
                case "VA": AppData.VAs[list.SelectedIndex].VAName = txt.Text; break;
                case "Label": AppData.Labels[list.SelectedIndex].LabelType = txt.Text; break;
            }
            RefreshList();
        }

        void DeleteItem(object? sender, EventArgs e)
        {
            if (list.SelectedIndex == -1) return;
            switch (master)
            {
                case "Part Code": AppData.PartCodes.RemoveAt(list.SelectedIndex); break;
                case "Party": AppData.Parties.RemoveAt(list.SelectedIndex); break;
                case "IEC Standard": AppData.IECStandards.RemoveAt(list.SelectedIndex); break;
                case "Model": AppData.Models.RemoveAt(list.SelectedIndex); break;
                case "Class": AppData.Classes.RemoveAt(list.SelectedIndex); break;
                case "VA": AppData.VAs.RemoveAt(list.SelectedIndex); break;
                case "Label": AppData.Labels.RemoveAt(list.SelectedIndex); break;
            }
            RefreshList();
        }

        void RefreshList()
        {
            list.Items.Clear();
            switch (master)
            {
                case "Part Code": AppData.PartCodes.ForEach(x => list.Items.Add(x.PartCodeValue)); break;
                case "Party": AppData.Parties.ForEach(x => list.Items.Add(x.PartyName)); break;
                case "IEC Standard": AppData.IECStandards.ForEach(x => list.Items.Add(x.StandardName)); break;
                case "Model": AppData.Models.ForEach(x => list.Items.Add(x.ModelName)); break;
                case "Class": AppData.Classes.ForEach(x => list.Items.Add(x.ClassName)); break;
                case "VA": AppData.VAs.ForEach(x => list.Items.Add(x.VAName)); break;
                case "Label": AppData.Labels.ForEach(x => list.Items.Add(x.LabelType)); break;
            }
        }
    }
}

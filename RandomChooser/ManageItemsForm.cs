using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomChooser
{
    public partial class ManageItemsForm : Form
    {
        public List<string> UpdatedItems { get; private set; }
        public ManageItemsForm(List<string> currentItems)
        {
            InitializeComponent();
            // Fill the listbox with names from the main window
            lstAllItems.Items.AddRange(currentItems.ToArray());
            this.KeyPreview = true;
        }
        private void lstAllItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAllItems.SelectedItem != null)
            {
                txtRename.Text = lstAllItems.SelectedItem.ToString();
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (lstAllItems.SelectedIndex != -1 && !string.IsNullOrWhiteSpace(txtRename.Text))
            {
                // Replace the old name with the one in the textbox
                lstAllItems.Items[lstAllItems.SelectedIndex] = txtRename.Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstAllItems.SelectedIndex != -1)
            {
                lstAllItems.Items.RemoveAt(lstAllItems.SelectedIndex);
                txtRename.Clear();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Pack everything up to send back
            UpdatedItems = lstAllItems.Items.Cast<string>().ToList();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

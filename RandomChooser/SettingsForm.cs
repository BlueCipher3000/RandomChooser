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
    public partial class SettingsForm : Form
    {
        public int SelectedDuration { get; private set; }
        public SettingsForm(int currentDuration)
        {
            InitializeComponent();
            // Set the current value so the user sees what's already saved
            numDuration.Value = currentDuration;
        }
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SelectedDuration = (int)numDuration.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

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
    public partial class AddValueForm : Form
    {
        public string ValueEntered { get; private set; }
        public AddValueForm()
        {
            InitializeComponent();
            this.AcceptButton = btnConfirm; // Pressing Enter clicks 'OK'
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ValueEntered = txtNewValue.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

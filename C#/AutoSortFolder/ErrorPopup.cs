using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoSortFolder
{
    public partial class ErrorPopup : Form
    {
        public string errorMessage;

        public ErrorPopup()
        {
            InitializeComponent();
            errorMessage = "There was an error that occurred. Please try again.";
            textboxErrorPopup.Text = errorMessage;
        }

        public ErrorPopup(string message)
        {
            errorMessage = message;
            textboxErrorPopup.Text = errorMessage;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

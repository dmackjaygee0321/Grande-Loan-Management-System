using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class dialogactivate : Form
    {
        public dialogactivate()
        {
            InitializeComponent();
        }
        public static string text;
        private void dialogactivate_Load(object sender, EventArgs e)
        {
            label1.Text = "Are you sure to " + text + " user? ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

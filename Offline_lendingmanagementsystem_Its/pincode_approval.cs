using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class pincode_approval : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public pincode_approval()
        {
            InitializeComponent();
        }

        private void pincode_approval_Load(object sender, EventArgs e)
        {
            display();
        }
        public static string text;
        public void display()
        {
            textBox1.Visible = false;
            button1.Text = "Yes";
            button2.Text = "No";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Continue")
            {
                con.Open();
                DataTable dt2 = new DataTable();
                string strAcct2 = "select concat(a.lname,a.fname,a.mname) as fn, a.userlevel,a.password,b.a_d from user as a, userlevel as b where a.userlevel = b.usertype and b.a_d = 'yes'";
                da = new OdbcDataAdapter(strAcct2, con);
                da.Fill(dt2);
                con.Close();
                for (int x = 0; x < dt2.Rows.Count; x++)
                {
                    if (dt2.Rows[x].ItemArray[2].ToString() == textBox1.Text)
                    {
                        this.DialogResult = DialogResult.OK;
                        return;
                    }
                    else if (x == dt2.Rows.Count - 1)
                    {
                        MessageBox.Show("Invalid Pin");
                    }
                }
            }
            textBox1.Visible = true;
            button1.Text = "Continue";
            button2.Text = "Cancel";
            label1.Text = "Please Enter Pin";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}

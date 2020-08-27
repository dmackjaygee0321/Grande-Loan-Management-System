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
using System.IO;
using System.Reflection;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class Login : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            panel1.BackColor = Color.FromArgb(246, 246, 246);
            panel3.BackColor = Color.FromArgb(37, 136, 227);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            panel3.BackColor = Color.White;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (label2.Visible == true)
            {
                label2.Visible = false;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            panel2.BackColor = Color.FromArgb(246, 246, 246);
            panel4.BackColor = Color.FromArgb(37, 136, 227);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            panel2.BackColor = Color.White;
            panel4.BackColor = Color.White;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (label2.Visible == true)
            {
                label2.Visible = false;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login();
        }
        public void login()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from user where status = 1";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
                /*
                Form1 f = new Form1();
                Form1.userid = dt.Rows[0].ItemArray[0].ToString();
                Form1.user = dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString() + " " + (dt.Rows[0].ItemArray[3].ToString())[0] + ".";
                Form1.usertype = dt.Rows[0].ItemArray[4].ToString();
                Form1.filename = dt.Rows[0].ItemArray[7].ToString();
                Form1.logintime = DateTime.Now.ToString();
                activity();
                f.Show();
                this.Hide();
                 * */
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (textBox1.Text == dt.Rows[x].ItemArray[5].ToString() && textBox2.Text == dt.Rows[x].ItemArray[6].ToString() && dt.Rows[x].ItemArray[4].ToString() != "Null")
                {
                    MessageBox.Show("Login Successful!");
                    Form1 f = new Form1();
                    Form1.userid = dt.Rows[x].ItemArray[0].ToString();
                    Form1.user = dt.Rows[x].ItemArray[1].ToString() + " " + dt.Rows[x].ItemArray[2].ToString() + " " + (dt.Rows[x].ItemArray[3].ToString())[0] + ".";
                    Form1.usertype = dt.Rows[x].ItemArray[4].ToString();
                    Form1.filename = dt.Rows[x].ItemArray[7].ToString();
                    Form1.logintime = DateTime.Now.ToString();
                    activity();
                    f.Show();
                    this.Hide();
                }
                else if (textBox1.Text == dt.Rows[x].ItemArray[5].ToString() && textBox2.Text == dt.Rows[x].ItemArray[6].ToString() && dt.Rows[x].ItemArray[4].ToString() == "Null")
                {
                    label2.Text = "Undifined User Level";
                    label2.Visible = true;
                }
                else if (x == dt.Rows.Count - 1)
                {
                    label2.Text = "Invalid Username or Password";
                    label2.Visible = true;
                }
            }
        }
        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Login','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}

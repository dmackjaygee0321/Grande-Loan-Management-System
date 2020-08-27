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
    public partial class addattachment : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public addattachment()
        {
            InitializeComponent();
        }
        string filename;
        public void insertattachment()
        {
            con.Open();
            string replace = filename.Replace('\\', '*');
            string strAdd = "Insert Into attachments values('"+CreditInvistigator.id+"','"+comboBox1.Text+"','"+replace+"','"+textBox2.Text+"',0)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addattachment_Load(object sender, EventArgs e)
        {
            textBox2.ShortcutsEnabled = false;
            displaycategory();
        }
        public void displaycategory()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from attachment_tbl";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            comboBox1.Items.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                comboBox1.Items.Add(dt.Rows[x].ItemArray[1].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (pbpic.Image != null)
            {
                insertattachment();
                activitylog();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Fill out all fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void activitylog()
        {
            string fn = string.Empty;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '" + CreditInvistigator.id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fn = dt.Rows[0].ItemArray[1].ToString().Trim() + " " + dt.Rows[0].ItemArray[2].ToString().Trim() + " " + dt.Rows[0].ItemArray[3].ToString().Trim();
            string text = "Add Attachment";
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'" + text + "','" + fn.Replace("'","''") + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void butb1_Click(object sender, EventArgs e)
        {

            opb1.Filter = "Image files (*.jpg,*.png) | *.jpg; *.png";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename = opb1.FileName.ToString();
                pbpic.Image = Image.FromFile(filename);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void function()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from attachment_tbl";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox2.Text;
            if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 32)
            {
                if (cursorposition == 0)
                {
                    e.Handled = true;
                }
                if (text.Length > cursorposition)
                {
                    if (text[cursorposition - 1] == 32 || text[cursorposition] == 32)
                    {
                        e.Handled = true;

                    }
                }
                if (text.Length == 0)
                {
                    e.Handled = true;
                }
                if (text.Length != 0)
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox2.Text);
            textBox2.Select(textBox2.Text.Length, 0);
        }
    }
}

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
    public partial class attachment_updatedelte : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public attachment_updatedelte()
        {
            InitializeComponent();
        }
        public static string id;
        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select * from attachment_tbl";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (textBox1.Text.Trim().ToLower() == dt.Rows[x].ItemArray[1].ToString().Trim().ToLower() && dt.Rows[x].ItemArray[0].ToString() != id)
                {
                    MessageBox.Show("Attachment Type is already existed!");
                    break;
                }
                else if (x == dt.Rows.Count - 1)
                {
                    update();
                    activity();
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void attachment_updatedelte_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            display();
        }

        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select * from attachment_tbl where ID = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label2.Text += " " + dt.Rows[0].ItemArray[0].ToString();
            textBox1.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
        }

        public void update()
        {
            con.Open();
            string strAdd = "Update attachment_tbl set A_type = '"+textBox1.Text+"', F_type = '"+textBox2.Text+"' where ID = '"+id+"'";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void delete()
        {
            con.Open();
            string strAdd = "Delete from attachment_tbl where ID = '" + id + "'";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            delete();
            delteactivity();
            this.DialogResult = DialogResult.OK;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
            textBox2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox2.Text);
            textBox2.Select(textBox1.Text.Length, 0);
        }

        public void validation(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (!Char.IsLetter(ch) && ch != 8 && ch != 32 && ch != 127)
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
                else
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                    }
                }
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox1.Text);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox2.Text);
        }
        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update Attachment','" + textBox1.Text.Trim() + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void delteactivity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Delete Attachment','" + textBox1.Text.Trim() + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

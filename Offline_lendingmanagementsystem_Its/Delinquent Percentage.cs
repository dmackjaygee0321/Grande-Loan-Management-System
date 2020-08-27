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
    public partial class Delinquent_Percentage : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Delinquent_Percentage()
        {
            InitializeComponent();
        }

        private void Delinquent_Percentage_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            button3.Text = "Update";
            display();
        }
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select delinquent from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Update")
            {
                textBox1.Enabled = true;
                button3.Text = "Save";
            }
            else
            {
                if (Convert.ToDouble(textBox1.Text) > 100 || Convert.ToDouble(textBox1.Text) < 0)
                {
                    MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                save();
                MessageBox.Show("Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Enabled = false;
                button3.Text = "Update";
            }
        }

        public void qweqwe(KeyPressEventArgs e, object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox1.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 127)
            {
                e.Handled = true;
            }
            if (cursorposition == 0 && ch == 46)
            {
                e.Handled = true;
                textBox1.Text = "0.";
                (sender as TextBox).SelectionStart = textBox1.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox1.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox1.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox1.TextLength == 1 && textBox1.Text[0] == '0')
                {
                    textBox1.Clear();
                }
            }
            if (ch == 8 && textBox1.TextLength == 1 || ch == 8 && textBox1.TextLength == 0)
            {
                textBox1.Text = "0";
                e.Handled = true;
            }
            if (textBox1.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox1.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox1.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox1.TextLength == 7 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox1.Text;
                for (int x = 0; x < textBox1.TextLength; x++)
                {
                    if (textBox1.Text[x] != '0' && x > 0)
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    textBox1.Text = text.Remove(0, count);
                    if (textBox1.Text == string.Empty)
                    {
                        textBox1.Text = "0";
                    }
                }
            }
            if (textBox1.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox1.TextLength; x++)
                {
                    if (textBox1.Text[x] == '.')
                    {
                        index = x;
                        break;
                    }
                }
                if (index > 6 && cursorposition <= index && ch != 8 && ch != 127)
                {
                    e.Handled = true;
                }
            }
        }

        public void save()
        {
            con.Open();
            string strAdd = "update loanmaintenance set delinquent = '"+textBox1.Text+"'";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e, sender);
        }
    }
}

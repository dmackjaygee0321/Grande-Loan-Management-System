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
    public partial class loanmaintenance : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public loanmaintenance()
        {
            InitializeComponent();
        }

        private void loanmaintenance_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            textBox18.ShortcutsEnabled = false;
            textBox6.ShortcutsEnabled = false;
            textBox5.ShortcutsEnabled = false;
            textBox8.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            textBox3.ShortcutsEnabled = false;
            textBox4.ShortcutsEnabled = false;
            textBox7.ShortcutsEnabled = false;
            textBox9.ShortcutsEnabled = false;
            textBox10.ShortcutsEnabled = false;
            disable_enable();
            display();
        }
        public void disable_enable()
        {
            if (button1.Text == "Update")
            {
                textBox1.Enabled = false;
                textBox18.Enabled = false;
                textBox6.Enabled = false;
                textBox5.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox18.Enabled = true;
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
            }

            if (button2.Text == "Update")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox7.Enabled = false;
                textBox10.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox7.Enabled = true;
                textBox10.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Update")
            {
                button1.Text = "Save";
            }
            else
            {
                if (Convert.ToDouble(textBox6.Text) < Convert.ToDouble(textBox5.Text) && Convert.ToDouble(textBox18.Text) <= 100 && Convert.ToDouble(textBox18.Text) >= 0)
                {
                    updatepersonal();
                    button1.Text = "Update";
                    activityp();
                    display();
                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
            disable_enable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Update")
            {
                button2.Text = "Save";
            }
            else
            {
                if (Convert.ToDouble(textBox7.Text) < Convert.ToDouble(textBox4.Text) && Convert.ToDouble(textBox3.Text) <= 100 && Convert.ToDouble(textBox3.Text) >= 0)
                {
                    updateemergency();
                    button2.Text = "Update";
                    activitye();
                    display();
                    MessageBox.Show("Saved Successfully");
                }
                else
                {
                    MessageBox.Show("Invalid Input");
                }
            }
            disable_enable();
        }
        double pi, pma, pmaxt, pmint, p;
        double mi, mma, mmint, mmaxt;
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            pi = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
            pma = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
            pmint = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
            pmaxt = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
            p = Convert.ToDouble(dt.Rows[0].ItemArray[8].ToString());
            mi = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());
            mma = Convert.ToDouble(dt.Rows[0].ItemArray[5].ToString());
            mmint = Convert.ToDouble(dt.Rows[0].ItemArray[6].ToString());
            mmaxt = Convert.ToDouble(dt.Rows[0].ItemArray[7].ToString());
            textBox18.Text = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()).ToString();
            textBox1.Text = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString()).ToString();
            textBox6.Text = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString()).ToString();
            textBox5.Text = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString()).ToString();
            textBox8.Text = Convert.ToDouble(dt.Rows[0].ItemArray[8].ToString()).ToString();
            textBox3.Text = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString()).ToString();
            textBox2.Text = Convert.ToDouble(dt.Rows[0].ItemArray[5].ToString()).ToString();
            textBox7.Text = Convert.ToDouble(dt.Rows[0].ItemArray[6].ToString()).ToString();
            textBox4.Text = Convert.ToDouble(dt.Rows[0].ItemArray[7].ToString()).ToString();
            textBox9.Text = Convert.ToDouble(dt.Rows[0].ItemArray[9].ToString()).ToString();
            textBox10.Text = Convert.ToDouble(dt.Rows[0].ItemArray[10].ToString()).ToString();
        }

        public void updatepersonal()
        {
            con.Open();
            string update = "update loanmaintenance set pinterest = '" + textBox18.Text + "',pminamount = '" + textBox1.Text + "',pminterm = '" + textBox6.Text + "',pmaxterm = '" + textBox5.Text + "',ppenalty = '" + textBox8.Text + "',pdaypenalty = '" + textBox9.Text + "' ";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void updateemergency()
        {
            con.Open();
            string update = "update loanmaintenance set ginterest = '" + textBox3.Text + "',gminamount = '" + textBox2.Text + "',gminterm = '" + textBox7.Text + "',gmaxterm = '" + textBox4.Text + "',gdaypenalty = '" + textBox10.Text + "' ";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox5.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox5.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox5.TextLength == 1 && textBox5.Text[0] == '0')
                {
                    textBox5.Clear();
                }
            }
            if (ch == 8 && textBox5.TextLength == 1 || ch == 8 && textBox5.TextLength == 0)
            {
                textBox5.Text = "0";
                e.Handled = true;
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox5.Text;
                for (int x = 0; x < textBox5.TextLength; x++)
                {
                    if (textBox5.Text[x] != '0' && x > 0)
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
                    textBox5.Text = text.Remove(0, count);
                    if (textBox5.Text == string.Empty)
                    {
                        textBox5.Text = "0";
                    }
                }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e,sender);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox2.Text.IndexOf('.') != -1)
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
                textBox2.Text = "0.";
                (sender as TextBox).SelectionStart = textBox2.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox2.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox2.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox2.TextLength == 1 && textBox2.Text[0] == '0')
                {
                    textBox2.Clear();
                }
            }
            if (ch == 8 && textBox2.TextLength == 1 || ch == 8 && textBox2.TextLength == 0)
            {
                textBox2.Text = "0";
                e.Handled = true;
            }
            if (textBox2.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox2.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox2.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox2.TextLength == 7 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox2.Text;
                for (int x = 0; x < textBox2.TextLength; x++)
                {
                    if (textBox2.Text[x] != '0' && x > 0)
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
                    textBox2.Text = text.Remove(0, count);
                    if (textBox2.Text == string.Empty)
                    {
                        textBox2.Text = "0";
                    }
                }
            }
            if (textBox2.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox2.TextLength; x++)
                {
                    if (textBox2.Text[x] == '.')
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox3.Text.IndexOf('.') != -1)
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
                textBox3.Text = "0.";
                (sender as TextBox).SelectionStart = textBox3.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox3.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox3.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox3.TextLength == 1 && textBox3.Text[0] == '0')
                {
                    textBox3.Clear();
                }
            }
            if (ch == 8 && textBox3.TextLength == 1 || ch == 8 && textBox3.TextLength == 0)
            {
                textBox3.Text = "0";
                e.Handled = true;
            }
            if (textBox3.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox3.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox3.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox3.TextLength == 3 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox3.Text;
                for (int x = 0; x < textBox3.TextLength; x++)
                {
                    if (textBox3.Text[x] != '0' && x > 0)
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
                    textBox3.Text = text.Remove(0, count);
                    if (textBox3.Text == string.Empty)
                    {
                        textBox3.Text = "0";
                    }
                }
            }
            if (textBox3.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox3.TextLength; x++)
                {
                    if (textBox3.Text[x] == '.')
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

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox18.Text.IndexOf('.') != -1)
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
                textBox18.Text = "0.";
                (sender as TextBox).SelectionStart = textBox18.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox18.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox18.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox18.TextLength == 1 && textBox18.Text[0] == '0')
                {
                    textBox18.Clear();
                }
            }
            if (ch == 8 && textBox18.TextLength == 1 || ch == 8 && textBox18.TextLength == 0)
            {
                textBox18.Text = "0";
                e.Handled = true;
            }
            if (textBox18.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox18.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox18.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox18.TextLength == 3 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox18.Text;
                for (int x = 0; x < textBox18.TextLength; x++)
                {
                    if (textBox18.Text[x] != '0' && x > 0)
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
                    textBox18.Text = text.Remove(0, count);
                    if (textBox18.Text == string.Empty)
                    {
                        textBox18.Text = "0";
                    }
                }
            }
            if (textBox18.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox18.TextLength; x++)
                {
                    if (textBox18.Text[x] == '.')
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox8.Text.IndexOf('.') != -1)
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
                textBox8.Text = "0.";
                (sender as TextBox).SelectionStart = textBox8.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox8.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox8.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox8.TextLength == 1 && textBox8.Text[0] == '0')
                {
                    textBox8.Clear();
                }
            }
            if (ch == 8 && textBox8.TextLength == 1 || ch == 8 && textBox8.TextLength == 0)
            {
                textBox8.Text = "0";
                e.Handled = true;
            }
            if (textBox8.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox8.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox8.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox8.TextLength == 3 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox8.Text;
                for (int x = 0; x < textBox8.TextLength; x++)
                {
                    if (textBox8.Text[x] != '0' && x > 0)
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
                    textBox8.Text = text.Remove(0, count);
                    if (textBox8.Text == string.Empty)
                    {
                        textBox8.Text = "0";
                    }
                }
            }
            if (textBox8.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox8.TextLength; x++)
                {
                    if (textBox8.Text[x] == '.')
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox6.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox6.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox6.TextLength == 1 && textBox6.Text[0] == '0')
                {
                    textBox6.Clear();
                }
            }
            if (ch == 8 && textBox6.TextLength == 1 || ch == 8 && textBox6.TextLength == 0)
            {
                textBox6.Text = "0";
                e.Handled = true;
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox6.Text;
                for (int x = 0; x < textBox6.TextLength; x++)
                {
                    if (textBox6.Text[x] != '0' && x > 0)
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
                    textBox6.Text = text.Remove(0, count);
                    if (textBox6.Text == string.Empty)
                    {
                        textBox6.Text = "0";
                    }
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox7.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox7.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox7.TextLength == 1 && textBox7.Text[0] == '0')
                {
                    textBox7.Clear();
                }
            }
            if (ch == 8 && textBox7.TextLength == 1 || ch == 8 && textBox7.TextLength == 0)
            {
                textBox7.Text = "0";
                e.Handled = true;
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox7.Text;
                for (int x = 0; x < textBox7.TextLength; x++)
                {
                    if (textBox7.Text[x] != '0' && x > 0)
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
                    textBox7.Text = text.Remove(0, count);
                    if (textBox7.Text == string.Empty)
                    {
                        textBox7.Text = "0";
                    }
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox4.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox4.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox4.TextLength == 1 && textBox4.Text[0] == '0')
                {
                    textBox4.Clear();
                }
            }
            if (ch == 8 && textBox4.TextLength == 1 || ch == 8 && textBox4.TextLength == 0)
            {
                textBox4.Text = "0";
                e.Handled = true;
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox4.Text;
                for (int x = 0; x < textBox4.TextLength; x++)
                {
                    if (textBox4.Text[x] != '0' && x > 0)
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
                    textBox4.Text = text.Remove(0, count);
                    if (textBox4.Text == string.Empty)
                    {
                        textBox4.Text = "0";
                    }
                }
            }
        }

        private void textBox18_MouseMove(object sender, MouseEventArgs e)
        {
            textBox18.SelectionLength = 0;
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {

            textBox1.SelectionLength = 0;
        }

        private void textBox6_MouseMove(object sender, MouseEventArgs e)
        {

            textBox6.SelectionLength = 0;
        }

        private void textBox5_MouseMove(object sender, MouseEventArgs e)
        {

            textBox7.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox18.SelectionLength = 0;
            textBox6.SelectionLength = 0;
            textBox5.SelectionLength = 0;
            textBox8.SelectionLength = 0;
            textBox2.SelectionLength = 0;
            textBox3.SelectionLength = 0;
            textBox4.SelectionLength = 0;
        }

        private void textBox8_MouseMove(object sender, MouseEventArgs e)
        {

            textBox7.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox18.SelectionLength = 0;
            textBox6.SelectionLength = 0;
            textBox5.SelectionLength = 0;
            textBox8.SelectionLength = 0;
            textBox2.SelectionLength = 0;
            textBox3.SelectionLength = 0;
            textBox4.SelectionLength = 0;
        }

        private void textBox3_MouseMove(object sender, MouseEventArgs e)
        {

            textBox7.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox18.SelectionLength = 0;
            textBox6.SelectionLength = 0;
            textBox5.SelectionLength = 0;
            textBox8.SelectionLength = 0;
            textBox2.SelectionLength = 0;
            textBox3.SelectionLength = 0;
            textBox4.SelectionLength = 0;
        }

        private void textBox2_MouseMove(object sender, MouseEventArgs e)
        {

            textBox7.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox18.SelectionLength = 0;
            textBox6.SelectionLength = 0;
            textBox5.SelectionLength = 0;
            textBox8.SelectionLength = 0;
            textBox2.SelectionLength = 0;
            textBox3.SelectionLength = 0;
            textBox4.SelectionLength = 0;
        }

        private void textBox7_MouseMove(object sender, MouseEventArgs e)
        {

            textBox7.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox18.SelectionLength = 0;
            textBox6.SelectionLength = 0;
            textBox5.SelectionLength = 0;
            textBox8.SelectionLength = 0;
            textBox2.SelectionLength = 0;
            textBox3.SelectionLength = 0;
            textBox4.SelectionLength = 0;
        }

        private void textBox4_MouseMove(object sender, MouseEventArgs e)
        {

            textBox7.SelectionLength = 0;
            textBox1.SelectionLength = 0;
            textBox18.SelectionLength = 0;
            textBox6.SelectionLength = 0;
            textBox5.SelectionLength = 0;
            textBox8.SelectionLength = 0;
            textBox2.SelectionLength = 0;
            textBox3.SelectionLength = 0;
            textBox4.SelectionLength = 0;
        }
        public void activityp()
        {
            string text = string.Empty;
            if (pi != Convert.ToDouble(textBox18.Text))
            {
                text = "Interest is update to " + textBox18.Text+"%";
            }
            if (pma != Convert.ToDouble(textBox1.Text))
            {
                if (text != string.Empty)
                    text += ", ";
                text += "Max amount is update to " + textBox1.Text;
            }
            if (pmint != Convert.ToDouble(textBox6.Text))
            {
                if (text != string.Empty)
                    text += ", ";
                text += "Min Term is update to " + textBox6.Text;
            }
            if (pmaxt != Convert.ToDouble(textBox5.Text))
            {
                if (text != string.Empty)
                    text += ", ";
                text += "Max Term is update to " + textBox5.Text;
            }
            if (p != Convert.ToDouble(textBox8.Text))
            {
                if (text != string.Empty)
                    text += ", ";
                text += "Penalty is update to " + textBox8.Text;
            }
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update Personal Loan','" + text + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void activitye()
        {
            string text = string.Empty;
            if (mi != Convert.ToDouble(textBox3.Text))
            {
                text = "Interest is update to " + textBox3.Text + "%";
            }
            if (mma != Convert.ToDouble(textBox2.Text))
            {
                if (text != string.Empty)
                text += ", ";
                text += "Min amount is update to " + textBox2.Text;
            }
            if (mmint != Convert.ToDouble(textBox7.Text))
            {
                if (text != string.Empty)
                    text += ", ";
                text += "Min Term is update to " + textBox7.Text;
            }
            if (mmaxt != Convert.ToDouble(textBox4.Text))
            {
                if (text != string.Empty)
                    text += ", ";
                text += "Max Term is update to " + textBox4.Text;
            }
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update Emergency Loan','" + text + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox9.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox9.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox9.TextLength == 1 && textBox9.Text[0] == '0')
                {
                    textBox9.Clear();
                }
            }
            if (ch == 8 && textBox9.TextLength == 1 || ch == 8 && textBox9.TextLength == 0)
            {
                textBox9.Text = "0";
                e.Handled = true;
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox9.Text;
                for (int x = 0; x < textBox9.TextLength; x++)
                {
                    if (textBox9.Text[x] != '0' && x > 0)
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
                    textBox9.Text = text.Remove(0, count);
                    if (textBox9.Text == string.Empty)
                    {
                        textBox9.Text = "0";
                    }
                }
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (char.IsLetter(ch) || ch == 32)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox10.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox10.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox10.TextLength == 1 && textBox10.Text[0] == '0')
                {
                    textBox10.Clear();
                }
            }
            if (ch == 8 && textBox10.TextLength == 1 || ch == 8 && textBox10.TextLength == 0)
            {
                textBox10.Text = "0";
                e.Handled = true;
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox10.Text;
                for (int x = 0; x < textBox10.TextLength; x++)
                {
                    if (textBox10.Text[x] != '0' && x > 0)
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
                    textBox10.Text = text.Remove(0, count);
                    if (textBox10.Text == string.Empty)
                    {
                        textBox10.Text = "0";
                    }
                }
            }
        }
    }
}

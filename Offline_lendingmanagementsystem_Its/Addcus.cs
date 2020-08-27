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
    public partial class Addcus : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Addcus()
        {
            InitializeComponent();
        }

        private void Addcus_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            textBox3.ShortcutsEnabled = false;
            textBox4.ShortcutsEnabled = false;
            textBox5.ShortcutsEnabled = false;
            textBox6.ShortcutsEnabled = false;
            textBox7.ShortcutsEnabled = false;
            textBox8.ShortcutsEnabled = false;
            textBox9.ShortcutsEnabled = false;
            label25.Visible = false;
        }

        public void Capital()
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
            textBox2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox2.Text);
            textBox2.Select(textBox2.Text.Length, 0);
            textBox3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox3.Text);
            textBox3.Select(textBox3.Text.Length, 0);
            textBox4.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox4.Text);
            textBox4.Select(textBox4.Text.Length, 0);
            textBox7.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox7.Text);
            textBox7.Select(textBox7.Text.Length, 0);
            textBox8.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox8.Text);
            textBox8.Select(textBox8.Text.Length, 0);
        }


        public void number(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                label25.Visible = true;
                label25.Text = "Letters is not allowed in phone number! ";
                label25.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label25.Visible = false;
            }
        }

        

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Capital();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Capital();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Capital();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Capital();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            Capital();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            number(e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        string filename1, filename2;

        private void butb1_Click(object sender, EventArgs e)
        {

            opb1.Filter = "jpg|*.jpg";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename1 = opb1.FileName.ToString();
                pbpic.Image = Image.FromFile(filename1);
            }
        }

        private void butb2_Click(object sender, EventArgs e)
        {

            opb2.Filter = "jpg|*.jpg";
            DialogResult res = opb2.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename2 = opb2.FileName.ToString();
                pbpic1.Image = Image.FromFile(filename2);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        string sex;
        int ctr;
        public void insertcustomerinfo()
        {

            if (radioButton1.Checked == true)
                sex = radioButton1.Text;
            else
                sex = radioButton2.Text;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from usersettings";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");
            string company = textBox7.Text.Trim().Replace("'", "''");
            string occupation = textBox8.Text.Trim().Replace("'", "''");
            string replace = filename1.Replace('\\', '*');
            string replace1 = filename2.Replace('\\', '*');
            string strAdd = "Insert Into customerinfo values('"
                + dt.Rows[0].ItemArray[2].ToString() + "','" + lastname + "','" + firstname + "','" + middlename + "','" + textBox4.Text.Trim() + "','" + dateTimePicker1.Text + "','" + sex + "','" + textBox5.Text.Trim() + "','" + textBox6.Text.Trim() + "','" +
                company + "','" + occupation+ "','0','" + replace + "','" + replace1 + "','" + Form1.userid + "','" + DateTime.Now.ToString() + "','" + textBox9.Text.Trim() + "','0','0','0','0');";
            ctr = Convert.ToInt32(dt.Rows[0].ItemArray[2]);
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
        }

        public void updateid()
        {
            ctr++;
            string update = "update usersettings set No='" + ctr.ToString() + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox4.Text != string.Empty &&
                    textBox5.Text != string.Empty && textBox6.Text != string.Empty && textBox7.Text != string.Empty && textBox8.Text != string.Empty &&
                    textBox9.Text != string.Empty && pbpic.Image != null && pbpic1.Image != null)
                {
                    if (textBox6.TextLength < 11)
                    {
                        MessageBox.Show("Please input valid phone number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int x = 0; x < textBox5.TextLength; x++)
                    {
                        if (textBox5.Text[x] == '@')
                        {
                            if (textBox5.Text[x + 1] == '.'&& x+1 < textBox5.TextLength-1)
                            {
                                MessageBox.Show("Please input valid email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    DateTime dp = Convert.ToDateTime(dateTimePicker1.Text);
                    int year = dp.Year;
                    int nowyear = DateTime.Now.Year;
                    int age = nowyear - year;
                    if (age < 18)
                    {
                        MessageBox.Show("Age must be 18 and above!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                        if (textBox5.Text.Trim().Contains("@") && textBox5.Text.Trim().Contains(".com"))
                        {
                            con.Open();
                            DataTable dt = new DataTable();
                            string strAcct = "Select LastName,FirstName,MiddleName from customerinfo";
                            da = new OdbcDataAdapter(strAcct, con);
                            da.Fill(dt);
                            con.Close();
                            if (dt.Rows.Count > 0)
                            {
                                for (int x = 0; x < dt.Rows.Count; x++)
                                {
                                    if (dt.Rows[x].ItemArray[0].ToString().ToLower().Trim() == textBox1.Text.ToLower().Trim() && dt.Rows[x].ItemArray[1].ToString().ToLower().Trim() == textBox2.Text.ToLower().Trim() && dt.Rows[x].ItemArray[2].ToString().ToLower().Trim() == textBox3.Text.ToLower().Trim())
                                    {
                                        MessageBox.Show("Borrower is Already Existed!");
                                        break;
                                    }
                                    else if (x == dt.Rows.Count - 1)
                                    {
                                        insertcustomerinfo();
                                        updateid();
                                        activitylog();
                                        MessageBox.Show("Successfully Saved");
                                        Form1.modes = 1;
                                        (this.Owner as Form1).timer4.Start();
                                    }
                                }
                            }
                            else
                            {
                                insertcustomerinfo();
                                updateid();
                                activitylog();
                                MessageBox.Show("Successfully Saved");
                                Form1.modes = 1;
                                (this.Owner as Form1).timer4.Start();
                            }
                        }
                        else
                        {
                            MessageBox.Show("please input valid email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
                else
                {
                    MessageBox.Show("Please fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void activitylog()
        {
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");

            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Add Borrower','" + lastname + " " + firstname + " " + middlename + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e,sender);
        }
        public void qweqwe(KeyPressEventArgs e,object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox9.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (char.IsLetter(ch)||ch == 32)
            {
                e.Handled = true;
                label25.Text = "Invalid Input";
                label25.Visible = true;
                return;
            }
            else
            {
                label25.Visible = false;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 127)
            {
                e.Handled = true;
            }
            if (cursorposition == 0 && ch == 46)
            {
                e.Handled = true;
                textBox9.Text = "0.";
                (sender as TextBox).SelectionStart = textBox9.TextLength;
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
            if (textBox9.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox9.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox9.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox9.TextLength == 7 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
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
            if (textBox9.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox9.TextLength; x++)
                {
                    if (textBox9.Text[x] == '.')
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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender,textBox1.Text);
            coute(e, sender, textBox1.Text);
        }
        public void coute(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (cursorposition == 0&&ch == 39)
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length - 1 && ch == 39)
            {
                if (text[cursorposition] == 39)
                {
                    e.Handled = true;
                }
            }
            if (cursorposition > 0 && ch == 39 && text[cursorposition - 1] == 39 || cursorposition > 0 && ch == 39 && text[cursorposition - 1] == ' ')
            {
                e.Handled = true;
            }
            if(cursorposition < text.Length)
            {
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == 39)
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {e.Handled = true;
                    textBox1.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox1.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox1.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox1.SelectionLength] == 39&&ch==8)
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(cursorposition, textBox1.SelectionLength+1);
                }
                if (ch == 8 && text[cursorposition + textBox1.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(cursorposition, textBox1.SelectionLength + 1);
                }
            }

            if (textBox1.SelectionLength > 0 && cursorposition + textBox1.SelectionLength < text.Length && cursorposition > 0 && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox1.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(cursorposition, textBox1.SelectionLength + 1);
                }
            }
        }
        public void coute2(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (cursorposition == 0 && ch == 39)
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length - 1 && ch == 39)
            {
                if (text[cursorposition] == 39)
                {
                    e.Handled = true;
                }
            }
            if (cursorposition > 0 && ch == 39 && text[cursorposition - 1] == 39 || cursorposition > 0 && ch == 39 && text[cursorposition - 1] == ' ')
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length)
            {
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == 39)
                {
                    e.Handled = true;
                    textBox2.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox2.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox2.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox2.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox2.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox2.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox2.Text = text.Remove(cursorposition, textBox2.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox2.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox2.Text = text.Remove(cursorposition, textBox2.SelectionLength + 1);
                }
            }

            if (textBox2.SelectionLength > 0 && cursorposition + textBox2.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox2.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox2.Text = text.Remove(cursorposition, textBox2.SelectionLength + 1);
                }
            }
        }
        public void coute3(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (cursorposition == 0 && ch == 39)
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length - 1 && ch == 39)
            {
                if (text[cursorposition] == 39)
                {
                    e.Handled = true;
                }
            }
            if (cursorposition > 0 && ch == 39 && text[cursorposition - 1] == 39 || cursorposition > 0 && ch == 39 && text[cursorposition - 1] == ' ')
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length)
            {
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == 39)
                {
                    e.Handled = true;
                    textBox3.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox3.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox3.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox3.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox3.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox3.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox3.Text = text.Remove(cursorposition, textBox3.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox3.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox3.Text = text.Remove(cursorposition, textBox3.SelectionLength + 1);
                }
            }

            if (textBox3.SelectionLength > 0 && cursorposition + textBox3.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox3.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox3.Text = text.Remove(cursorposition, textBox3.SelectionLength + 1);
                }
            }
        }
        public void coute4(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (cursorposition == 0 && ch == 39)
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length - 1 && ch == 39)
            {
                if (text[cursorposition] == 39)
                {
                    e.Handled = true;
                }
            }
            if (cursorposition > 0 && ch == 39 && text[cursorposition - 1] == 39 || cursorposition > 0 && ch == 39 && text[cursorposition - 1] == ' ')
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length)
            {
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == 39)
                {
                    e.Handled = true;
                    textBox7.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox7.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox7.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox7.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox7.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox7.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox7.Text = text.Remove(cursorposition, textBox7.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox7.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox7.Text = text.Remove(cursorposition, textBox7.SelectionLength + 1);
                }
            }

            if (textBox7.SelectionLength > 0 && cursorposition + textBox7.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox7.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox7.Text = text.Remove(cursorposition, textBox7.SelectionLength + 1);
                }
            }
        }
        public void coute5(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (cursorposition == 0 && ch == 39)
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length - 1 && ch == 39)
            {
                if (text[cursorposition] == 39)
                {
                    e.Handled = true;
                }
            }
            if (cursorposition > 0 && ch == 39 && text[cursorposition - 1] == 39 || cursorposition > 0 && ch == 39 && text[cursorposition - 1] == ' ')
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length)
            {
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == 39)
                {
                    e.Handled = true;
                    textBox8.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox8.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox8.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox8.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox8.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox8.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox8.Text = text.Remove(cursorposition, textBox8.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox8.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox8.Text = text.Remove(cursorposition, textBox8.SelectionLength + 1);
                }
            }

            if (textBox8.SelectionLength > 0 && cursorposition + textBox8.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox8.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox8.Text = text.Remove(cursorposition, textBox8.SelectionLength + 1);
                }
            }
        }
        public void validation(KeyPressEventArgs e, object sender,string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            /*
            if (ch == 39 && text.IndexOf("'") != -1)
            {
                e.Handled = true;
                return;
            }
             */
            if (!Char.IsLetter(ch) && ch != 8 && ch != 32 && ch != 127&&ch != 39)
            {
                e.Handled = true;
                label25.Text = "Invalid Input";
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
            }
            if (ch == 32)
            {
                if (cursorposition == 0)
                {
                        e.Handled = true;
                        label25.Text = "Invalid Input";
                        label25.Visible = true;
                }
                if (text.Length > cursorposition&&cursorposition != 0)
                {
                    if (text[cursorposition - 1] == 32 || text[cursorposition] == 32)
                    {
                        e.Handled = true;
                        label25.Text = "Invalid Input";
                        label25.Visible = true;

                    }
                }
                if (text.Length == 0)
                {
                    e.Handled = true;
                    label25.Text = "Invalid Input";
                    label25.Visible = true;
                }
                else if(cursorposition != 0)
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                        label25.Text = "Invalid Input";
                        label25.Visible = true;
                    }
                }
            }
 
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

            label25.Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            validation(e, sender,textBox2.Text);
            coute2(e, sender, textBox2.Text);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            label25.Visible = false;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

            label25.Visible = false;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

            label25.Visible = false;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox8.Text);
            coute5(e, sender, textBox8.Text);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

            validation(e, sender, textBox3.Text);
            coute3(e, sender, textBox3.Text);
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            validation(e, sender, textBox7.Text);
            coute4(e, sender, textBox4.Text);
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {

            label25.Visible = false;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox5.Text;
            if (ch == 39)
            {
                e.Handled = true;
                label25.Text = "Invalid Input";
                label25.Visible = true;
            }
            if (ch == 32)
            {
                e.Handled = true;
                label25.Text = "Invalid Input";
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            label25.Visible = false;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox4.Text;
            if (!Char.IsLetter(ch) &&!Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 127)
            {
                e.Handled = true;
                label25.Text = "Invalid Input";
                label25.Visible = true;
            }
            else
            {
                label25.Visible = false;
            }
            if (ch == 32)
            {
                if (cursorposition == 0)
                {
                    e.Handled = true;
                    label25.Text = "Invalid Input";
                    label25.Visible = true;
                }
                else
                {
                    label25.Visible = false;
                }
                if (text.Length > cursorposition)
                {
                    if (text[cursorposition - 1] == 32 || text[cursorposition] == 32)
                    {
                        e.Handled = true;
                        label25.Text = "Invalid Input";
                        label25.Visible = true;

                    }
                    else
                    {
                        label25.Visible = false;
                    }
                }
                if (text.Length == 0)
                {
                    e.Handled = true;
                    label25.Text = "Invalid Input";
                    label25.Visible = true;
                }
                else
                {
                    label25.Visible = false;
                }
                if (text.Length != 0)
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                        label25.Text = "Invalid Input";
                        label25.Visible = true;
                    }
                    else
                    {
                        label25.Visible = false;
                    }
                }
            }
            if (e.Handled == false)
            {
                label25.Visible = false;
            }
        }

        private void textBox9_MouseMove(object sender, MouseEventArgs e)
        {
            textBox9.SelectionLength = 0;
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
            string text=textBox1.Text.Replace("'","''");
            MessageBox.Show(text);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

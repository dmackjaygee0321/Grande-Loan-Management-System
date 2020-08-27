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
    public partial class updateborrowerinfo : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public updateborrowerinfo()
        {
            InitializeComponent();
        }
        public static string id;
        public static string search;
        string file1, file2;
        private void updateborrowerinfo_Load(object sender, EventArgs e)
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
            button3.Enabled = false;
            disable();
        }
        public void disable()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            dateTimePicker1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            butb1.Enabled = false;
            butb2.Enabled = false;
        }
        public void enable()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            dateTimePicker1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            butb1.Enabled = true;
            butb2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            search = textBox10.Text;
            dialogupdate d = new dialogupdate();
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                display();
            }
        }
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                button3.Enabled = true;
                textBox1.Text = dt.Rows[0].ItemArray[1].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
                dateTimePicker1.Text = dt.Rows[0].ItemArray[5].ToString();
                if (dt.Rows[0].ItemArray[6].ToString() == "Male")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
                textBox5.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox6.Text = dt.Rows[0].ItemArray[8].ToString();
                textBox7.Text = dt.Rows[0].ItemArray[9].ToString();
                textBox8.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox9.Text = dt.Rows[0].ItemArray[16].ToString();
                file1 = dt.Rows[0].ItemArray[12].ToString();
                file2 = dt.Rows[0].ItemArray[13].ToString();
                string replace = dt.Rows[0].ItemArray[12].ToString().Replace('*', '\\');
                string replace1 = dt.Rows[0].ItemArray[13].ToString().Replace('*', '\\');
                pbpic.Image = Image.FromFile(replace);
                pbpic1.Image = Image.FromFile(replace1);
            }
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

        public void update()
        {
            string sex = "Male";
            if (radioButton2.Checked == true)
            {
                sex = radioButton2.Text;
            }
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");
            string company = textBox7.Text.Trim().Replace("'", "''");
            string occupation = textBox8.Text.Trim().Replace("'", "''");
            string replace1 = file1.Replace('\\','*');
            string replace2 = file2.Replace('\\', '*');
            con.Open(); 
            string update = "update customerinfo set LastName = '"+lastname+"', FirstName='"+firstname+"', MiddleName = '"+middlename+
                "', Address = '"+textBox4.Text+"', Birthday = '"+dateTimePicker1.Text+"',Gender = '"+sex+"', EmailAddress = '"+textBox5.Text
                +"', PhoneNumber = '"+textBox6.Text+"', CompanyName = '"+company+"', Ocupation = '"+occupation+"', ProfilePic = '"+replace1
                +"', Signiture = '"+replace2+"', salary = '"+textBox9.Text+"' where No = '"+id+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

            Capital();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Capital();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "Update")
            {
                button3.Text = "Save";
                enable();
            }
            else
            {
                if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox4.Text != string.Empty &&
                       textBox5.Text != string.Empty && textBox6.Text!=string.Empty && textBox7.Text != string.Empty && textBox8.Text != string.Empty &&
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
                            if (textBox5.Text[x + 1] == '.' && x + 1 < textBox5.TextLength - 1)
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
                        update();
                        activitylog();
                        button3.Text = "Update";
                        disable();
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
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            number(e);
        }

        private void butb1_Click(object sender, EventArgs e)
        {
            opb1.Filter = "jpg|*.jpg";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                file1 = opb1.FileName.ToString();
                pbpic.Image = Image.FromFile(file1);
            }
        }

        private void butb2_Click(object sender, EventArgs e)
        {

            opb2.Filter = "jpg|*.jpg";
            DialogResult res = opb2.ShowDialog();
            if (res == DialogResult.OK)
            {
                file2 = opb2.FileName.ToString();
                pbpic1.Image = Image.FromFile(file2);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void validation(KeyPressEventArgs e, object sender, string text)
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
            if (!Char.IsLetter(ch) && ch != 8 && ch != 32 && ch != 127 && ch != 39)
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
                if (text.Length > cursorposition && cursorposition != 0)
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
                else if (cursorposition != 0)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox1.Text);
            coute(e, sender, textBox1.Text);
        }

        private void leave(object sender, EventArgs e)
        {
            label25.Visible = false;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            validation(e, sender, textBox2.Text);
            coute2(e, sender, textBox2.Text);
        }

        private void leave()
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox4.Text;

            if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 127)
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

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

            validation(e, sender, textBox7.Text);
            coute4(e, sender, textBox7.Text);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {

            validation(e, sender, textBox8.Text);
            coute5(e, sender, textBox8.Text);
        }
        public void qweqwe(KeyPressEventArgs e, object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox9.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (char.IsLetter(ch) || ch == 32)
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
            if (!Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 46 && ch != 127)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e, sender);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox3.Text);
            coute3(e, sender, textBox3.Text);
        }

        private void textBox9_MouseMove(object sender, MouseEventArgs e)
        {
            textBox9.SelectionLength = 0;
        }
        public void coute(KeyPressEventArgs e, object sender, string text)
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
                    textBox1.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
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
                if (text[cursorposition + textBox1.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(cursorposition, textBox1.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox1.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox1.Text = text.Remove(cursorposition, textBox1.SelectionLength + 1);
                }
            }

            if (textBox1.SelectionLength > 0 && cursorposition + textBox1.SelectionLength < text.Length && cursorposition > 0)
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
        public void activitylog()
        {
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");

            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update Borrower Information','" + lastname + " " + firstname + " " + middlename + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

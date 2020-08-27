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
    public partial class AddComaker : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public AddComaker()
        {
            InitializeComponent();
        }

        private void AddComaker_Load(object sender, EventArgs e)
        {
            textBox10.ShortcutsEnabled = false;
            textBox11.ShortcutsEnabled = false;
            textBox12.ShortcutsEnabled = false;
            textBox13.ShortcutsEnabled = false;
            textBox14.ShortcutsEnabled = false;
            textBox15.ShortcutsEnabled = false;
            textBox16.ShortcutsEnabled = false;
            textBox17.ShortcutsEnabled = false;
            textBox18.ShortcutsEnabled = false;
            textBox11.Visible = false;
            label19.Visible = false;
            label25.Visible = false;
            function();
        }
        public static string cid;
        public void function()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select Comaker from customerinfo where No = '"+CreditInvistigator.id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (dt.Rows[0].ItemArray[0].ToString() != "0")
            {
                button4.Visible = true;
                button3.Text = "Update";
                cid = dt.Rows[0].ItemArray[0].ToString();
                function1(dt.Rows[0].ItemArray[0].ToString());
            }
            else
            {
                button4.Visible = false;
                button3.Text = "Save";
            }
        }

        public void function1(string id)
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from comakerinfo where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            textBox18.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox17.Text = dt.Rows[0].ItemArray[2].ToString();
            textBox16.Text = dt.Rows[0].ItemArray[3].ToString();
            textBox15.Text = dt.Rows[0].ItemArray[4].ToString();
            dateTimePicker2.Text = dt.Rows[0].ItemArray[5].ToString();
            if (dt.Rows[0].ItemArray[6].ToString() == "Female")
            {
                radioButton3.Checked = true;
            }
            else
            {
                radioButton4.Checked = true;
            }
            textBox14.Text = dt.Rows[0].ItemArray[7].ToString();
            textBox13.Text = dt.Rows[0].ItemArray[8].ToString();
            textBox12.Text = dt.Rows[0].ItemArray[9].ToString();
            textBox10.Text = dt.Rows[0].ItemArray[10].ToString();
            textBox11.Text = dt.Rows[0].ItemArray[13].ToString();
            filename1 = dt.Rows[0].ItemArray[11].ToString().Replace('*','\\');
            filename2 = dt.Rows[0].ItemArray[12].ToString().Replace('*', '\\');

            pictureBox2.Image = Image.FromFile(filename1);
            pictureBox1.Image = Image.FromFile(filename2);

        }
        public void delete()
        {
            con.Open();
            string update = "update customerinfo set Comaker = '0' where No = '" + CreditInvistigator.id + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Form1.modes = 2;
            (this.Owner as Form1).timer4.Start();
        }
        public void save()
        {
            con.Open();
            string update = "update customerinfo set Comaker = '"+(ctr1-1)+"' where No = '" + CreditInvistigator.id + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update()
        {
            string sex;
            if (radioButton3.Checked == true)
            {
                sex = radioButton3.Text;
            }
            else
            {
                sex = radioButton4.Text;
            }
            string replace = filename1.Replace('\\', '*');
            string replace1 = filename2.Replace('\\', '*');
            string lastname = textBox18.Text.Trim().Replace("'", "''");
            string firstname = textBox17.Text.Trim().Replace("'", "''");
            string middlename = textBox16.Text.Trim().Replace("'", "''");
            string company = textBox12.Text.Trim().Replace("'", "''");
            string occupation = textBox10.Text.Trim().Replace("'", "''");
            con.Open();
            string update = "update comakerinfo set LastName = '"+lastname+
                "', FirstName = '"+firstname+"', MiddleName = '"+middlename+"', Address = '"+textBox15.Text+
                "', Birthday = '"+dateTimePicker2.Text+"', Gender = '"+sex+"', EmailAddress = '"+textBox14.Text+
                "', PhoneNumber = '"+textBox13.Text+"', CompanyName = '"+company+"',Ocupation = '"+occupation+
                "', salary = '"+textBox11.Text+"', ProfilePic = '"+replace+"', Signiture = '"+replace1+"' where No = '"+cid+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void number1(KeyPressEventArgs e)
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

        string sex,filename1,filename2;
        int ctr1;
        public void insertcomaker()
        {

            if (radioButton4.Checked == true)
                sex = radioButton4.Text;
            else
                sex = radioButton3.Text;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from usersettings";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            ctr1 = Convert.ToInt32(dt.Rows[0].ItemArray[4].ToString());
            string lastname = textBox18.Text.Trim().Replace("'", "''");
            string firstname = textBox17.Text.Trim().Replace("'", "''");
            string middlename = textBox16.Text.Trim().Replace("'", "''");
            string company =textBox12.Text.Trim().Replace("'", "''");
            string occupation = textBox10.Text.Trim().Replace("'", "''");
            string replace = filename1.Replace('\\', '*');
            string replace1 = filename2.Replace('\\', '*');
            string strAdd = "Insert Into comakerinfo values('"
                + ctr1 + "','" + lastname + "','" + firstname + "','" + middlename + "','" + textBox15.Text + "','" + dateTimePicker2.Text + "','" + sex + "','" + textBox14.Text + "','" + textBox13.Text + "','" +
                company + "','" + occupation + "','" + replace + "','" + replace1 + "','" + textBox11.Text + "');";

            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
        }

        public void updateid()
        {
            ctr1++;
            string update = "update usersettings set cono='" + ctr1.ToString() + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void capital()
        {
            textBox18.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox18.Text);
            textBox18.Select(textBox18.Text.Length, 0);
            textBox17.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox17.Text);
            textBox17.Select(textBox17.Text.Length, 0);
            textBox16.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox16.Text);
            textBox16.Select(textBox16.Text.Length, 0);
            textBox15.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox15.Text);
            textBox15.Select(textBox15.Text.Length, 0);
            textBox12.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox12.Text);
            textBox12.Select(textBox12.Text.Length, 0);
            textBox10.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox10.Text);
            textBox10.Select(textBox10.Text.Length, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            opb3.Filter = "jpg|*.jpg";
            DialogResult res = opb3.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename1 = opb3.FileName.ToString();
                pictureBox2.Image = Image.FromFile(filename1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            opb4.Filter = "jpg|*.jpg";
            DialogResult res = opb4.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename2 = opb4.FileName.ToString();
                pictureBox1.Image = Image.FromFile(filename2);
            }
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            capital();
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

            capital();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

            capital();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

            capital();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

            capital();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

            capital();
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            number1(e);
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e,sender);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox10.Text != string.Empty && textBox11.Text != string.Empty && textBox12.Text != string.Empty &&
                    textBox13.Text != string.Empty && textBox14.Text != string.Empty && textBox15.Text != string.Empty &&
                    textBox17.Text != string.Empty && textBox18.Text != string.Empty &&
                    pictureBox1.Image != null && pictureBox2.Image != null)
                {
                    if (textBox13.TextLength < 11)
                    {
                        MessageBox.Show("Please input valid phone number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    for (int x = 0; x < textBox14.TextLength; x++)
                    {
                        if (textBox14.Text[x] == '@')
                        {
                            if (textBox14.Text[x + 1] == '.' && x + 1 < textBox14.TextLength - 1)
                            {
                                MessageBox.Show("Please input valid email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    if (!textBox14.Text.Trim().Contains("@") || !textBox14.Text.Trim().Contains(".com"))
                    {
                        MessageBox.Show("Please input valid email!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    DateTime dp = Convert.ToDateTime(dateTimePicker2.Text);
                    int year = dp.Year;
                    int nowyear = DateTime.Now.Year;
                    int age = nowyear - year;
                    if (age < 18)
                    {
                        MessageBox.Show("Age must be 18 and above!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (button3.Text == "Save")
                    {
                        insertcomaker();
                        updateid();
                        save();
                    }
                    else
                    {
                        update();
                    }
                    activitylog();
                    MessageBox.Show("Successfully Saved");
                    Form1.modes = 2;
                    (this.Owner as Form1).timer4.Start();
                }
                else
                {
                    MessageBox.Show("Fill out all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void activitylog()
        {
            string fn = string.Empty;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '"+CreditInvistigator.id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fn = dt.Rows[0].ItemArray[1].ToString().Trim() + " " + dt.Rows[0].ItemArray[2].ToString().Trim() + " " + dt.Rows[0].ItemArray[3].ToString().Trim();
            string text = string.Empty;
            if (button3.Text == "Save")
            {
                text = "Add Comaker";
            }
            else
            {
                text = "Update Comaker Information";
            }
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'"+text+"','" + fn.Replace("'","''") + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void activitylogdelete()
        {
            string fn = string.Empty;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '" + CreditInvistigator.id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fn = dt.Rows[0].ItemArray[1].ToString().Trim() + " " + dt.Rows[0].ItemArray[2].ToString().Trim() + " " + dt.Rows[0].ItemArray[3].ToString().Trim();
            
            string text = "Delete Comaker";
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'" + text + "','" + fn + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form1.modes = 2;
            (this.Owner as Form1).timer4.Start();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete();
            activitylogdelete();
        }

        public void qweqwe(KeyPressEventArgs e, object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox11.Text.IndexOf('.') != -1)
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
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 127)
            {
                e.Handled = true;
            }
            if (cursorposition == 0 && ch == 46)
            {
                e.Handled = true;
                textBox11.Text = "0.";
                (sender as TextBox).SelectionStart = textBox11.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox11.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox11.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox11.TextLength == 1 && textBox11.Text[0] == '0')
                {
                    textBox11.Clear();
                }
            }
            if (ch == 8 && textBox11.TextLength == 1 || ch == 8 && textBox11.TextLength == 0)
            {
                textBox11.Text = "0";
                e.Handled = true;
            }
            if (textBox11.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox11.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox11.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox11.TextLength == 7 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text = textBox11.Text;
                for (int x = 0; x < textBox11.TextLength; x++)
                {
                    if (textBox11.Text[x] != '0' && x > 0)
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
                    textBox11.Text = text.Remove(0, count);
                    if (textBox11.Text == string.Empty)
                    {
                        textBox11.Text = "0";
                    }
                }
            }
            if (textBox11.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox11.TextLength; x++)
                {
                    if (textBox11.Text[x] == '.')
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_MouseMove(object sender, MouseEventArgs e)
        {
            textBox11.SelectionLength = 0;
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox15.Text;
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

        private void textBox15_Leave(object sender, EventArgs e)
        {
            label25.Visible = false;
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
                    textBox12.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox12.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox12.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox12.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox12.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox12.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox12.Text = text.Remove(cursorposition, textBox12.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox12.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox12.Text = text.Remove(cursorposition, textBox12.SelectionLength + 1);
                }
            }

            if (textBox12.SelectionLength > 0 && cursorposition + textBox12.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox12.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox12.Text = text.Remove(cursorposition, textBox12.SelectionLength + 1);
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
                    textBox10.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox10.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox10.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox10.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox10.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox10.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox10.Text = text.Remove(cursorposition, textBox10.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox10.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox10.Text = text.Remove(cursorposition, textBox10.SelectionLength + 1);
                }
            }

            if (textBox10.SelectionLength > 0 && cursorposition + textBox10.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox10.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox10.Text = text.Remove(cursorposition, textBox10.SelectionLength + 1);
                }
            }
        }
        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox14.Text;

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

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox18.Text);
            coute(e, sender, textBox18.Text);
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox17.Text);
            coute2(e, sender, textBox17.Text);
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox16.Text);
            coute3(e, sender, textBox16.Text);
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox12.Text);
            coute4(e, sender, textBox12.Text);
        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
            label25.Visible = false;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox10.Text);
            coute5(e, sender, textBox10.Text);
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
                    textBox18.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox18.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox18.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox18.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox18.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox18.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox18.Text = text.Remove(cursorposition, textBox18.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox18.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox18.Text = text.Remove(cursorposition, textBox18.SelectionLength + 1);
                }
            }

            if (textBox18.SelectionLength > 0 && cursorposition + textBox18.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox18.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox18.Text = text.Remove(cursorposition, textBox18.SelectionLength + 1);
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
                    textBox17.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox17.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox17.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox17.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox17.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox17.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox17.Text = text.Remove(cursorposition, textBox17.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox17.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox17.Text = text.Remove(cursorposition, textBox17.SelectionLength + 1);
                }
            }

            if (textBox17.SelectionLength > 0 && cursorposition + textBox17.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox17.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox17.Text = text.Remove(cursorposition, textBox17.SelectionLength + 1);
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
                    textBox16.Text = text.Remove(0, cursorposition + 1);
                }
                if (ch == 8 && cursorposition == 1 && text[cursorposition] == ' ')
                {
                    e.Handled = true;
                    textBox16.Text = text.Remove(0, cursorposition + 1);
                }
            }
            if (cursorposition < text.Length && cursorposition > 1)
            {
                if (ch == 8 && text[cursorposition - 2] == ' ' && text[cursorposition] == 39 && cursorposition > 0)
                {
                    e.Handled = true;
                    textBox16.Text = text.Remove(cursorposition - 1, 2);
                }
            }
            //Mack jaygee's
            if (textBox16.SelectionLength > 0 && cursorposition == 0 && cursorposition + textBox16.SelectionLength < text.Length)
            {
                if (text[cursorposition + textBox16.SelectionLength] == 39 && ch == 8)
                {
                    e.Handled = true;
                    textBox16.Text = text.Remove(cursorposition, textBox16.SelectionLength + 1);
                }
                if (ch == 8 && text[cursorposition + textBox16.SelectionLength] == ' ')
                {
                    e.Handled = true;
                    textBox16.Text = text.Remove(cursorposition, textBox16.SelectionLength + 1);
                }
            }

            if (textBox16.SelectionLength > 0 && cursorposition + textBox16.SelectionLength < text.Length && cursorposition > 0)
            {
                if (text[cursorposition - 1] == ' ' && ch == 8 && text[cursorposition + textBox16.SelectionLength] == 39)
                {
                    e.Handled = true;
                    textBox16.Text = text.Remove(cursorposition, textBox16.SelectionLength + 1);
                }
            }
        }
    }
}

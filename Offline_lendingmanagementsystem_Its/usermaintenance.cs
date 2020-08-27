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
using System.Reflection;
using System.IO;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class usermaintenance : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();

        public usermaintenance()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        public static string id;
        private void usermaintenance_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            textBox3.ShortcutsEnabled = false;
            textBox4.ShortcutsEnabled = false;
            textBox5.ShortcutsEnabled = false;
            label25.Visible = false;
            userlevel();
            display();
            disable();
        }
        public void disable()
        {
            if (id == "101" || id == "128")
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }
        public void userlevel()
        {
            comboBox1.Items.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from userlevel";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();

            for (int x = 0; x < dt.Rows.Count; x++)
            {
                comboBox1.Items.Add(dt.Rows[x].ItemArray[1].ToString());
            }

            comboBox1.SelectedIndex = 0;
        }

        string filename;
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from user where id='"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            textBox1.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[2].ToString();
            textBox3.Text = dt.Rows[0].ItemArray[3].ToString();
            comboBox1.Text = dt.Rows[0].ItemArray[4].ToString();
            textBox4.Text = dt.Rows[0].ItemArray[5].ToString();
            textBox5.Text = dt.Rows[0].ItemArray[6].ToString();
            label2.Text += dt.Rows[0].ItemArray[0].ToString();
            filename = dt.Rows[0].ItemArray[7].ToString();
            if (filename != "null")
            {
                string replace = filename.Replace('*', '\\');
                pictureBox2.Image = Image.FromFile(replace);
            }
            else
            {
                Assembly s = Assembly.GetExecutingAssembly();
                Stream ss = s.GetManifestResourceStream("Offline_lendingmanagementsystem_Its.qwe.jpg");
                Bitmap img1 = new Bitmap(ss);
                pictureBox2.Image = img1;
            }
            if (dt.Rows[0].ItemArray[8].ToString() == "0")
            {
                button2.Text = "Activate";
            }
            else
            {
                button2.Text = "Deactivate";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            opb1.Filter = "jpg|*.jpg";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename = opb1.FileName.ToString();
                pictureBox2.Image = Image.FromFile(filename);
            }
        }

        public void delete()
        {
            con.Open();
            string delete = "delete from user where id='" + id.ToString() + "'";
            cmd = new OdbcCommand(delete, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void update()
        {
            con.Open();
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");
            string replace = filename.Replace('\\', '*');
            string update = "update user set lname ='" + lastname + "',fname ='" + firstname + "',mname ='" + middlename + "',userlevel = '" + comboBox1.Text + "',username = '" + textBox4.Text + "',password = '" + textBox5.Text + "',profile = '"+replace+"' where id = '"+id+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            activity();
        }

        public void active_inactive()
        {
            int act = 1;
            if (button2.Text == "Deactivate")
            {
                act = 0;    
            }
            con.Open();
            string delete = "update user set status = '"+act+"' where id = '"+id+"'";
            cmd = new OdbcCommand(delete, con);
            cmd.ExecuteNonQuery();
            con.Close();
            deleteactivity();
            if (button2.Text == "Deactivate")
            {
                button2.Text = "Activate";
            }
            else
            {
                button2.Text = "Deactivate";
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            dialogactivate d = new dialogactivate();
            dialogactivate.text = button2.Text;
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                active_inactive();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty && pictureBox2.Image != null)
            {
                int error = 0;
                string texterror = "Your Password ";
                string pass = textBox5.Text;
                if (pass.Length <= 7)
                {
                    error++;
                    texterror += "Password is atleast 8 characters\n";
                }
                int valid = 0;
                foreach (char c in pass)
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        valid++;
                        break;
                    }
                }
                if (valid == 0)
                {
                    error++;
                    texterror += "must Atleast one lower case letter \n";
                }
                valid = 0;
                foreach (char c in pass)
                {
                    if (c >= 'A' && c <= 'Z')
                    {
                        valid++;
                        break;
                    }
                }
                if (valid == 0)
                {

                    error++;
                    texterror += "must Atleast one Upper Case letter\n";
                }
                valid = 0;
                foreach (char c in pass)
                {
                    if (c >= '0' && c <= '9')
                    {
                        valid++;
                        break;
                    }
                }
                if (valid == 0)
                {
                    error++;
                    texterror += "must Atleast one number \n";
                }
                valid = 0;
                char[] special = { '@', '#', '$', '%', '^', '&', '+', '=', '_' };
                foreach (char c in pass)
                {
                    for (int x = 0; x < special.Length; x++)
                    {
                        if (c == special[x])
                        {
                            valid++;
                            break;
                        }
                    }
                }
                if (valid == 0)
                {
                    error++;
                    texterror += " must alteast one special character\n";
                }
                if (error == 0)
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    string strAcct = "Select * from user";
                    da = new OdbcDataAdapter(strAcct, con);
                    da.Fill(dt);
                    con.Close();
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        if (textBox1.Text.ToLower().Trim() == dt.Rows[x].ItemArray[1].ToString().ToLower().Trim() && textBox2.Text.ToLower().Trim() == dt.Rows[x].ItemArray[2].ToString().ToLower().Trim() && textBox3.Text.ToLower().Trim() == dt.Rows[x].ItemArray[3].ToString().ToLower().Trim() && id != dt.Rows[x].ItemArray[0].ToString())
                        {
                            MessageBox.Show("User Is Already Existed");
                            break;
                        }
                        else if (textBox4.Text.Trim() == dt.Rows[x].ItemArray[5].ToString().Trim() && id != dt.Rows[x].ItemArray[0].ToString())
                        {
                            MessageBox.Show("Username Is Already Existed");
                            break;
                        }
                        else if (x == dt.Rows.Count - 1)
                        {
                            update();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(texterror, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill out all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void activity()
        {
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update User Information','" + lastname + " " + firstname + " " + middlename + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteactivity()
        {
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");
            string text = string.Empty;
            if (button2.Text == "Activate")
            {
                text = "Activate User";
            }
            else
            {
                text = "Deactivate User";
            }
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'"+text+"','" + lastname + " " + firstname + " " + middlename + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void usermaintenance_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void hayahay(object sender, EventArgs e)
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
            textBox2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox2.Text);
            textBox2.Select(textBox2.Text.Length, 0);
            textBox3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox3.Text);
            textBox3.Select(textBox3.Text.Length, 0); 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox1.Text);
            coute(e, sender, textBox1.Text);
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox2.Text);
            coute2(e, sender, textBox2.Text);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox3.Text);
            coute3(e, sender, textBox3.Text);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox4.Text;

            if (ch == 32||ch == 39)
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
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox4.Text;

            if (ch == 32 || ch == 39)
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

        private void hayahay2(object sender, EventArgs e)
        {
            label25.Visible = false;
        }

        public void activitylog()
        {

            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update User Information','" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

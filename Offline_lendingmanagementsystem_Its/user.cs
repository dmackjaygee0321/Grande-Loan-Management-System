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
    public partial class user : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public user()
        {
            InitializeComponent();
        }

        private void user_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            textBox3.ShortcutsEnabled = false;
            textBox4.ShortcutsEnabled = false;
            textBox5.ShortcutsEnabled = false;
            label25.Visible = false;
            vScrollBar1.Maximum = 300;
            vScrollBar1.Minimum = -57;
            vScrollBar1.Value = -57;
            userlevel();
            display();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty && textBox3.Text != string.Empty && textBox4.Text != string.Empty && textBox5.Text != string.Empty&&pictureBox2.Image!=null)
            {
                int error = 0;
                string texterror = "Your Password ";
                string pass = textBox5.Text;
                if (pass.Length <= 7)
                {
                    error++;
                    texterror+="Password is atleast 8 characters\n";
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
                        if (textBox1.Text.ToLower().Trim() == dt.Rows[x].ItemArray[1].ToString().ToLower().Trim() && textBox2.Text.ToLower().Trim() == dt.Rows[x].ItemArray[2].ToString().ToLower().Trim() && textBox3.Text.ToLower().Trim() == dt.Rows[x].ItemArray[3].ToString().ToLower().Trim())
                        {
                            MessageBox.Show("User Is Already Existed");
                            break;
                        }
                        else if (textBox4.Text.Trim() == dt.Rows[x].ItemArray[5].ToString().Trim())
                        {
                            MessageBox.Show("Username Is Already Existed");
                            break;
                        }
                        else if (x == dt.Rows.Count - 1)
                        {

                            MessageBox.Show("Saved Successfully");
                            adduser();
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
                MessageBox.Show("Fill out all fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void activity()
        {
            string lastname = textBox1.Text.Trim().Replace("'", "''");
            string firstname = textBox2.Text.Trim().Replace("'", "''");
            string middlename = textBox3.Text.Trim().Replace("'", "''");
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Add User','" + lastname + " " + firstname + " " + middlename + " As " + comboBox1.Text + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        int ctr;
        public void adduser()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "Select * from usersettings";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                ctr = Convert.ToInt32(dt.Rows[0].ItemArray[6]);
                string replace = filename.Replace('\\', '*');
                string lastname = textBox1.Text.Trim().Replace("'", "''");
                string firstname = textBox2.Text.Trim().Replace("'", "''");
                string middlename = textBox3.Text.Trim().Replace("'", "''");
                string strAdd = "Insert Into user values('" + dt.Rows[0].ItemArray[6] + "','" + lastname + "','" + firstname + "','" + middlename + "','" + comboBox1.Text + "','" + textBox4.Text.Trim() + "','" + textBox5.Text.Trim() + "','" + replace + "','1')";
                cmd = new OdbcCommand(strAdd, con);
                cmd.ExecuteNonQuery();
                con.Close();
                updatetid();
                activity();
                clear();
                display();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = 0;
            pictureBox2.Image = null;
        }

        public void updatetid()
        {
            ctr++;
            con.Open();
            string update = "update usersettings set userno='" + ctr.ToString() + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        string filename;
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

        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from user";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            dataGridView1.Rows.Clear();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                string status = "Active";
                if (dt.Rows[x].ItemArray[8].ToString() == "0")
                {
                    status = "Deactivated";
                }
                dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[4].ToString(),status);
            }
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, (vScrollBar1.Value - (vScrollBar1.Value * 2)));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usermaintenance.id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            usermaintenance up=new usermaintenance();
            up.StartPosition = FormStartPosition.CenterParent;
            up.ShowDialog();
            if (up.DialogResult == DialogResult.OK)
            {
                display();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void capital()
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
            textBox2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox2.Text);
            textBox2.Select(textBox2.Text.Length, 0);
            textBox3.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox3.Text);
            textBox3.Select(textBox3.Text.Length, 0); 
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            capital();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            capital();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            capital();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox1.Text);
            coute(e, sender, textBox1.Text);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            label25.Visible = false;
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
    }
}

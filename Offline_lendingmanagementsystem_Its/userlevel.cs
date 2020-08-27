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
    public partial class userlevel : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public userlevel()
        {
            InitializeComponent();
        }

        private void userlevel_Load(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = 283;
            vScrollBar1.Minimum = -57;
            vScrollBar1.Value = -57;
            display();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, (vScrollBar1.Value - (vScrollBar1.Value * 2)));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty)
            {
                string r1 = "no", r2 = "no", r3 = "no", r4 = "no", r5 = "no", r6 = "no", r7 = "no", r8 = "no", r9 = "no";
                if (checkBox1.Checked == true)
                {
                    r1 = "yes";
                }
                if (checkBox2.Checked == true)
                {
                    r2 = "yes";
                }
                if (checkBox3.Checked == true)
                {
                    r3 = "yes";
                }
                if (checkBox4.Checked == true)
                {
                    r4 = "yes";
                }
                if (checkBox5.Checked == true)
                {
                    r5 = "yes";
                }
                if (checkBox6.Checked == true)
                {
                    r6 = "yes";
                }
                if (checkBox7.Checked == true)
                {
                    r7 = "yes";
                }
                if (checkBox8.Checked == true)
                {
                    r8 = "yes";
                }
                if (checkBox10.Checked == true)
                {
                    r9 = "yes";
                }
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "Select * from userlevel";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    if (textBox1.Text.Trim() == dt.Rows[x].ItemArray[1].ToString().Trim())
                    {
                        MessageBox.Show("This type is already Existed");
                        break;
                    }
                    else if (x == dt.Rows.Count - 1)
                    {
                        insertuserlvl(r1, r2, r3, r4, r5, r6, r7, r8, r9);

                    }
                }
            }
            else
            {
                MessageBox.Show("Fill up all!");
            }
        }

        public void insertuserlvl(string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9)
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "Select * from usersettings";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                ctr = Convert.ToInt32(dt.Rows[0].ItemArray[5]);
                string strAdd = "Insert Into userlevel values('" + dt.Rows[0].ItemArray[5] + "','" + textBox1.Text + "','" + r1 + "','" + r2 + "','" + r3 + "','" + r4 + "','" + r5 + "','" + r6 + "','" + r7 + "','" + r8 + "','" + r9 + "')";
                
                cmd = new OdbcCommand(strAdd, con);
                cmd.ExecuteNonQuery();
                con.Close();
                updatetid();
                MessageBox.Show("Successfuly added");
                activity();
                clear();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        int ctr;
        public void updatetid()
        {
            ctr++;
            con.Open();
            string update = "update usersettings set userlvlno='" + ctr.ToString() + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void clear()
        {
            textBox1.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
        }

        public void display()
        {
            try
            {
                dataGridView1.Rows.Clear();
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "Select * from userlevel";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                for(int x=0;x < dt.Rows.Count;x++)
                {
                    dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[4].ToString(), dt.Rows[x].ItemArray[5].ToString(), dt.Rows[x].ItemArray[6].ToString(), dt.Rows[x].ItemArray[7].ToString(), dt.Rows[x].ItemArray[8].ToString(), dt.Rows[x].ItemArray[9].ToString(), dt.Rows[x].ItemArray[10].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updatedeleteuserlvl.id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            updatedeleteuserlvl up = new updatedeleteuserlvl();
            up.StartPosition = FormStartPosition.CenterParent;
            up.ShowDialog();
            if (up.DialogResult == DialogResult.OK)
            {
                display();
            }

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender,textBox1.Text);
            coute5(e, sender,textBox1.Text);
        }

        public void coute5(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (cursorposition == 0 && ch == 39)
            {
                e.Handled = true;
            }
            if (cursorposition < text.Length - 1&&ch == 39)
            {
                if (text[cursorposition] == 39)
                {
                    e.Handled = true;
                }
            }
            if (cursorposition > 0 && ch == 39 && text[cursorposition - 1] == 39 || cursorposition > 0 && ch == 39 && text[cursorposition-1] == ' ')
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
            }
            if (ch == 32)
            {
                if (cursorposition == 0)
                {
                    e.Handled = true;
                }
                if (text.Length > cursorposition && cursorposition != 0)
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
                else if (cursorposition != 0)
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
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox10.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox10.Checked = false;
            }
        }

        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Add User Type','" + textBox1.Text.Trim() + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

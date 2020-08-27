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
    public partial class updateborrowerattachment : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public updateborrowerattachment()
        {
            InitializeComponent();
        }
        public static string id;
        public void displaytypes()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select type from deduction_tbl";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                comboBox1.Items.Add(dt.Rows[x].ItemArray[0].ToString());
            }
            comboBox1.SelectedIndex = 0;
        }
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select * from borrower_deduction where no = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            comboBox1.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox1.Text = dt.Rows[0].ItemArray[3].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[2].ToString(); 
        }
        private void updateborrowerattachment_Load(object sender, EventArgs e)
        {
            displaytypes();
            display();
        }
        public void delete()
        {
            con.Open();
            string update = "delete from borrower_deduction where no = '"+id+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void update()
        {
            con.Open();
            string update = "update borrower_deduction set type = '"+comboBox1.Text+"',description = '"+textBox1.Text+"',amount='"+textBox2.Text+"' where no = '" + id + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            delete();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty && Convert.ToDouble(textBox2.Text) == 0)
            {
                MessageBox.Show("Fill out all Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Convert.ToDouble(textBox2.Text) == 0)
            {
                MessageBox.Show("Please input valid amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Fill out all Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            update();
            this.DialogResult = DialogResult.OK;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe1(e, sender);
        }

        public void qweqwe1(KeyPressEventArgs e, object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (char.IsLetter(ch))
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
        }
    }
}

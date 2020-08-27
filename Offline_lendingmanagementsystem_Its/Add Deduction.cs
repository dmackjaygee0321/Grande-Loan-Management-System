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
    public partial class Add_Deduction : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Add_Deduction()
        {
            InitializeComponent();
        }

        private void Add_Deduction_Load(object sender, EventArgs e)
        {
            displaytypes();
        }
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
        public void add()
        {
            try
            {
                con.Open();
                string update = "insert into borrower_deduction values('" + CreditInvistigator.id + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox1.Text + "',null)";
                cmd = new OdbcCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty&&Convert.ToDouble(textBox2.Text) == 0)
            {
                MessageBox.Show("Fill out all Fields","Error" , MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            add();
            this.DialogResult = DialogResult.OK;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe1(e,sender);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox1.Text;
            if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 127)
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
                if (text.Length != 0)
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
    }
}

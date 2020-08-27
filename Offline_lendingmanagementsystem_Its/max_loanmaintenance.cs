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
    public partial class max_loanmaintenance : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public max_loanmaintenance()
        {
            InitializeComponent();
        }
        public void pdisplay()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select pminamount, pminsalary from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from pmaxloanmaintenance order by salary";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            dataGridView1.Rows.Add(dt.Rows[0].ItemArray[1].ToString(), dt.Rows[0].ItemArray[0].ToString());
            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                dataGridView1.Rows.Add(dt1.Rows[x].ItemArray[0].ToString(), dt1.Rows[x].ItemArray[1].ToString());
            }
        }
        public void gdisplay()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select gminamount, pminsalary from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from gmaxloanmaintenance order by salary";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            dataGridView1.Rows.Add(dt.Rows[0].ItemArray[1].ToString(), dt.Rows[0].ItemArray[0].ToString());
            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                dataGridView1.Rows.Add(dt1.Rows[x].ItemArray[0].ToString(), dt1.Rows[x].ItemArray[1].ToString());
            }
        }
        private void max_loanmaintenance_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                pdisplay();
            }
            else
            {
                gdisplay();
            }
        }

        public void pinsert()
        {
            con.Open();
            string update = "insert into pmaxloanmaintenance values('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            pdisplay();
        }
        public void ginsert()
        {
            con.Open();
            string update = "insert into gmaxloanmaintenance values('" + textBox1.Text + "','" + textBox2.Text + "')";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            pdisplay();
        }
        double min, max;
        public void prange()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select pminamount, pminsalary from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from pmaxloanmaintenance order by salary";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            double[,] table = new double[dt1.Rows.Count + 1, 2];
            table[0,0] = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
            table[0, 1] = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
            for (int x = 1; x < dt1.Rows.Count + 1; x++)
            {
                table[x, 0] = Convert.ToDouble(dt1.Rows[x-1].ItemArray[0].ToString());
                table[x, 1] = Convert.ToDouble(dt1.Rows[x-1].ItemArray[1].ToString());
            }
            double salary = 0;
            if (textBox1.Text != string.Empty)
            {
                salary = Convert.ToDouble(textBox1.Text);
            }
            if (dt1.Rows.Count > 0)
            {
                for (int x = dt1.Rows.Count; x >= 0; x--)
                {
                    if (salary > table[x, 0] && x == dt1.Rows.Count)
                    {
                        min = table[x, 1];
                        max = 0;
                        break;
                    }
                    else if (salary == table[x, 0] && x == dt1.Rows.Count)
                    {
                        min = table[x - 1, 1];
                        max = table[x, 1];
                        break;
                    }
                    if (salary >= table[x, 0])
                    {
                        min = table[x, 1];
                        max = table[x + 1, 1];
                        break;
                    }
                    else if (x == 0)
                    {
                        min = table[x, 1];
                        max = table[x + 1, 1];
                    }
                }
            }
            else
            {
                min = table[0, 1];
                max = 0;
            }
        }
        public void grange()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select gminamount, pminsalary from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from gmaxloanmaintenance order by salary";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            double[,] table = new double[dt1.Rows.Count + 1, 2];
            table[0, 0] = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
            table[0, 1] = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
            for (int x = 1; x < dt1.Rows.Count + 1; x++)
            {
                table[x, 0] = Convert.ToDouble(dt1.Rows[x - 1].ItemArray[0].ToString());
                table[x, 1] = Convert.ToDouble(dt1.Rows[x - 1].ItemArray[1].ToString());
            }
            double salary = 0;
            if (textBox1.Text != string.Empty)
            {
                salary = Convert.ToDouble(textBox1.Text);
            }
            if (dt1.Rows.Count > 0)
            {
                for (int x = dt1.Rows.Count; x >= 0; x--)
                {
                    if (salary > table[x, 0] && x == dt1.Rows.Count)
                    {
                        min = table[x, 1];
                        max = 0;
                        break;
                    }
                    else if (salary == table[x, 0] && x == dt1.Rows.Count)
                    {
                        min = table[x - 1, 1];
                        max = table[x, 1];
                        break;
                    }
                    if (salary >= table[x, 0])
                    {
                        min = table[x, 1];
                        max = table[x + 1, 1];
                        break;
                    }
                    else if (x == 0)
                    {
                        min = table[x, 1];
                        max = table[x + 1, 1];
                    }
                }
            }
            else
            {
                min = table[0, 1];
                max = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox1.Text) != 0 && Convert.ToDouble(textBox2.Text) != 0)
            {
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {

                    if ((Convert.ToDouble(textBox1.Text) > Convert.ToDouble(dataGridView1.Rows[x].Cells[0].Value.ToString())) && (Convert.ToDouble(textBox1.Text) - Convert.ToDouble(dataGridView1.Rows[x].Cells[0].Value.ToString())) < 5000)
                    {
                        MessageBox.Show("More Than 5000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                    
                    if ((Convert.ToDouble(textBox1.Text) < Convert.ToDouble(dataGridView1.Rows[x].Cells[0].Value.ToString())) && (Convert.ToDouble(dataGridView1.Rows[x].Cells[0].Value.ToString()) - Convert.ToDouble(textBox1.Text)) < 5000)
                    {
                        MessageBox.Show("More Than 5000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (comboBox1.SelectedIndex == 0)
                {
                    con.Close();
                    prange();
                    if (max == 0 && min >= Convert.ToDouble(textBox2.Text))
                    {
                        MessageBox.Show("Invalid Range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (max != 0 && min >= Convert.ToDouble(textBox2.Text) || max != 0 && max <= Convert.ToDouble(textBox2.Text))
                    {
                        MessageBox.Show("Invalid Range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    pinsert();
                    pdisplay();
                }
                else
                {
                    grange();
                    if (max == 0 && min >= Convert.ToDouble(textBox2.Text))
                    {
                        MessageBox.Show("Invalid Range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (max != 0 && min >= Convert.ToDouble(textBox2.Text) || max != 0 && max <= Convert.ToDouble(textBox2.Text))
                    {
                        MessageBox.Show("Invalid Range", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ginsert();
                    gdisplay();
                }
                clear();
            }
            else
            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > 0)
            {
                dialogm d = new dialogm();
                d.ShowDialog();
                if (d.DialogResult == DialogResult.OK)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        pdelete();
                    }
                    else
                    {
                        gdelete();
                    }
                }
            }
            else
            {
                MessageBox.Show("Default Salary", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void pdelete()
        {
            con.Open();
            string update = "delete from pmaxloanmaintenance where salary = '"+dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            pdisplay();
        }

        public void gdelete()
        {
            con.Open();
            string update = "delete from gmaxloanmaintenance where salary = '" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            pdisplay();
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
        public void qweqwe1(KeyPressEventArgs e, object sender)
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e,sender);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe1(e, sender);
        }
    }
}

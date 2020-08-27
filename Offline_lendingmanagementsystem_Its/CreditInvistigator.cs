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
    public partial class CreditInvistigator : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public CreditInvistigator()
        {
            InitializeComponent();
        }
        public static string id, search;
        public static int process;
        private void CreditInvistigator_Load(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = 573;
            vScrollBar1.Minimum = -90;
            vScrollBar1.Value = -90;
            comboBox1.Enabled = false;
            button7.Visible = false;
            button5.Visible = false;
            textBox2.Visible = false;
            textBox18.ShortcutsEnabled = false;
            if (process == 1)
            {
                process = 0;
                displayinfo();
                displayattachment();
                disabled();
                disableability();
                comboBox1.SelectedIndex = 0;
                displayability();
                displaydeduction();
                displayragec();
            
            }
            disabled();
            disableability();
        }
        public void disableability()
        {
            textBox2.Enabled = false;
            textBox18.Enabled = false;
            checkBox1.Enabled = false;
            button2.Text = "Update";
        }
        public void displaydeduction()
        {
            dataGridView2.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select * from borrower_deduction where ID = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            double total = 0;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                double d = Convert.ToDouble(dt.Rows[x].ItemArray[2].ToString());
                total += d;
                dataGridView2.Rows.Add(dt.Rows[x].ItemArray[4].ToString(),dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[3].ToString(),d.ToString("n2"));
            }
            label10.Text = total.ToString("n2");
            double salary = Convert.ToDouble(label18.Text);
            double grandtotal = salary - total;
            if (grandtotal < 0)
            {
                grandtotal = 0;
            }
            label11.Text = grandtotal.ToString("n2");
        }
        public void displayrange()
        {
            try
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "select pminterm,pmaxterm,pinterest from loanmaintenance";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                int min = Convert.ToInt32(dt.Rows[0].ItemArray[0].ToString());
                int max = Convert.ToInt32(dt.Rows[0].ItemArray[1].ToString());
                double i = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString()) / 100;
                double salary = Convert.ToDouble(label11.Text);
                double a = Math.Pow((1 + i), max);
                double b = 1 / a;
                double c = 1 - b;
                double d = salary / i;
                double e = d * c;

                double f = Math.Pow((1 + i), min);
                double g = 1 / f;
                double h = 1 - g;
                double j = salary / i;
                double k = j * h;
                if (e < 0)
                {
                    e = 0;
                }
                if (k < 0)
                {
                    k = 0;
                }

                label14.Text = e.ToString("n2");
                label17.Text = k.ToString("n2");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void displayability()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select salary, maxloan_e, approved_p,approved_e,maxloan_p from customerinfo where No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label18.Text = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()).ToString("n2");
            if (comboBox1.SelectedIndex == 0)
            {
                textBox18.Text = dt.Rows[0].ItemArray[4].ToString();
                if (dt.Rows[0].ItemArray[2].ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            if (comboBox1.SelectedIndex == 1)
            {
                textBox18.Text = dt.Rows[0].ItemArray[1].ToString();
                if (dt.Rows[0].ItemArray[3].ToString() == "1")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
        }
        public void disabled()
        {
            if (label4.Text == "ID No.:")
            {
                button2.Enabled = false;
                button4.Enabled = false;
                button1.Enabled = false;
                button5.Enabled = false;
                button2.Enabled = false;
                button6.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                button4.Enabled = true;
                button1.Enabled = true;
                button5.Enabled = true;
                button2.Enabled = true;
                button6.Enabled = true;
            }
        }
        public void displayinfo()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select No,LastName,FirstName,MiddleName,maxloan_p,approved_p,Comaker from customerinfo where No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label4.Text = "ID No.: " + dt.Rows[0].ItemArray[0].ToString();
            label5.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
            label34.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
            label35.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
            if (Convert.ToInt32(dt.Rows[0].ItemArray[5].ToString()) == 0)
            {
                button5.Text = "Approved";
            }
            else
            {
                button5.Text = "Disapproved";
            }
            comaker(dt.Rows[0].ItemArray[6].ToString());
        }
        public void comaker(string comaker)
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select No,LastName,FirstName,MiddleName from comakerinfo where No = '" + comaker + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                label30.Text = "Comaker ID: " + dt.Rows[0].ItemArray[0].ToString();
                label31.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
                label32.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
                label33.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
                button4.Text = "Update";
            }
            else
            {
                label30.Text = "Comaker ID: ";
                label31.Text = "Lastname: ";
                label32.Text = "Firstname: ";
                label33.Text = "Middlename: ";
                button4.Text = "Add";
            }
        }
        public void displayattachment()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from attachments where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for(int x=0;x < dt.Rows.Count;x++)
            {
                string replace = dt.Rows[x].ItemArray[2].ToString().Replace('*','\\');
                dataGridView1.Rows.Add(dt.Rows[x].ItemArray[4].ToString(),dt.Rows[x].ItemArray[1].ToString(),replace,dt.Rows[x].ItemArray[3].ToString());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            search = textBox1.Text;
            dialogsearch_ci d = new dialogsearch_ci();
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                comboBox1.Enabled = true;
                displayinfo();
                displayattachment();
                disabled();
                balancep();
                disableability();
                comboBox1.SelectedIndex = 0;
                displayability();
                displaydeduction();
                displayragec();
            }
        }

        double balance;
        public void balancep()
        {
            balance = 0;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from loan where No = '" + CreditInvistigator.id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            StringBuilder text = new StringBuilder();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                text.AppendLine(dt.Rows[x].ItemArray[1].ToString());
                string accountid = dt.Rows[x].ItemArray[3].ToString();
                if (dt.Rows[x].ItemArray[1].ToString() == "Personal Loan")
                {
                    int count = 0;
                    con.Open();
                    DataTable dt1 = new DataTable();
                    string strAcct1 = "Select per from customersched where No = '" + CreditInvistigator.id + "' and acctno = '" + accountid + "'";
                    da = new OdbcDataAdapter(strAcct1, con);
                    da.Fill(dt1);
                    con.Close();

                    count = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString());

                    con.Open();
                    DataTable dt2 = new DataTable();
                    string strAcct2 = "Select MonthlyInterest, MonthlyPrincipal from personalloan where No = '" + CreditInvistigator.id + "' and Accid = '" + accountid + "' ";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();

                    con.Open();
                    DataTable dt3 = new DataTable();
                    string strAcct3 = "Select balance from payment where id = '" + CreditInvistigator.id + "' and acctid = '" + accountid + "' ";
                    da = new OdbcDataAdapter(strAcct3, con);
                    da.Fill(dt3);
                    con.Close();

                    for (int y = 0; y < count; y++)
                    {
                        if (y < dt3.Rows.Count)
                        {
                            balance += Convert.ToDouble(dt3.Rows[y].ItemArray[0].ToString());
                        }
                        else
                        {
                            balance += Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString()) + Convert.ToDouble(dt2.Rows[0].ItemArray[1].ToString());
                        }
                    }

                }
                else
                {
                    con.Open();
                    DataTable dt2 = new DataTable();
                    string strAcct2 = "Select TotalPayment from emergencyloan where No = '" + CreditInvistigator.id + "' and Accid = '" + accountid + "' ";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();

                    con.Open();
                    DataTable dt3 = new DataTable();
                    string strAcct3 = "Select balance from payment where id = '" + CreditInvistigator.id + "' and acctid = '" + accountid + "' ";
                    da = new OdbcDataAdapter(strAcct3, con);
                    da.Fill(dt3);
                    con.Close();
                    if (dt3.Rows.Count > 0)
                    {
                        balance += Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                    }
                    else
                    {
                        balance += Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString());
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox18.Enabled == false)
            {
                textBox2.Enabled = true;
                textBox18.Enabled = true;
                comboBox1.Enabled = false;
                checkBox1.Enabled = true;
                button7.Visible = true;
                button2.Text = "Save";
            }
            else
            {
                con.Open();
                DataTable dt3 = new DataTable();
                string strAcct3 = "Select pminamount,gminamount from loanmaintenance";
                da = new OdbcDataAdapter(strAcct3, con);
                da.Fill(dt3);
                con.Close();

                if (Convert.ToDecimal(textBox18.Text) < Convert.ToDecimal(min) || Convert.ToDecimal(textBox18.Text) > Convert.ToDecimal(max))
                {
                    MessageBox.Show("Invalid Max Loan","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                if (comboBox1.SelectedIndex == 0)
                {
                    con.Open();
                    DataTable dt2 = new DataTable();
                    string strAcct2 = "Select Comaker from customerinfo where No = '" + CreditInvistigator.id + "' ";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();
                    
                    if (dt2.Rows[0].ItemArray[0].ToString() == "0" && checkBox1.Checked == true)
                    {
                        MessageBox.Show("Please input comaker information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (checkBox1.Checked == true && dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("Attachment is Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (checkBox1.Checked == true && Convert.ToDouble(label11.Text) < 8000)
                {
                    MessageBox.Show("Grand total is not enough", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToDecimal(dt3.Rows[0].ItemArray[0].ToString()) > Convert.ToDecimal(textBox18.Text)&&comboBox1.SelectedIndex == 0&&checkBox1.Checked == true)
                {
                    MessageBox.Show("Max amount is less than minimum amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToDecimal(dt3.Rows[0].ItemArray[1].ToString()) > Convert.ToDecimal(textBox18.Text) && comboBox1.SelectedIndex == 1 && checkBox1.Checked == true)
                {
                    MessageBox.Show("Max amount is less than minimum amount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pincode_approval p = new pincode_approval();
                p.ShowDialog();
                if (p.DialogResult == DialogResult.OK)
                {
                    updateability();
                    textBox2.Enabled = false;
                    textBox18.Enabled = false;
                    comboBox1.Enabled = true;
                    checkBox1.Enabled = false;
                    button7.Visible = false;
                    maxloanactivitylog();
                    button2.Text = "Update";
                }
            }
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
            table[0, 0] = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
            table[0, 1] = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
            for (int x = 1; x < dt1.Rows.Count + 1; x++)
            {
                table[x, 0] = Convert.ToDouble(dt1.Rows[x - 1].ItemArray[0].ToString());
                table[x, 1] = Convert.ToDouble(dt1.Rows[x - 1].ItemArray[1].ToString());
            }
            double salary = Convert.ToDouble(label11.Text);
            if (dt1.Rows.Count > 0)
            {
                for (int x = dt1.Rows.Count; x >= 0; x--)
                {
                    if (salary > table[x, 0] && x == dt1.Rows.Count)
                    {
                        min = table[x - 1, 1];
                        max = table[x, 1];
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
                max = table[0, 1];
            }
            label14.Text = max.ToString("n2");
            label17.Text = min.ToString("n2");
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
            double salary = Convert.ToDouble(label11.Text);
            if (dt1.Rows.Count > 0)
            {
                for (int x = dt1.Rows.Count; x >= 0; x--)
                {
                    if (salary > table[x, 0] && x == dt1.Rows.Count)
                    {
                        min = table[x - 1, 1];
                        max = table[x, 1];
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
                max = table[0, 1];
            }
            label14.Text = max.ToString("n2");
            label17.Text = min.ToString("n2");
        }
        public void displayragec()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                prange();
            }
            else
            {
                grange();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            addattachment d = new addattachment();
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                displayattachment();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            viewattachment.id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            viewattachment v = new viewattachment();
            v.ShowDialog();
            if (v.DialogResult == DialogResult.OK)
            {
                displayattachment();
            }
        }
        public void updateability()
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int c = 0;
                if (checkBox1.Checked == true)
                {
                    c = 1;
                }
                con.Open();
                string update = "update customerinfo set maxloan_p = '" + textBox18.Text + "' ,approved_p = '" + c + "' where No = '" + id + "'";
                cmd = new OdbcCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                int c = 0;
                if (checkBox1.Checked == true)
                {
                    c = 1;
                }
                con.Open();
                string update = "update customerinfo set maxloan_e = '" + textBox18.Text + "', approved_e = '" + c + "' where No = '" + id + "'";
                cmd = new OdbcCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, (vScrollBar1.Value - (vScrollBar1.Value * 2)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.modes = 3;
            (this.Owner as Form1).timer4.Start();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {

            if (balance != 0 && button5.Text == "Disapproved")
            {
                MessageBox.Show("Borrower has a balance of " + balance);
                return;
            }
            pincode_approval p = new pincode_approval();
            pincode_approval.text = button5.Text;
            p.ShowDialog();
            if (p.DialogResult == DialogResult.OK)
            {
                displayinfo();
                displayattachment();
                disabled();
                balancep();
            }
            /*
            if (button5.Text == "Approved")
            {
                con.Open();
                string update = "update customerinfo set approved = 1 where No = '" + id + "'";
                cmd = new OdbcCommand(update, con);
                cmd.ExecuteNonQuery();
                con.Close();
                activitylog();
                button5.Text = "Disapproved";
            }
            else
            {
                    con.Open();
                    string update = "update customerinfo set approved = 0 where No = '" + id + "'";
                    cmd = new OdbcCommand(update, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    activitylog();
                    button5.Text = "Approved";
                }
                else
                {
                }
            }
             */
        }
        public void activitylog()
        {
            string fn = string.Empty;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '" + CreditInvistigator.id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fn = dt.Rows[0].ItemArray[1].ToString().Trim() + " " + dt.Rows[0].ItemArray[2].ToString().Trim() + " " + dt.Rows[0].ItemArray[3].ToString().Trim();
            string text = string.Empty;
            if (button5.Text == "Approve")
            {
                text = "Approved Borrower";
            }
            else
            {
                text = "Dissaproved Borrower";
            }
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'" + text + "','" + fn + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void maxloanactivitylog()
        {
            string fn = string.Empty;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '" + CreditInvistigator.id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fn = dt.Rows[0].ItemArray[1].ToString().Trim() + " " + dt.Rows[0].ItemArray[2].ToString().Trim() + " " + dt.Rows[0].ItemArray[3].ToString().Trim();
            string text = string.Empty;
            if (button2.Text == "Save")
            {
                text = "Set Max loan";
            }
            else
            {
                text = "Update Max loan";
            }
            string company = fn.Trim().Replace("'", "''");
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'" + text + "','" + company + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            qweqwe(e, sender);
        }

        public void qweqwe(KeyPressEventArgs e, object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox18.Text.IndexOf('.') != -1)
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
                if (textBox18.TextLength == 7 && ch != 8 && ch != 127 && ch != 46)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayability();
            displayragec();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Deduction d = new Add_Deduction();
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                displaydeduction();
                //displayrange(); 
                displayragec();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            displaydeduction();
            displayrange(); 
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateborrowerattachment u = new updateborrowerattachment();
            updateborrowerattachment.id = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString();
            u.ShowDialog();
            if (u.DialogResult == DialogResult.OK)
            {
                displaydeduction();
                //displayrange(); 
                displayragec();
            }
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

        private void Cancel(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox18.Enabled = false;
            comboBox1.Enabled = true;
            checkBox1.Enabled = false;
            button7.Visible = false;
            button2.Text = "Update";
            displayability();
        }

    }
}

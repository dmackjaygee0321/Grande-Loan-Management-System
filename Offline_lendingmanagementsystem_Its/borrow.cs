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
    public partial class borrow : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public static int process;
        public borrow()
        {
            InitializeComponent();
        }
        public static string id, search;
        private void borrow_Load(object sender, EventArgs e)
        {
            textBox8.ShortcutsEnabled = false;
            textBox10.ShortcutsEnabled = false;
            comboBox3.SelectedIndex = 0;
            label29.Visible = false;
            if (process == 1)
            {
                process = 0;
                loaninfo();
            }
            if (label4.Text == "ID No.:")
            {
                butb2.Enabled = false;
                comboBox3.Enabled = false;
                textBox8.Enabled = false;
                textBox10.Enabled = false;
            }
            else
            {
                butb2.Enabled = true;
                comboBox3.Enabled = true;
                textBox8.Enabled = true;
                textBox10.Enabled = true;
            }
            groupBox3.Visible = false;
        }
        double interest;
        int minterm, maxterm;
        double minamm, maxamm;
        string frequency;
        public void function1()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            

            if (comboBox3.Text == "Personal Loan")
            {
                groupBox3.Visible = false;
                minterm = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
                maxterm = Convert.ToInt32(dt.Rows[0].ItemArray[3].ToString());
                interest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                label17.Text = dt.Rows[0].ItemArray[0].ToString() + "%";
                minamm = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
                label13.Text = "Min amount: " + dt.Rows[0].ItemArray[1].ToString();
                label24.Text = "Min term: " + dt.Rows[0].ItemArray[2].ToString() + " Months";
                label25.Text = "Max term: " + dt.Rows[0].ItemArray[3].ToString() + " Months";
                label23.Location = new Point(124, 295);
                label18.Visible = true;
                label11.Visible = true;
                label28.Visible = true;
                label2.Visible = true;
                label26.Visible = false;
                label3.Visible = true;
                label10.Visible = true;
                label1.Visible = true;
                label9.Visible = true;
                label23.Text = "Monthly Payment:";
                label9.Text = "0";
                label11.Text = "Monthly";
                label12.Text = "Months";
                frequency = "Monthly";
            }
            else
            {
                groupBox3.Visible = false;
                minterm = Convert.ToInt32(dt.Rows[0].ItemArray[6].ToString());
                maxterm = Convert.ToInt32(dt.Rows[0].ItemArray[7].ToString());
                interest = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());
                minamm = Convert.ToDouble(dt.Rows[0].ItemArray[5].ToString());
                label17.Text = dt.Rows[0].ItemArray[4].ToString() + "%";
                label13.Text = "Min amount: " + dt.Rows[0].ItemArray[5].ToString();
                label24.Text = "Min term: " + dt.Rows[0].ItemArray[6].ToString() + " Weeks";
                label25.Text = "Max term: " + dt.Rows[0].ItemArray[7].ToString() + " Weeks";
                label23.Text = "Due Date:";
                label23.Location = new Point(184, 295);
                label12.Text = "Weeks";
                label26.Visible = true; 
                label9.Visible = false;
                label18.Visible = false;
                label11.Visible = false;
                label10.Visible = false;
                label28.Visible = false;
                label3.Visible = false;
                label1.Visible = false;
                frequency = "Weekly";
            }
        }

        double borrowmoney, wi, ti, tp, wp;
        string term;
        string duedate;
        List<string> list;
        DateTime d = DateTime.Now;
        public void function2()
        {
            try
            {
                if (comboBox3.Text == "Emergency Loan")
                {

                    borrowmoney = 0;
                    int weeks = 0;

                    if (textBox8.Text != string.Empty)
                        borrowmoney = Convert.ToDouble(textBox8.Text);
                    if (textBox10.Text != string.Empty)
                        weeks = Convert.ToInt32(textBox10.Text);

                    wi = borrowmoney * (interest / 100);
                    ti = wi * weeks;
                    tp = ti + borrowmoney;

                    label6.Text = ti.ToString("n2");
                    label7.Text = borrowmoney.ToString("n2");
                    label8.Text = tp.ToString("n2");
                    DateTime due = d.AddDays(7*weeks);
                    label26.Text = due.ToLongDateString();
                    term = weeks + " Weeks";
                    duedate = due.ToLongDateString();
                }
                else 
                {
                    borrowmoney = 0;
                    int months = 0;

                    if (textBox8.Text != string.Empty)
                        borrowmoney = Convert.ToDouble(textBox8.Text);
                    if (textBox10.Text != string.Empty)
                        months = Convert.ToInt32(textBox10.Text);

                    wi = borrowmoney * (interest / 100);
                    ti = wi * months;
                    wp = borrowmoney / months;
                    tp = ti + borrowmoney;
                    double wpay = wi + wp;
                    DateTime maturity = d.AddMonths(1);
                    DateTime finale = d.AddMonths(months);
                    label10.Text = wi.ToString("n2");
                    label6.Text = ti.ToString("n2");
                    label7.Text = borrowmoney.ToString("n2");
                    label8.Text = tp.ToString("n2");
                    label9.Text = wpay.ToString("n2");
                    label3.Text = "Maturity Date:           " + maturity.ToLongDateString();
                    label1.Text = "Final DueDate:           " + finale.ToLongDateString();
                    list = new List<string>();
                    for (int x = 1; x <= months; x++)
                    {
                        DateTime duedate = d.AddMonths(x);
                        list.Add(duedate.ToLongDateString());

                    }
                    term = months + " Months";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void max_status()
        {
            if (comboBox3.SelectedIndex == 0)
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "select maxloan_p,approved_p from customerinfo where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                maxamm = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                label14.Text = "Max amount: " + Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()).ToString("n2"); 
                if (dt.Rows[0].ItemArray[1].ToString() == "1")
                {
                    label37.Text = "Status: Approved";
                    label37.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    label37.Text = "Status: Disapproved";
                    label37.ForeColor = System.Drawing.Color.Red;
                }
                if (dt.Rows[0].ItemArray[1].ToString() == "1" && balancep == 0)
                {
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    butb2.Enabled = true;
                }
                else
                {
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    butb2.Enabled = false;
                }
            }
            else
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "select maxloan_e,approved_e from customerinfo where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                maxamm = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                label14.Text = "Max amount: " + Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()).ToString("n2");
                if (dt.Rows[0].ItemArray[1].ToString() == "1")
                {
                    label37.Text = "Status: Approved";
                    label37.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    label37.Text = "Status: Disapproved";
                    label37.ForeColor = System.Drawing.Color.Red;
                }
                if (dt.Rows[0].ItemArray[1].ToString() == "1"&&balancep == 0)
                {
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    butb2.Enabled = true;
                }
                else
                {
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    butb2.Enabled = false;
                }
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            function1();
            function2();
            if (label4.Text != "ID No.:")
            {
                max_status();
                status();
            }

              //  loaninfo();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void butb2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox10.Text) <= maxterm && Convert.ToInt32(textBox10.Text) >= minterm && Convert.ToInt32(textBox8.Text) <= maxamm && Convert.ToInt32(textBox8.Text) >= minamm)
            {
                MessageBox.Show("Borrow Successfully");
                loan();
                if (comboBox3.Text == "Emergency Loan")
                {
                    emergency();
                }
                else
                {
                    personal();
                    sched();
                }
                statementofact s = new statementofact();
                statementofact.id = id;
                dataprint();
                s.ShowDialog();
                loaninfo2();
                balance1();
                activity();
                max_status();
                clear();
            }
            else
            {
                MessageBox.Show("Invalid Input","Error",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }
        }
        public void clear()
        {
            comboBox3.SelectedIndex = 0;
            textBox8.Clear();
            textBox10.Clear();
        }

        int acctid;
        public void loan()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from loan where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            acctid = 0;
            if (dt.Rows.Count > 0)
            {
                DataTable dt1 = new DataTable();
                string strAcct1 = "Select max(Accid) from loan where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct1, con);
                da.Fill(dt1);
                acctid = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString()) + 1;
            }

            string strAdd = "Insert Into loan values('" + id + "','" + comboBox3.Text + "','" + borrowmoney + "','" + acctid + "','" + Form1.userid + "','" + DateTime.Now.ToLongDateString() + "');";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void emergency()
        {
            con.Open();
            string strAdd = "Insert Into emergencyloan values('" + id + "','" + interest + "','" + frequency + "','" + term + "','" + wi + "','" + ti + "','" + tp + "','" + duedate + "','" + acctid + "');";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void personal()
        {
            con.Open();
            string strAdd = "Insert Into personalloan values('" + id + "','" + interest + "','" + frequency + "','" + term + "','" + wi + "','" + wp + "','" + ti + "','" + tp + "','" + acctid + "');";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void sched()
        {
            con.Open();
            for(int x=0;x < list.Count;x++)
            {
                string strAdd = "Insert Into customersched values('" + id + "','" + list.Count + "','" + acctid + "','" + list[x] + "');";
                cmd = new OdbcCommand(strAdd, con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            function2();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            function2();
        }
        string fullname;
        private void button2_Click(object sender, EventArgs e)
        {
            dialogsearch d = new dialogsearch();
            search = textBox1.Text;
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                loaninfo2();
                //loaninfo();
                balance1();
                max_status();
                status();
                //disabled();
            }
        }
        public void status()
        {
            if (balancep != 0)
            {
                label37.Text = "Status: Disapproved";
                label37.ForeColor = System.Drawing.Color.Red;
            }
        }
        double balancep;
        public void balance()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from loan where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                double vpay = 0;
                double vpayk = 0; 
                DataTable dt1 = new DataTable();
                string strAcct1 = "Select TotalGrandpayment from personalloan where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct1, con);
                da.Fill(dt1);
                con.Close();
                DataTable dt2 = new DataTable();
                string strAcct2 = "Select TotalPayment from emergencyloan where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct2, con);
                da.Fill(dt2);
                con.Close();
                DataTable dt3 = new DataTable();
                string strAcct3 = "Select interestpayment,principalpayment from payment where id = '" + id + "'";
                da = new OdbcDataAdapter(strAcct3, con);
                da.Fill(dt3);
                con.Close();
                for (int x = 0; x < dt1.Rows.Count; x++)
                {
                    vpay += Convert.ToDouble(dt1.Rows[x].ItemArray[0].ToString());
                }
                for (int x = 0; x < dt2.Rows.Count; x++)
                {
                    vpay += Convert.ToDouble(dt2.Rows[x].ItemArray[0].ToString());
                }
                for (int x = 0; x < dt3.Rows.Count; x++)
                {
                    vpayk += (Convert.ToDouble(dt3.Rows[x].ItemArray[0].ToString()) + Convert.ToDouble(dt3.Rows[x].ItemArray[1].ToString()));
                }
                balancep = vpay - vpayk;
                if (balancep < 1)
                {
                    balancep = 0;
                }
                label36.Text = "Balance: "+balancep;
            }
            else
            {
                balancep = 0;
                label36.Text = "Balance: 0";
            }
        }
        public void balance1()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from loan where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            StringBuilder text = new StringBuilder();
            double balance = 0;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                text.AppendLine(dt.Rows[x].ItemArray[1].ToString());
                string accountid = dt.Rows[x].ItemArray[3].ToString();
                if (dt.Rows[x].ItemArray[1].ToString() == "Personal Loan")
                {
                    int count = 0;
                    con.Open();
                    DataTable dt1 = new DataTable();
                    string strAcct1 = "Select per from customersched where No = '" + id + "' and acctno = '" + accountid + "'";
                    da = new OdbcDataAdapter(strAcct1, con);
                    da.Fill(dt1);
                    con.Close();

                    count = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString());

                    con.Open();
                    DataTable dt2 = new DataTable();
                    string strAcct2 = "Select MonthlyInterest, MonthlyPrincipal from personalloan where No = '" + id + "' and Accid = '" + accountid + "' ";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();

                    con.Open();
                    DataTable dt3 = new DataTable();
                    string strAcct3 = "Select balance from payment where id = '" + id + "' and acctid = '" + accountid + "' ";
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
                    string strAcct2 = "Select TotalPayment from emergencyloan where No = '" + id + "' and Accid = '" + accountid + "' ";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();

                    con.Open();
                    DataTable dt3 = new DataTable();
                    string strAcct3 = "Select balance from payment where id = '" + id + "' and acctid = '" + accountid + "' ";
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
            balancep = balance;
            label36.Text = "Balance: " + balancep.ToString("n2");
            if (balancep == 0)
            {
                label36.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                label36.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void loaninfo()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select No,LastName,FirstName,MiddleName,Comaker,maxloan_p from customerinfo where No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fullname = dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString() + " " + dt.Rows[0].ItemArray[3].ToString();
            label4.Text = "ID No.: " + dt.Rows[0].ItemArray[0].ToString();
            label5.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
            label34.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
            label35.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
            //maxamm = Convert.ToDouble(dt.Rows[0].ItemArray[5].ToString());
            //label14.Text = "Max Amount: " + maxamm.ToString("n2");
            if (dt.Rows[0].ItemArray[4].ToString() == "0")
            {
                label30.Text = "Comaker ID: ";
                label31.Text = "Lastname: ";
                label32.Text = "Firstname: ";
                label33.Text = "Middlename: ";
            }
            else
            {
                comakerinfo(dt.Rows[0].ItemArray[4].ToString());
            }

            if (comboBox3.Text == "Personal Loan")
            {
                if (dt.Rows[0].ItemArray[5].ToString() == "0" || dt.Rows[0].ItemArray[4].ToString() == "0" || balancep!=0)
                {
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    butb2.Enabled = false;
                }
                else
                {
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    butb2.Enabled = true;
                }
            }
            else
            {
                if (dt.Rows[0].ItemArray[5].ToString() == "0"|| balancep != 0)
                {
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    butb2.Enabled = false;
                }
                else
                {
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    butb2.Enabled = true;
                }
            }
        }
        public void loaninfo2()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select No,LastName,FirstName,MiddleName,Comaker,maxloan_p from customerinfo where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fullname = dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString() + " " + dt.Rows[0].ItemArray[3].ToString();
            label4.Text = "ID No.: " + dt.Rows[0].ItemArray[0].ToString();
            label5.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
            label34.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
            label35.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
            //maxamm = Convert.ToDouble(dt.Rows[0].ItemArray[5].ToString());
            //label14.Text = "Max Amount: " + maxamm.ToString("n2");
            if (dt.Rows[0].ItemArray[4].ToString() == "0")
            {
                label30.Text = "Comaker ID: ";
                label31.Text = "Lastname: ";
                label32.Text = "Firstname: ";
                label33.Text = "Middlename: ";
            }
            else
            {
                comakerinfo(dt.Rows[0].ItemArray[4].ToString());
            }
            comboBox3.Enabled = true;

        }
        public void disabled()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select No,LastName,FirstName,MiddleName,Comaker,maxloan_p from customerinfo where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (comboBox3.Text == "Personal Loan")
            {
                if (dt.Rows[0].ItemArray[5].ToString() == "0" || dt.Rows[0].ItemArray[4].ToString() == "0" || balancep != 0)
                {
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    butb2.Enabled = false;
                }
                else
                {
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    butb2.Enabled = true;
                }
            }
            else
            {
                if (dt.Rows[0].ItemArray[5].ToString() == "0" || balancep != 0)
                {
                    textBox8.Enabled = false;
                    textBox10.Enabled = false;
                    butb2.Enabled = false;
                }
                else
                {
                    textBox8.Enabled = true;
                    textBox10.Enabled = true;
                    butb2.Enabled = true;
                }
            }
        }
        public void comakerinfo(string coid)
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select No,LastName,FirstName,MiddleName from comakerinfo where No = '" + coid + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label30.Text = "Comaker ID: " + dt.Rows[0].ItemArray[0].ToString();
            label31.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
            label32.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
            label33.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.modes = 3;
            (this.Owner as Form1).timer4.Start();
        }
        
        public void dataprint()
        {
            statementofact.schedlist = new List<string>();
            statementofact.data = new string[12];
            statementofact.data[0] = (acctid + 1).ToString();
            statementofact.data[1] = comboBox3.Text;
            statementofact.data[2] = borrowmoney.ToString("n2");
            statementofact.data[3] = interest.ToString("n2");
            statementofact.data[4] = frequency;
            statementofact.data[5] = term;
            statementofact.data[6] = DateTime.Now.ToShortDateString();
            statementofact.data[7] = ti.ToString("n2");
            statementofact.data[8] = borrowmoney.ToString("n2");
            statementofact.data[9] = tp.ToString("n2");
            if (comboBox3.Text == "Personal Loan")
            {
                statementofact.schedlist = list;
                statementofact.data[10] = wp.ToString("n2");
            }
            else
            {
                statementofact.data[10] = tp.ToString("n2");
                statementofact.schedlist.Add(duedate);
            }
            statementofact.data[11] = wi.ToString("n2");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(term);
        }

        public void textbox_8(KeyPressEventArgs e, object sender)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox8.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (char.IsLetter(ch))
            {
                e.Handled = true;
                label29.Text = "Invalid Input";
                label29.Visible = true;
                return;
            }
            else
            {
                label29.Visible = false;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 127)
            {
                e.Handled = true;
            }
            if (cursorposition == 0 && ch == 46)
            {
                e.Handled = true;
                textBox8.Text = "0.";
                (sender as TextBox).SelectionStart = textBox8.TextLength;
            }
            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox8.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox8.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox8.TextLength == 1 && textBox8.Text[0] == '0')
                {
                    textBox8.Clear();
                }
            }
            if (ch == 8 && textBox8.TextLength == 1 || ch == 8 && textBox8.TextLength == 0)
            {
                textBox8.Text = "0";
                e.Handled = true;
            }
            if (textBox8.Text.IndexOf('.') != -1 && ch != 8 && ch != 127)
            {
                int index = 0;
                int count = 0;
                for (int x = 0; x < cursorposition; x++)
                {
                    if (textBox8.Text[x] == '.')
                    {
                        index = x;
                        count++;
                    }
                }
                if (count > 0)
                {
                    if ((textBox8.TextLength - index) >= 3)
                    {
                        e.Handled = true;
                    }
                }
            }
            else
            {
                if (textBox8.TextLength == 7 && ch != 8 && ch != 127 && ch != 46)
                {
                    e.Handled = true;
                }
            }
            if (ch == 8 && cursorposition == 1)
            {
                int count = 0;
                string text=textBox8.Text;
                for (int x = 0; x < textBox8.TextLength; x++)
                {
                    if (textBox8.Text[x] != '0'&&x > 0)
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
                    textBox8.Text = text.Remove(0, count);
                    if (textBox8.Text == string.Empty)
                    {
                        textBox8.Text = "0";
                    }
                }
            } 
            if (textBox8.Text.IndexOf('.') != -1)
            {
                int index = 0;
                for (int x = 0; x < textBox8.TextLength; x++)
                {
                    if (textBox8.Text[x] == '.')
                    {
                        index = x;
                        break;
                    }
                }
                if (index > 6&&cursorposition <= index)
                {
                    e.Handled = true;
                }
            }

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            textbox_8(e, sender);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }

            if (ch == 48)
            {
                if (cursorposition > 0)
                {
                    int count = 0;
                    for (int x = 0; x < cursorposition; x++)
                    {
                        if (textBox10.Text[x] != '0')
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        e.Handled = true;
                    }
                }
                else if (cursorposition == 0 && textBox10.TextLength > 0)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (textBox10.TextLength == 1 && textBox10.Text[0] == '0')
                {
                    textBox10.Clear();
                }
            }

            if (ch == 8 && textBox10.TextLength == 1 || ch == 8 && textBox10.TextLength == 0)
            {
                textBox10.Text = "0";
                e.Handled = true;
            }
            
        }

        private void textBox8_MouseMove(object sender, MouseEventArgs e)
        {
            textBox8.SelectionLength = 0;
        }

        private void textBox10_MouseMove(object sender, MouseEventArgs e)
        {

            textBox10.SelectionLength = 0;
        }
        public void activity()
        {
            string occupation = fullname.Trim().Replace("'", "''");
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Borrow Transaction','" + occupation + " Borrow " + textBox8.Text + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

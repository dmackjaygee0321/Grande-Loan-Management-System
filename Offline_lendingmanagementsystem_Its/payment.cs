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
    public partial class payment : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public payment()
        {
            InitializeComponent();
        }

        private void payment_Load(object sender, EventArgs e)
        {
            textBox8.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            label25.Visible = false;
            button1.Enabled = false;
        }
        string fname;
        public void loaninfo()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select No,LastName,FirstName,MiddleName from customerinfo where No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select Accid from loan where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            label4.Text = "ID No.: " + dt.Rows[0].ItemArray[0].ToString();
            label5.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
            label34.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
            label35.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
            fname = dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString() + " " + dt.Rows[0].ItemArray[1].ToString().ToUpper()[0];
            comboBox1.Items.Clear();
            if (dt1.Rows.Count > 0)
            {
                comboBox1.Enabled = true;
                for (int x = 0; x < dt1.Rows.Count; x++)
                {
                    comboBox1.Items.Add((Convert.ToInt32(dt1.Rows[x].ItemArray[0].ToString()) + 1).ToString());
                }
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                textBox8.Text = "0";
                textBox2.Text = "0";
                button1.Enabled = false;
                textBox2.Enabled = false;
                textBox8.Enabled = false;
                dataGridView1.Rows.Clear();
                comboBox1.Enabled = false;
            }
        }
        int limit;
        public void accountinfo_p()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.No,a.Accid, b.date,"+ 
            "(Select MonthlyInterest from personalloan where No = a.No && Accid = a.Accid) as MonthlyInterest," +
            "(Select MonthlyPrincipal from personalloan where No = a.No && Accid = a.Accid) as MonthlyPrincipal " +
            "from loan as a, customersched as b where a.No = b.No and b.acctno = a.Accid and "+
            "a.Accid = '"+(Convert.ToInt32(comboBox1.Text) - 1).ToString()+"' and a.No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt); 
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from payment where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            con.Close();
            dataGridView1.Rows.Clear();
            v_interest =Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
            v_principal =Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());
            limit = dt1.Rows.Count;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                if (x < dt1.Rows.Count)
                {
                    double interest = Convert.ToDouble(dt1.Rows[x].ItemArray[4].ToString());
                    double principal = Convert.ToDouble(dt1.Rows[x].ItemArray[5].ToString());
                    double penaltyp = Convert.ToDouble(dt1.Rows[x].ItemArray[7].ToString());
                    double penalty = 0;
                    double balance = Convert.ToDouble(dt1.Rows[x].ItemArray[6].ToString());
                    dataGridView1.Rows.Add(dt1.Rows[x].ItemArray[1].ToString(),
                        dt1.Rows[x].ItemArray[3].ToString(),
                        principal.ToString("n2"),
                        interest.ToString("n2"),
                        dt1.Rows[x].ItemArray[6].ToString(),
                        dt1.Rows[x].ItemArray[7].ToString(),
                        (interest + principal + penaltyp),
                        dt1.Rows[x].ItemArray[2].ToString(),
                        dt1.Rows[x].ItemArray[10].ToString());
                    if (dataGridView1.Rows[x].Cells[2].Value.ToString() == "0.00")
                    {
                        dataGridView1.Rows[x].Cells[2].Value = v_principal.ToString("n2");
                        dataGridView1.Rows[x].Cells[2].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {

                        dataGridView1.Rows[x].Cells[2].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                    if (dataGridView1.Rows[x].Cells[4].Value.ToString() == "0.0" || dataGridView1.Rows[x].Cells[4].Value.ToString() == "0")
                    {
                        dataGridView1.Rows[x].Cells[0].Style.ForeColor = System.Drawing.Color.Blue;
                        dataGridView1.Rows[x].Cells[1].Style.ForeColor = System.Drawing.Color.Blue;
                        dataGridView1.Rows[x].Cells[5].Style.ForeColor = System.Drawing.Color.Blue;

                    }
                    else
                    {
                        con.Open();
                        DataTable dt3 = new DataTable();
                        string strAcct3 = "select pdaypenalty from loanmaintenance";
                        da = new OdbcDataAdapter(strAcct3, con);
                        da.Fill(dt3);
                        con.Close();
                        int dayofpenalty = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                        dataGridView1.Rows[x].Cells[5].Value = penaltyp.ToString("n2");
                        dataGridView1.Rows[x].Cells[0].Style.ForeColor = System.Drawing.Color.Red;
                        dataGridView1.Rows[x].Cells[1].Style.ForeColor = System.Drawing.Color.Red;

                        DateTime duedate = Convert.ToDateTime(dt1.Rows[x].ItemArray[2].ToString());
                        DateTime date = duedate;
                        int delayno = 0;
                        int nopenalty = 0;
                        while (date < now)
                        {

                            delayno++;

                            if (date >= duedate.AddDays(dayofpenalty))
                            {
                                nopenalty++;
                            }
                            
                            date = duedate.AddDays(delayno);
                        }
                        penalty = pinterest * (nopenalty);
                        dataGridView1.Rows[x].Cells[5].Value = penalty.ToString("n2");
                        
                        if (penalty != 0)
                            dataGridView1.Rows[x].Cells[5].Style.ForeColor = System.Drawing.Color.Red;
                        else
                        {
                            dataGridView1.Rows[x].Cells[5].Value = dt1.Rows[x].ItemArray[7].ToString();
                            dataGridView1.Rows[x].Cells[5].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                    }
                    if (dataGridView1.Rows[x].Cells[3].Value.ToString() == "0")
                    {
                        dataGridView1.Rows[x].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[x].Cells[3].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                    if (dataGridView1.Rows[x].Cells[4].Value.ToString() != "0")
                    {
                        dataGridView1.Rows[x].Cells[4].Style.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        dataGridView1.Rows[x].Cells[4].Style.ForeColor = System.Drawing.Color.Blue;
                    }
                    dataGridView1.Rows[x].Cells[6].Style.ForeColor = System.Drawing.Color.Blue;
                    dataGridView1.Rows[x].Cells[7].Style.ForeColor = System.Drawing.Color.Blue;
                        
                    
                }
                else
                {
                    string typeofpaid = string.Empty;
                    double balance = 0;
                    DateTime duedate = Convert.ToDateTime(dt.Rows[x].ItemArray[2].ToString());
                    double penalty = 0;
                    if (duedate > now)
                    {
                        typeofpaid = "Early Payment";
                    }
                    else if (duedate.ToLongDateString() == now.ToLongDateString())
                    {
                        typeofpaid = "On Time Payment";
                    }
                    else
                    {
                        con.Open();
                        DataTable dt3 = new DataTable();
                        string strAcct3 = "select pdaypenalty from loanmaintenance";
                        da = new OdbcDataAdapter(strAcct3, con);
                        da.Fill(dt3);
                        con.Close();
                        int dayofpenalty = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                        typeofpaid = "Delay Payment";
                        DateTime date = duedate;
                        int delayno = 0;
                        int nopenalty = 0;
                        while (date < now)
                        {
                            delayno++; 
                            if (date >= duedate.AddDays(dayofpenalty))
                            {
                                nopenalty++;
                            }
                            
                            date = duedate.AddDays(delayno);
                        }
                        penalty = pinterest * nopenalty;
                    }
                    dataGridView1.Rows.Add(dt.Rows[x].ItemArray[2].ToString(), typeofpaid, v_principal, v_interest, balance, penalty, (v_principal + v_interest+ penalty), "On Going", "On Going"); 
                    dataGridView1.Rows[x].Cells[0].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[x].Cells[1].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[x].Cells[2].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[x].Cells[3].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[x].Cells[4].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[x].Cells[5].Style.ForeColor = Color.Red;
                    dataGridView1.Rows[x].Cells[6].Style.ForeColor = Color.Red;
                }
            }
            displayPersonal(dt.Rows.Count,dt1.Rows.Count);
        }

        DateTime now = DateTime.Now;
        double v_principal,v_interest;
        string dateofpenalty_e;
        public void accountinfo_e()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select TotalInterest, TotalPayment , DueDate,WeeklyInterest from emergencyloan where Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and No = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from payment where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            dataGridView1.Rows.Clear();
            if(dt.Rows.Count > 0)
            {
                v_interest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                v_principal = (Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString()) - Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()));
                double weeklyinterest = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        con.Open();
                        DataTable dt2 = new DataTable();
                        string strAcct2 = "select (a.TotalPayment - a.TotalInterest) as principal, b.principalpayment from emergencyloan as a, payment as b where a.No = b.id and a.Accid = b.acctid and a.No = '" + id + "' and a.Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' ";
                        da = new OdbcDataAdapter(strAcct2, con);
                        da.Fill(dt2);
                        con.Close();
                        double principalpen = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString()) + Convert.ToDouble(dt2.Rows[0].ItemArray[1].ToString());
                        double interest = Convert.ToDouble(dt1.Rows[x].ItemArray[4].ToString());
                        double principal = Convert.ToDouble(dt1.Rows[x].ItemArray[5].ToString());
                        double penaltyp = Convert.ToDouble(dt1.Rows[x].ItemArray[7].ToString());
                        double penalty = 0;
                        double balance = Convert.ToDouble(dt1.Rows[x].ItemArray[6].ToString());
                        dataGridView1.Rows.Add(dt1.Rows[x].ItemArray[1].ToString(),
                            dt1.Rows[x].ItemArray[3].ToString(),
                            principal.ToString("n2"),
                            interest.ToString("n2"),
                            dt1.Rows[x].ItemArray[6].ToString(),
                            dt1.Rows[x].ItemArray[7].ToString(),
                            (interest+principal+penaltyp),
                            dt1.Rows[x].ItemArray[2].ToString(),
                            dt1.Rows[x].ItemArray[10].ToString());
                        if (dataGridView1.Rows[x].Cells[2].Value.ToString() == "0.00")
                        {
                            dataGridView1.Rows[x].Cells[2].Value = v_principal.ToString("n2");
                            dataGridView1.Rows[x].Cells[2].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {

                            dataGridView1.Rows[x].Cells[2].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        if (dataGridView1.Rows[x].Cells[4].Value.ToString() == "0.0" || dataGridView1.Rows[x].Cells[4].Value.ToString() == "0")
                        {
                            dataGridView1.Rows[x].Cells[0].Style.ForeColor = System.Drawing.Color.Blue;
                            dataGridView1.Rows[x].Cells[1].Style.ForeColor = System.Drawing.Color.Blue;
                            dataGridView1.Rows[x].Cells[5].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        else
                        {
                            con.Open();
                            DataTable dt3 = new DataTable();
                            string strAcct3 = "select gdaypenalty from loanmaintenance";
                            da = new OdbcDataAdapter(strAcct3, con);
                            da.Fill(dt3);
                            con.Close();
                            int dayofpenalty = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                            dataGridView1.Rows[x].Cells[5].Value = penaltyp.ToString("n2");
                            dataGridView1.Rows[x].Cells[0].Style.ForeColor = System.Drawing.Color.Red;
                            dataGridView1.Rows[x].Cells[1].Style.ForeColor = System.Drawing.Color.Red; 
                            DateTime d = Convert.ToDateTime(Convert.ToDateTime(dt1.Rows[x].ItemArray[9].ToString()));
                            DateTime datedelay = d;
                            DateTime date = d;
                            int delayno = 0;
                            double balanceinterest = principalpen * (pinterest / 100);
                            while (date < now)
                            {
                                delayno++;
                                if (date == datedelay.AddDays(dayofpenalty))
                                {
                                    penalty += balanceinterest;
                                    datedelay = datedelay.AddDays(7);
                                }
                                date = d.AddDays(delayno);
                            }
                            dateofpenalty_e = datedelay.ToLongDateString();
                            dataGridView1.Rows[x].Cells[5].Value = penalty.ToString("n2");
                            if (penalty != 0)
                                dataGridView1.Rows[x].Cells[5].Style.ForeColor = System.Drawing.Color.Red;
                            else
                            {
                                dataGridView1.Rows[x].Cells[5].Value = dt1.Rows[x].ItemArray[7].ToString();
                                dataGridView1.Rows[x].Cells[5].Style.ForeColor = System.Drawing.Color.Blue;
                            }
                        }
                        if (dataGridView1.Rows[x].Cells[3].Value.ToString() == "0")
                        {
                            dataGridView1.Rows[x].Cells[3].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[x].Cells[3].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        if (dataGridView1.Rows[x].Cells[4].Value.ToString() != "0")
                        {
                            dataGridView1.Rows[x].Cells[4].Style.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[x].Cells[4].Style.ForeColor = System.Drawing.Color.Blue;
                        }
                        dataGridView1.Rows[x].Cells[6].Style.ForeColor = System.Drawing.Color.Blue;
                        dataGridView1.Rows[x].Cells[7].Style.ForeColor = System.Drawing.Color.Blue;
                        
                    }
                    else
                    {
                        con.Open();
                        DataTable dt2 = new DataTable();
                        string strAcct2 = "select BorrowedMoney from loan where accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and No = '" + id + "'	";
                        da = new OdbcDataAdapter(strAcct2, con);
                        da.Fill(dt2);
                        con.Close();
                        double principalpen = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString());
                        string typeofpaid = string.Empty;
                        DateTime d = Convert.ToDateTime(dt.Rows[x].ItemArray[2].ToString());
                        double penalty = 0;
                        if (d > now)
                        {
                            typeofpaid = "Early Payment";
                            dateofpenalty_e = d.ToLongDateString();
                        }
                        else if (d.ToLongDateString() == now.ToLongDateString())
                        {
                            dateofpenalty_e = d.ToLongDateString();
                            typeofpaid = "On Time Payment";
                        }
                        else
                        {
                            con.Open();
                            DataTable dt3 = new DataTable();
                            string strAcct3 = "select gdaypenalty from loanmaintenance";
                            da = new OdbcDataAdapter(strAcct3, con);
                            da.Fill(dt3);
                            con.Close();
                            int dayofpenalty = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                            typeofpaid = "Delay Payment";
                            DateTime datedelay = d;
                            DateTime date = d;
                            int delayno = 0;
                            while (date < now)
                            {
                                delayno++;
                                if (date == datedelay.AddDays(dayofpenalty))
                                {
                                    penalty += principalpen * (pinterest / 100);
                                    datedelay = datedelay.AddDays(7);
                                }
                                date = d.AddDays(delayno);
                            }
                            dateofpenalty_e = datedelay.ToLongDateString();
                        }
                        dataGridView1.Rows.Add(dt.Rows[x].ItemArray[2].ToString(), typeofpaid, (Convert.ToDouble(dt.Rows[x].ItemArray[1].ToString()) - Convert.ToDouble(dt.Rows[x].ItemArray[0].ToString())), Convert.ToDouble(dt.Rows[x].ItemArray[0].ToString()), "0", penalty.ToString(), Convert.ToDouble(dt.Rows[x].ItemArray[1].ToString()), "On Going", "On Going");
                        dataGridView1.Rows[x].Cells[0].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[x].Cells[1].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[x].Cells[2].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[x].Cells[3].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[x].Cells[4].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[x].Cells[5].Style.ForeColor = Color.Red;
                        dataGridView1.Rows[x].Cells[6].Style.ForeColor = Color.Red;
                    }
                }
            }
            displayEmegency();
        }
        string type;
        public void displaytype()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select Type from loan where No='" + id + "' and Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString()+ "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label14.Text = "Type: " + dt.Rows[0].ItemArray[0].ToString();
            type = dt.Rows[0].ItemArray[0].ToString();
        }

        public static string id, search;
        private void button2_Click(object sender, EventArgs e)
        {
            dialogsearchpayment d = new dialogsearchpayment();
            search = textBox3.Text;
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                loaninfo();
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaytype();
            textBox1.Clear();
            textBox2.Clear();
            textBox8.Enabled = true;
            textBox2.Enabled = true;
            if (type == "Personal Loan")
            {
                interest_p();
                accountinfo_p();
            }
            else
            {
                interest_e();
                accountinfo_e();
            }
        }
        public void displayEmegency()
        {
            if (dataGridView1.Rows[0].Cells[0].Style.ForeColor == System.Drawing.Color.Red)
            {
                textBox2.Enabled = true;
                textBox8.Enabled = true;
                label1.Text = "Due Date: " + dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            else
            {
                label1.Text = "Due Date: -";
                textBox8.Enabled = false;
                textBox2.Enabled = false;
            }
            if (dataGridView1.Rows[0].Cells[2].Style.ForeColor == System.Drawing.Color.Red && dataGridView1.Rows[0].Cells[3].Style.ForeColor == System.Drawing.Color.Red)
            {
                textBox8.Enabled = true;
                textBox8.Text = (Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value.ToString()) + Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString())).ToString();
            }
            else
            {
                textBox8.Enabled = false;
                textBox8.Text = "0";
            }
            if (dataGridView1.Rows[0].Cells[5].Style.ForeColor == System.Drawing.Color.Red)
                textBox1.Text = Convert.ToDouble(dataGridView1.Rows[0].Cells[5].Value.ToString()).ToString();
            else
            {
                textBox1.Text = "0";
            }
            if (Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value.ToString()) != 0&&dataGridView1.Rows[0].Cells[4].Style.ForeColor == System.Drawing.Color.Red )
            {
                textBox2.Enabled = true;
                textBox2.Text = Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value.ToString()).ToString();
            }
            else
            {
                textBox2.Text = "0";
                textBox2.Enabled = false;
            }

            double amount = 0, balances = 0;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells[2].Style.ForeColor == System.Drawing.Color.Red)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells[3].Style.ForeColor == System.Drawing.Color.Red)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells[4].Style.ForeColor == System.Drawing.Color.Red)
                {
                    balances += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
            }
            if (amount == 0 && balances == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
        public void displayPersonal(int a,int b)
        {
            if (a != b)
            {
                label1.Text = "Due Date: " + dataGridView1.Rows[b].Cells[0].Value.ToString();
                double payment = Convert.ToDouble(dataGridView1.Rows[b].Cells[2].Value.ToString()) + Convert.ToDouble(dataGridView1.Rows[b].Cells[3].Value.ToString());
                textBox8.Text = payment.ToString();
                if (dataGridView1.Rows[b].Cells[5].Style.ForeColor == System.Drawing.Color.Red && Convert.ToDouble(dataGridView1.Rows[b].Cells[5].Value.ToString()) != 0)
                {
                    textBox1.Text = (Convert.ToDouble(dataGridView1.Rows[b].Cells[5].Value.ToString())).ToString("n2");
                }
                double balance = 0;
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    balance += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
                textBox2.Text = balance.ToString(); 
                int row = 0;
                for (int z = 0; z < dataGridView1.Rows.Count; z++)
                {
                    if (dataGridView1.Rows[z].Cells[4].Style.ForeColor == System.Drawing.Color.Blue)
                    {
                        row++;
                    }
                } if (row == dataGridView1.Rows.Count)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = row - 1;
                    dataGridView1.Refresh();
                    dataGridView1.CurrentCell = dataGridView1.Rows[row - 1].Cells[6];
                }
                if (row != 0 && dataGridView1.Rows.Count > 1 && row != dataGridView1.Rows.Count)
                {
                    dataGridView1.FirstDisplayedScrollingRowIndex = row;
                    dataGridView1.Refresh();
                    dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[6];
                }
                else
                {
                    dataGridView1.Refresh();
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[6];
                }
            }
            else
            {
                double balance = 0;
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    balance += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
                if (balance > 0)
                    textBox2.Text = balance.ToString();
                else
                {
                    textBox2.Text = balance.ToString();
                    textBox2.Enabled = false;
                }
                label1.Text = "Due Date: -";
                textBox8.Enabled = false;
                textBox8.Text= "0";
            }
            double amount = 0, balances = 0;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells[2].Style.ForeColor == System.Drawing.Color.Red)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells[3].Style.ForeColor == System.Drawing.Color.Red)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells[4].Style.ForeColor == System.Drawing.Color.Red)
                {
                    balances += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
            }
            if (amount == 0 && balances == 0)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
        int ctr;
        string[] sched;
        string[] schedtype;
        double[] schedpenalty;
        double paymentpenalty;
        public void paymentchangepersonal()
        {
            paymentpenalty = 0;
            if (limit < dataGridView1.Rows.Count - 1)
            {
                double payment = 0;
                if (textBox8.Text != string.Empty)
                    payment = Convert.ToDouble(textBox8.Text);
                ctr = 0;
                
                for (int x = limit; x < dataGridView1.Rows.Count; x++)
                {
                    if (payment > (v_interest + v_principal))
                    {
                        payment -= (v_interest + v_principal);
                        ctr++;
                    }
                }
                if (limit + ctr < dataGridView1.Rows.Count)
                {
                    label1.Text = "Due Date: " + dataGridView1.Rows[limit + ctr].Cells[0].Value.ToString();
                }
                double penalty = 0;
                if (payment!=0&&limit+ctr!=dataGridView1.Rows.Count)
                    ctr++;
                for (int x = limit; x < (limit + ctr); x++)
                {
                    penalty += Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
                }
                paymentpenalty = penalty;
                textBox1.Text =(penalty + balancepenalty).ToString("n2");

                sched = new string[ctr];
                schedtype = new string[ctr];
                schedpenalty = new double[ctr];
                int index = 0;
                for (int x = limit; x < limit+ctr; x++)
                {
                    sched[index] = dataGridView1.Rows[x].Cells[0].Value.ToString();
                    schedtype[index] = dataGridView1.Rows[x].Cells[1].Value.ToString();
                    schedpenalty[index] = Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
                    index++;
                }
            }
            else
            {
                textBox1.Text = "0.0";
                ctr = 1;
                sched = new string[ctr];
                schedtype = new string[ctr];
                schedpenalty = new double[ctr];
                sched[0] = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value.ToString();
                schedtype[0] = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value.ToString();
                schedpenalty[0] = Convert.ToDouble(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value.ToString());
            }
        }

        double balancepenalty;
        List<List<string>> balancepaymentdata;
        public void balancepaymentchange()
        {
            double balancepayment = 0;
            double penalty = 0;
            if (textBox2.Text != string.Empty)
            {
                balancepayment = Convert.ToDouble(textBox2.Text);
            }
            if (balancepayment != 0)
            {
                balancepaymentdata = new List<List<string>>();
                int index_x = 0;
                StringBuilder b = new StringBuilder();
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    double balance = Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                    if (balance != 0)
                    {
                        balancepaymentdata.Add(new List<string>());
                        if (balancepayment > balance)
                        {
                            balancepayment -= balance;
                            balancepaymentdata[index_x].Add(dataGridView1.Rows[x].Cells[0].Value.ToString());
                            balancepaymentdata[index_x].Add(balance.ToString());
                            if (dataGridView1.Rows[x].Cells[5].Style.ForeColor == System.Drawing.Color.Red)
                            {
                                balancepaymentdata[index_x].Add(dataGridView1.Rows[x].Cells[5].Value.ToString());
                                penalty += Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
                            }
                            else
                            balancepaymentdata[index_x].Add("0");
                            b.AppendLine(balancepaymentdata[index_x][0]);
                            b.AppendLine(balancepaymentdata[index_x][1]);
                            b.AppendLine(balancepaymentdata[index_x][2]);
                        }
                        else
                        {
                            balancepaymentdata[index_x].Add(dataGridView1.Rows[x].Cells[0].Value.ToString());
                            balancepaymentdata[index_x].Add(balancepayment.ToString());
                            if (dataGridView1.Rows[x].Cells[5].Style.ForeColor == System.Drawing.Color.Red)
                            {
                                balancepaymentdata[index_x].Add(dataGridView1.Rows[x].Cells[5].Value.ToString());
                                penalty += Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
                            }
                            else
                                balancepaymentdata[index_x].Add("0");
                            b.AppendLine(balancepaymentdata[index_x][0]);
                            b.AppendLine(balancepaymentdata[index_x][1]);
                            b.AppendLine(balancepaymentdata[index_x][2]);
                            break;
                        }
                        index_x++;
                    }
                }
                //MessageBox.Show(b.ToString());

            }
            balancepenalty = penalty;
            textBox1.Text = (paymentpenalty + penalty).ToString("n2");
        }
        public void e_payment()
        {
            double principal=0,interest=0,balance=0,penalty=0;
            double payment = Convert.ToDouble(textBox8.Text);
            if (payment > v_interest)
            {
                interest = v_interest;
                principal = payment - interest;
            }
            else
            {
                interest = payment;
                principal = 0;
            }
            rp = principal;
            ri = interest;

            rrp = principal;
            rri = interest;
            balance = (v_interest + v_principal) - payment;
            penalty = Convert.ToDouble(textBox1.Text);
            con.Open();
            string strAdd = "Insert Into payment values('" + id + "','" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString() + "','" + DateTime.Now.ToLongDateString() + "','" + dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString() + "','" + interest + "','" + principal + "','" + balance + "','" + penalty + "','" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "','" + dateofpenalty_e + "','" + Form1.userid + "');";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();           
        }
        public void e_balance()
        {
            double balancep = Convert.ToDouble(textBox2.Text);
            double balance = 0;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.TotalInterest, a.TotalPayment, b.interestpayment, b.principalpayment,b.penalty from emergencyloan as a, payment as b where a.No = b.id and b.acctid = a.Accid and b.acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and b.id = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            double principalp = 0;
            double interestp = 0;
            double penalty = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());
            double interest = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
            double principal = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
            double vinterest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
            double vprincipal = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString()) - vinterest;
            if (interest == vinterest)
            {
                principalp = principal + balancep;
                rrp = balancep;
                balance = vprincipal - principalp;
                con.Open();
                string strAdd = "update payment set principalpayment = " + principalp.ToString() + ", balance = " + balance.ToString("n2") + " where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'";
                cmd = new OdbcCommand(strAdd, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                if (interest + balancep > vinterest)
                {
                    double need = vinterest - interest;
                    balancep -= need;
                    rri = need;
                    rrp = balancep;
                    principalp = balancep;
                    balance = vprincipal - principalp;
                    con.Open();
                    string strAdd = "update payment set interestpayment = " + vinterest + ", principalpayment = " + principalp.ToString() + ", balance = " + balance.ToString() + " where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'";
                    cmd = new OdbcCommand(strAdd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {
                    interestp = interest + balancep;
                    rri = balancep;
                    balance = (vinterest + vprincipal) - interestp;
                    con.Open();
                    string strAdd = "update payment set interestpayment = " + interestp + ", balance = " + balance.ToString() + " where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'";
                    cmd = new OdbcCommand(strAdd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            double penaltyp = penalty + Convert.ToDouble(textBox1.Text);
            con.Open();
            string strAdd1 = "update payment set penalty = " + penaltyp.ToString() + ", datepenalty = '"+dateofpenalty_e+"' where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'";
            cmd = new OdbcCommand(strAdd1, con);
            cmd.ExecuteNonQuery();
            con.Close();
           
            
        }
       
        public void p_payment()
        {
            double payment = 0;
            payment = Convert.ToDouble(textBox8.Text);
            for (int x = 0; x < ctr; x++)
            {
                double principal = 0, interest = 0, balance = 0, penalty = 0;
                if (x < ctr - 1)
                {
                    payment -= (v_interest + v_principal);
                    rp += v_principal;
                    ri += v_interest;

                    rrp += v_principal;
                    rri += v_interest;
                    con.Open();
                    string strAdd = "Insert Into payment values('" + id + "','" + sched[x] + "','" + DateTime.Now.ToLongDateString() + "','" + schedtype[x] + "','" + v_interest + "','" + v_principal + "','" + 0 + "','" + schedpenalty[x] + "','" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "','" + dateofpenalty_e + "','" + Form1.userid + "');";
                    cmd = new OdbcCommand(strAdd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();      
                }
                else
                {
                    if (payment > v_interest)
                    {
                        interest = v_interest;
                        principal = payment - interest;
                    }
                    else
                    {
                        interest = payment;
                        principal = 0;
                    }
                    rp += principal;
                    ri += interest;

                    rri += interest;
                    rrp += principal;
                    balance = (v_interest + v_principal) - payment;
                    penalty = schedpenalty[x];
                    con.Open();
                    string strAdd = "Insert Into payment values('" + id + "','" + sched[x] + "','" + DateTime.Now.ToLongDateString() + "','" + schedtype[x] + "','" + interest + "','" + principal + "','" + balance + "','" + penalty + "','" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "','" + dateofpenalty_e + "','" + Form1.userid + "');";
                    cmd = new OdbcCommand(strAdd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();           
                }
 
            }
        }
        public void p_balancepayment()
        {
            for (int x = 0; x < balancepaymentdata.Count(); x++)
            {
                if (x < balancepaymentdata.Count - 1)
                {
                    con.Open();
                    DataTable dt = new DataTable();
                    string strAcct = "select penalty from payment where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "' and paymentsched ='" + balancepaymentdata[x][0] + "'";
                    da = new OdbcDataAdapter(strAcct, con);
                    da.Fill(dt);
                    double currentpenalty = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                    double totalpenalty = currentpenalty + Convert.ToDouble(balancepaymentdata[x][2]);
                    rrp += v_principal;
                    rri += v_interest;
                    string strAdd = "update payment set interestpayment = '" + v_interest + "', principalpayment = '" + v_principal + "',balance = '0.00', penalty = '" + totalpenalty + "' where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "' and paymentsched ='" + balancepaymentdata[x][0] + "'";
                    cmd = new OdbcCommand(strAdd, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                {

                    double balancep = Convert.ToDouble(balancepaymentdata[x][1]);
                    double balance = 0;
                    con.Open();
                    DataTable dt = new DataTable();
                    string strAcct = "select a.MonthlyInterest,a.MonthlyPrincipal,b.interestpayment,b.principalpayment,b.penalty from personalloan as a, payment as b where a.No = b.id and b.acctid = a.Accid and b.acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and b.id = '" + id + "' and b.paymentsched = '"+balancepaymentdata[x][0]+"'";
                    da = new OdbcDataAdapter(strAcct, con);
                    da.Fill(dt);
                    con.Close();
                    double principalp = 0;
                    double interestp = 0;
                    double penalty = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());
                    double interest = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
                    double principal = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
                    double vinterest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                    double vprincipal = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
                    if (interest == vinterest)
                    {
                        principalp = principal + balancep;
                        rrp += balancep;
                        balance = vprincipal - principalp;
                        con.Open();
                        string strAdd = "update payment set principalpayment = " + principalp.ToString() + ", balance = " + balance.ToString() + " where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "' and paymentsched = '" + balancepaymentdata[x][0] + "'";
                        cmd = new OdbcCommand(strAdd, con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        if (interest + balancep > vinterest)
                        {
                            double need = vinterest - interest;
                            balancep -= need;
                            rri += need;
                            principalp = balancep;
                            rrp += balancep;
                            balance = vprincipal - principalp;
                            con.Open();
                            string strAdd = "update payment set interestpayment = " + vinterest + ", principalpayment = " + principalp.ToString() + ", balance = " + balance.ToString() + " where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "' and paymentsched = '" + balancepaymentdata[x][0] + "'";
                            cmd = new OdbcCommand(strAdd, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                        else
                        {
                            interestp = interest + balancep;
                            rri += balancep;
                            balance = (vinterest + vprincipal) - interestp;
                            con.Open();
                            string strAdd = "update payment set interestpayment = " + interestp + ", balance = " + balance.ToString() + " where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "' and paymentsched = '" + balancepaymentdata[x][0] + "'";
                            cmd = new OdbcCommand(strAdd, con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }

                    }
                    double penaltyp = penalty + Convert.ToDouble(balancepaymentdata[x][2]);
                    con.Open();
                    string strAdd1 = "update payment set penalty = " + penaltyp.ToString() + ", datepenalty = '" + dateofpenalty_e + "' where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "' and paymentsched = '" + balancepaymentdata[x][0] + "'";
                    cmd = new OdbcCommand(strAdd1, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        double pinterest;
        double rp, ri;
        string rpp,rb;
        double rrp, rri;
        string [] datas;
        int alertsched;
            
        private void button1_Click(object sender, EventArgs e)
        {
            alertsched = 0;
            datas = new string[9];  
            rrp = 0; rri = 0;
            double amount = 0,balance = 0;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells[2].Style.ForeColor == System.Drawing.Color.Red)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells[3].Style.ForeColor == System.Drawing.Color.Red)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells[4].Style.ForeColor == System.Drawing.Color.Red)
                {
                    balance += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
            }
            if (Convert.ToDecimal(textBox8.Text) > Convert.ToDecimal(amount))
            {
                MessageBox.Show("Amount payment is too much" + amount);
                return;
            }
            if (Convert.ToDecimal(textBox2.Text) > Convert.ToDecimal(balance))
            {
                MessageBox.Show("Amount balance is too much");
                return;
            }
            reciept.balancealert = 0;
            rp = 0;
            ri = 0;
            rpp = string.Empty;
            rb = string.Empty;
            if (type == "Emergency Loan")
            {
                alertsched = 1;
                reciept.sched = new string[1];
                reciept.sched[0] = Convert.ToDateTime(dataGridView1.Rows[0].Cells[0].Value.ToString()).ToShortDateString();
                if (Convert.ToDouble(textBox8.Text) != 0)
                {
                    e_payment();
                }
                if (Convert.ToDouble(textBox2.Text) != 0)
                {
                    e_balance();
                }
                MessageBox.Show("Payment Successfully!");
                rpp = textBox1.Text;
                rb = textBox2.Text;
                accountinfo_e();
            }
            else
            {
                if (Convert.ToDouble(textBox8.Text) != 0)
                {

                    alertsched = 1;
                    if (ctr > 1)
                    {
                        reciept.sched = new string[2];
                        reciept.sched[0] = Convert.ToDateTime(sched[0]).ToShortDateString();
                        reciept.sched[1] = Convert.ToDateTime(sched[ctr-1]).ToShortDateString();
                    }
                    else
                    {
                        reciept.sched = new string[1];
                        reciept.sched[0] = Convert.ToDateTime(sched[0]).ToShortDateString();
                    }
                    p_payment();
                }
                if (Convert.ToDouble(textBox2.Text) != 0)
                {
                    reciept.balancealert = 1;
                    
                    if (balancepaymentdata.Count > 1)
                    {
                        reciept.bsched = new string[2];
                        reciept.bsched[0] = Convert.ToDateTime(balancepaymentdata[0][0]).ToShortDateString();
                        reciept.bsched[1] = Convert.ToDateTime(balancepaymentdata[balancepaymentdata.Count-1][0]).ToShortDateString();
                    }
                    else
                    {
                        reciept.bsched = new string[1];
                        reciept.bsched[0] = Convert.ToDateTime(balancepaymentdata[0][0]).ToShortDateString();
                    }
                    p_balancepayment();
                }
                MessageBox.Show("Payment Successfully!");
                rpp = textBox1.Text;
                rb = textBox2.Text;
                textBox8.Clear();
                textBox1.Clear();
                accountinfo_p();
            }

            datas[0] = id;
            if (alertsched != 0)
            {
                if (reciept.sched.Length > 1)
                {
                    datas[8] = Convert.ToDateTime(reciept.sched[0]).ToLongDateString() + " - " + Convert.ToDateTime(reciept.sched[1]).ToLongDateString();
                }
                else
                {
                    datas[8] = Convert.ToDateTime(reciept.sched[0]).ToLongDateString();
                }
            }
            else
            {
                if (reciept.bsched.Length > 1)
                {
                    datas[8] = Convert.ToDateTime(reciept.bsched[0]).ToLongDateString() + " - " + Convert.ToDateTime(reciept.bsched[1]).ToLongDateString();
                }
                else
                {
                    datas[8] = Convert.ToDateTime(reciept.bsched[0]).ToLongDateString();
                }
            }
            if (alertsched != 0)
            {
                if (Convert.ToDateTime(reciept.sched[0]) < DateTime.Now)
                {
                    datas[1] = "Delayed Payment";
                }
                else if (Convert.ToDateTime(reciept.sched[0]) == DateTime.Now)
                {
                    datas[1] = "On time Payment";
                }
                else
                {
                    datas[1] = "Early Payment";
                }
            }
            else
            {
                if (Convert.ToDateTime(reciept.bsched[0]) < DateTime.Now)
                {
                    datas[1] = "Delayed Payment";
                }
                else if (Convert.ToDateTime(reciept.bsched[0]) == DateTime.Now)
                {
                    datas[1] = "On time Payment";
                }
                else
                {
                    datas[1] = "Early Payment";
                }
            }
            datas[2] = comboBox1.Text;
            datas[3] = rri.ToString("n2");
            datas[4] = rrp.ToString("n2");
            datas[5] = Convert.ToDouble(rpp).ToString("n2");
            datas[6] = (Convert.ToDouble(rpp) + rri + rrp).ToString("n2");
            datas[7] = Form1.user;
            rrvoid();
            reciept r = new reciept();
            reciept.data = new string[8];
            reciept.data[0] = fname;
            reciept.data[1] = comboBox1.Text;
            reciept.data[2] = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            reciept.data[3] = rp.ToString("n2");
            reciept.data[4] = ri.ToString("n2");
            reciept.data[5] = Convert.ToDouble(rb).ToString("n2");
            reciept.data[6] = Convert.ToDouble(rpp).ToString("n2");
            reciept.data[7] = (Convert.ToDouble(reciept.data[3])+ Convert.ToDouble(reciept.data[4]) + Convert.ToDouble(reciept.data[5]) + Convert.ToDouble(reciept.data[6])).ToString("n2"); 
            r.ShowDialog();
        }
        public void rrvoid()
        {
            con.Open();
            string strAdd = "insert into revenuew values('" + datas[0] + "','" + datas[1] + "','" + datas[2] + "','" + datas[3] + "','" + datas[4] + "','" + datas[5] + "','" + datas[6] + "','" + datas[7].Replace("'","''") + "',null,'"+datas[8]+"','"+DateTime.Now.ToLongDateString()+"')";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void interest_e()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAdd = "Select ginterest from loanmaintenance";
            da = new OdbcDataAdapter(strAdd, con);
            da.Fill(dt);
            con.Close();
            pinterest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
        }

        public void interest_p()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAdd = "Select ppenalty from loanmaintenance";
            da = new OdbcDataAdapter(strAdd, con);
            da.Fill(dt);
            con.Close();
            pinterest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(type == "Personal Loan")
                paymentchangepersonal();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(type == "Personal Loan")
            balancepaymentchange();
        }

        public void number(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                label25.Visible = true;
                label25.Text = "Letters is not allowed in payment transaction! ";
                label25.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label25.Visible = false;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox8.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 46 && ch != 127)
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
                string text = textBox8.Text;
                for (int x = 0; x < textBox8.TextLength; x++)
                {
                    if (textBox8.Text[x] != '0' && x > 0)
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
                if (index > 6 && cursorposition <= index && ch != 8 && ch != 127)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (ch == 46 && textBox2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 46 && ch != 127)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            double amount = 0;
            double balance = 0;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells[6].Selected == true && dataGridView1.Rows[x].Cells[6].Style.ForeColor != System.Drawing.Color.Blue)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[6].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
                }

                if (dataGridView1.Rows[x].Cells[4].Selected == true && dataGridView1.Rows[x].Cells[4].Style.ForeColor != System.Drawing.Color.Blue)
                {
                    balance += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
            }
            textBox8.Text = amount.ToString();
            textBox2.Text = balance.ToString();

        
        }

        private void dataGridView1_MultiSelectChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            double amount = 0;
            double balance = 0;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells[6].Selected == true && dataGridView1.Rows[x].Cells[6].Style.ForeColor != System.Drawing.Color.Blue)
                {
                    amount += Convert.ToDouble(dataGridView1.Rows[x].Cells[6].Value.ToString()) - Convert.ToDouble(dataGridView1.Rows[x].Cells[5].Value.ToString());
                }

                if (dataGridView1.Rows[x].Cells[4].Selected == true && dataGridView1.Rows[x].Cells[4].Style.ForeColor != System.Drawing.Color.Blue)
                {
                    balance += Convert.ToDouble(dataGridView1.Rows[x].Cells[4].Value.ToString());
                }
            }
            textBox8.Text = amount.ToString();
            textBox2.Text = balance.ToString();
        }
    }
}

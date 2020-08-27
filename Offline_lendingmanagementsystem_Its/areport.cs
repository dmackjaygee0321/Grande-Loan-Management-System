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
    public partial class areport : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public areport()
        {
            InitializeComponent();
        }

        private void areport_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        DateTime now = DateTime.Now;
        public void display()
        {
            dataGridView2.Rows.Clear();
            label8.Text = "0";
            label9.Text = "0";
            label10.Text = "0";
            label11.Text = "0";
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.Visible = false;
                label12.Visible = false;
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "select a.id, concat(b.lastname,' ',b.firstname,' ',b.middlename) as name,(typeofpayment)as actno,a.sched,a.actno,a.interest,a.principal,a.penalty,a.totalpayment,a.paymentdated,a.processby from revenuew as a, customerinfo as b where a.id = b.no order by a.paymentdated ";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                double interest = 0;
                double total = 0;
                double penalty = 0;
                double principal = 0;
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    if (Convert.ToDateTime(dateTimePicker1.Text) <= Convert.ToDateTime(dt.Rows[x].ItemArray[9].ToString()) && Convert.ToDateTime(dateTimePicker2.Text) >= Convert.ToDateTime(dt.Rows[x].ItemArray[9].ToString()))
                    {
                        dataGridView2.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[4].ToString(), dt.Rows[x].ItemArray[5].ToString(), dt.Rows[x].ItemArray[6].ToString(), dt.Rows[x].ItemArray[7].ToString(), dt.Rows[x].ItemArray[8].ToString(), dt.Rows[x].ItemArray[9].ToString(), dt.Rows[x].ItemArray[10].ToString());
                        interest += Convert.ToDouble(dt.Rows[x].ItemArray[5].ToString());
                        principal += Convert.ToDouble(dt.Rows[x].ItemArray[6].ToString());
                        penalty += Convert.ToDouble(dt.Rows[x].ItemArray[7].ToString());
                        total += Convert.ToDouble(dt.Rows[x].ItemArray[8].ToString());
                    }
                }
                label8.Text = penalty.ToString("n2");
                label9.Text = interest.ToString("n2");
                label10.Text = principal.ToString("n2");
                label11.Text = total.ToString("n2");
            }
            else
            {
                dataGridView2.Rows.Clear();
                dataGridView2.Columns[9].Visible = false;
                dataGridView2.Columns[10].Visible = false;
                comboBox2.Visible = true;
                label12.Visible = true;
                if (comboBox2.SelectedIndex == 0)
                {
                    interest_e();
                    con.Open();
                    DataTable dt = new DataTable();
                    string strAcct = "select a.No,concat (b.LastName,' ',b.FirstName,' ',b.MiddleName) as fullname, a.Accid,a.DueDate, a.TotalInterest," +
                    "(a.TotalPayment - a.TotalInterest), a.TotalPayment,a.WeeklyInterest from emergencyloan as a, customerinfo as b where a.No = b.No order by cast(a.DueDate as date) ";
                    da = new OdbcDataAdapter(strAcct, con);
                    da.Fill(dt);
                    con.Close();
                    double tinterest = 0;
                    double ttotal = 0;
                    double tpenalty = 0;
                    double tprincipal = 0;
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        if (Convert.ToDateTime(dateTimePicker1.Text) <= Convert.ToDateTime(dt.Rows[x].ItemArray[3].ToString()) && Convert.ToDateTime(dateTimePicker2.Text) >= Convert.ToDateTime(dt.Rows[x].ItemArray[3].ToString()))
                        {
                            con.Open();
                            DataTable dt1 = new DataTable();
                            string strAcct1 = "select * from payment where id = '" + dt.Rows[x].ItemArray[0].ToString() + "' and acctid = '" + dt.Rows[x].ItemArray[2].ToString() + "'";
                            da = new OdbcDataAdapter(strAcct1, con);
                            da.Fill(dt1);
                            con.Close();
                            if (dt1.Rows.Count > 0)
                            {
                                if (Convert.ToDouble(dt1.Rows[0].ItemArray[6].ToString()) != 0)
                                {
                                    con.Open();
                                    DataTable dt2 = new DataTable();
                                    string strAcct2 = "select (a.TotalPayment - a.TotalInterest) as principal, b.principalpayment from emergencyloan as a, payment as b where a.No = b.id and a.Accid = b.acctid and a.No = '" + dt.Rows[x].ItemArray[0].ToString() + "' and a.Accid = '" + dt.Rows[x].ItemArray[2].ToString() + "' ";
                                    da = new OdbcDataAdapter(strAcct2, con);
                                    da.Fill(dt2);
                                    con.Close();

                                    con.Open();
                                    DataTable dt3 = new DataTable();
                                    string strAcct3 = "select gdaypenalty from loanmaintenance";
                                    da = new OdbcDataAdapter(strAcct3, con);
                                    da.Fill(dt3);
                                    con.Close();
                                    int dayofpenalty = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());

                                    double principalpen = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString()) + Convert.ToDouble(dt2.Rows[0].ItemArray[1].ToString());
                                    double interest = Convert.ToDouble(dt1.Rows[0].ItemArray[4].ToString());
                                    double principal = Convert.ToDouble(dt1.Rows[0].ItemArray[5].ToString());
                                    double penalty = 0;
                                    double vinterest = Convert.ToDouble(dt.Rows[x].ItemArray[4].ToString());
                                    double vprincipal = Convert.ToDouble(dt.Rows[x].ItemArray[5].ToString());
                                    double rinterest = vinterest - interest;
                                    double rprincipal = vprincipal - principal;
                                    DateTime d = Convert.ToDateTime(Convert.ToDateTime(dt1.Rows[0].ItemArray[9].ToString()));
                                    DateTime datedelay = d;
                                    DateTime date = d;
                                    int delayno = 0;
                                    double balance = Convert.ToDouble(dt1.Rows[0].ItemArray[6].ToString());
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
                                    dataGridView2.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt1.Rows[0].ItemArray[3].ToString(), rinterest, rprincipal, penalty, (rprincipal + rinterest + penalty)); interest += Convert.ToDouble(dt.Rows[x].ItemArray[5].ToString());
                                    tprincipal += rprincipal;
                                    tpenalty += penalty;
                                    ttotal += (rprincipal + rinterest + penalty);
                                    tinterest += rinterest;
                                }
                            }
                            else
                            {
                                con.Open();
                                DataTable dt2 = new DataTable();
                                string strAcct2 = "select BorrowedMoney from loan where accid = '" + dt.Rows[x].ItemArray[2].ToString() + "' and No = '" + dt.Rows[x].ItemArray[0].ToString() + "'	";
                                da = new OdbcDataAdapter(strAcct2, con);
                                da.Fill(dt2);
                                con.Close();
                                double principalpen = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString());

                                string typeofpaid = string.Empty;
                                DateTime d = Convert.ToDateTime(dt.Rows[x].ItemArray[3].ToString());
                                double penalty = 0;
                                double weeklyinterest = Convert.ToDouble(dt.Rows[x].ItemArray[7].ToString());
                                if (d > now)
                                {
                                    typeofpaid = "Early Payment";
                                }
                                else if (d.ToLongDateString() == now.ToLongDateString())
                                {
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
                                }
                                dataGridView2.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), typeofpaid, dt.Rows[x].ItemArray[4].ToString(), dt.Rows[x].ItemArray[5].ToString(), penalty, Convert.ToDouble(dt.Rows[x].ItemArray[6].ToString()) + penalty);
                                tprincipal += Convert.ToDouble(dt.Rows[x].ItemArray[5].ToString());
                                tpenalty += penalty;
                                ttotal += Convert.ToDouble(dt.Rows[x].ItemArray[6].ToString()) + penalty;
                                tinterest += Convert.ToDouble(dt.Rows[x].ItemArray[4].ToString());
                            }
                        }
                    }
                    label8.Text = tpenalty.ToString("n2");
                    label9.Text = tinterest.ToString("n2");
                    label10.Text = tprincipal.ToString("n2");
                    label11.Text = ttotal.ToString("n2");
                }
                else
                {
                    interest_p();
                    con.Open();
                    DataTable dt = new DataTable();
                    string strAcct = "select a.No,a.Accid+1,a.MonthlyInterest,(select concat(LastName,' ',FirstName,' ',MiddleName) from customerinfo where No=a.No ), " +
                    "a.MonthlyPrincipal,b.date from personalloan as a, customersched as b where " +
                    "a.No = b.No and b.acctno = a.Accid";
                    da = new OdbcDataAdapter(strAcct, con);
                    da.Fill(dt);
                    con.Close();
                    double tinterest = 0;
                    double ttotal = 0;
                    double tpenalty = 0;
                    double tprincipal = 0;
                    for (int x = 0; x < dt.Rows.Count; x++)
                    {
                        if (Convert.ToDateTime(dateTimePicker1.Text) <= Convert.ToDateTime(dt.Rows[x].ItemArray[5].ToString()) && Convert.ToDateTime(dateTimePicker2.Text) >= Convert.ToDateTime(dt.Rows[x].ItemArray[5].ToString()))
                        {
                            con.Open();
                            DataTable dt1 = new DataTable();
                            string strAcct1 = "select * from payment where id = '" + dt.Rows[x].ItemArray[0].ToString() + "' and acctid = '" + (Convert.ToDouble(dt.Rows[x].ItemArray[1].ToString()) - 1) + "' and paymentsched = '" + dt.Rows[x].ItemArray[5].ToString() + "'";
                            da = new OdbcDataAdapter(strAcct1, con);
                            da.Fill(dt1);
                            con.Close();
                            if (dt1.Rows.Count > 0)
                            {
                                if (Convert.ToDouble(dt1.Rows[0].ItemArray[6].ToString()) != 0)
                                {
                                    double interest = Convert.ToDouble(dt1.Rows[0].ItemArray[4].ToString());
                                    double principal = Convert.ToDouble(dt1.Rows[0].ItemArray[5].ToString());
                                    double penalty = 0;
                                    double vinterest = Convert.ToDouble(dt.Rows[x].ItemArray[2].ToString());
                                    double vprincipal = Convert.ToDouble(dt.Rows[x].ItemArray[4].ToString());
                                    double rinterest = vinterest - interest;
                                    double rprincipal = vprincipal - principal;
                                    DateTime duedate = Convert.ToDateTime(dt1.Rows[0].ItemArray[2].ToString());
                                    DateTime date = duedate;
                                    int delayno = 0; 
                                    
                                    con.Open();
                                    DataTable dt3 = new DataTable();
                                    string strAcct3 = "select pdaypenalty from loanmaintenance";
                                    da = new OdbcDataAdapter(strAcct3, con);
                                    da.Fill(dt3);
                                    con.Close();
                                    int dayofpenalty = Convert.ToInt32(dt3.Rows[0].ItemArray[0].ToString());
                                    int nopenalty = 0;
                                    while (date < now)
                                    {
                                        delayno++;
                                        if (date >= duedate.AddDays(dayofpenalty))
                                        {
                                            nopenalty++;
                                        }
                                        date = duedate.AddDays(nopenalty);
                                    }
                                    penalty = pinterest * (nopenalty);

                                    dataGridView2.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[5].ToString(), dt1.Rows[0].ItemArray[3].ToString(), rinterest, rprincipal, penalty, (rinterest + rprincipal + penalty));
                                    tprincipal += rprincipal;
                                    tpenalty += penalty;
                                    ttotal += (rprincipal + rinterest + penalty);
                                    tinterest += rinterest;
                                }
                            }
                            else
                            {
                                string typeofpaid = string.Empty;
                                DateTime duedate = Convert.ToDateTime(dt.Rows[x].ItemArray[5].ToString());
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
                                    int nopenalty = 0;

                                    typeofpaid = "Delay Payment";
                                    DateTime date = duedate;
                                    int delayno = 0;
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
                                }
                                double interest = Convert.ToDouble(dt.Rows[x].ItemArray[2].ToString());
                                double principal = Convert.ToDouble(dt.Rows[x].ItemArray[4].ToString());
                                dataGridView2.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[5].ToString(), typeofpaid, interest, principal, penalty, (interest + principal + penalty));
                                tprincipal += interest;
                                tpenalty += penalty;
                                ttotal += (principal + interest + penalty);
                                tinterest += interest;
                            }
                        }
                    }
                    label8.Text = tpenalty.ToString("n2");
                    label9.Text = tinterest.ToString("n2");
                    label10.Text = tprincipal.ToString("n2");
                    label11.Text = ttotal.ToString("n2");
                }

            }
        }
        double pinterest;
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
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            display();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            display();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            display();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                accountreport a = new accountreport();
                accountreport.datalength = dataGridView2.Rows.Count;
                accountreport.data = new string[dataGridView2.Rows.Count, 6];
                for (int x = 0; x < dataGridView2.Rows.Count; x++)
                {
                    accountreport.data[x, 0] = dataGridView2.Rows[x].Cells[0].Value.ToString();
                    accountreport.data[x, 1] = dataGridView2.Rows[x].Cells[1].Value.ToString();
                    accountreport.data[x, 2] = Convert.ToDouble(dataGridView2.Rows[x].Cells[6].Value.ToString()).ToString("n2");
                    accountreport.data[x, 3] = Convert.ToDouble(dataGridView2.Rows[x].Cells[5].Value.ToString()).ToString("n2");
                    accountreport.data[x, 4] = Convert.ToDouble(dataGridView2.Rows[x].Cells[7].Value.ToString()).ToString("n2");
                    accountreport.data[x, 5] = Convert.ToDouble(dataGridView2.Rows[x].Cells[8].Value.ToString()).ToString("n2");
                }
                accountreport.accountinfo = new string[7];
                accountreport.accountinfo[0] = comboBox1.Text;
                accountreport.accountinfo[1] = comboBox2.Text;
                accountreport.accountinfo[2] = "From " + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + " to " + Convert.ToDateTime(dateTimePicker2.Text).ToShortDateString();
                accountreport.accountinfo[3] = label8.Text;
                accountreport.accountinfo[4] = label9.Text;
                accountreport.accountinfo[5] = label10.Text;
                accountreport.accountinfo[6] = label11.Text;
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("Empty Record", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

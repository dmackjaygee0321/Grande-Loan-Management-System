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
    public partial class Borrowerinformation : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Borrowerinformation()
        {
            InitializeComponent();
        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, (vScrollBar1.Value - (vScrollBar1.Value * 2)));
        }

        private void Borrowerinformation_Load(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = 400;
            vScrollBar1.Minimum = -57;
            vScrollBar1.Value = -57;
        }

        public static string id, search;
        string fullname;
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fullname = dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString() + " " + dt.Rows[0].ItemArray[3].ToString();
            label4.Text = "Lastname: " + dt.Rows[0].ItemArray[1].ToString();
            label5.Text = "Firstname: " + dt.Rows[0].ItemArray[2].ToString();
            label1.Text = "Middlename: " + dt.Rows[0].ItemArray[3].ToString();
            label6.Text = "Address: " + dt.Rows[0].ItemArray[4].ToString();
            label7.Text = "Birthday: " + Convert.ToDateTime(dt.Rows[0].ItemArray[5].ToString()).ToShortDateString();
            label26.Text = "Gender: " + dt.Rows[0].ItemArray[6].ToString();
            label8.Text = "Email Address: " + dt.Rows[0].ItemArray[7].ToString();
            label9.Text = "Phone Number: " + dt.Rows[0].ItemArray[8].ToString();
            label10.Text = "Company Name: " + dt.Rows[0].ItemArray[9].ToString();
            label11.Text = "Occupation: " + dt.Rows[0].ItemArray[10].ToString();
            label24.Text = "Salary: " + dt.Rows[0].ItemArray[16].ToString();
            string replace = dt.Rows[0].ItemArray[12].ToString().Replace('*', '\\');
            string replace1 = dt.Rows[0].ItemArray[13].ToString().Replace('*', '\\');
            pbpic.Image = Image.FromFile(replace);
            pbpic1.Image = Image.FromFile(replace1);
        }
        public void statistic()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select sum(BorrowedMoney), count(*) from loan where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            double tinterestpayment = 0, etotalinteres = 0, ptotalinteres = 0;

            DataTable dt5 = new DataTable();
            string strAcct5 = "select * from payment where id='"+id+"'";
            da = new OdbcDataAdapter(strAcct5, con);
            da.Fill(dt5);

            if (dt5.Rows.Count > 0)
            {
                DataTable dt6 = new DataTable();
                string strAcct6 = "select sum(interestpayment) from payment where id='" + id + "'";
                da = new OdbcDataAdapter(strAcct6, con);
                da.Fill(dt6);
                tinterestpayment = Convert.ToDouble(dt6.Rows[0].ItemArray[0].ToString());
            }

            DataTable dt7 = new DataTable();
            string strAcct7 = "select * from emergencyloan where No ='" + id + "'";
            da = new OdbcDataAdapter(strAcct7, con);
            da.Fill(dt7);
            if (dt7.Rows.Count > 0)
            {
                DataTable dt6 = new DataTable();
                string strAcct6 = "select sum(TotalInterest) from emergencyloan where No='" + id + "'";
                da = new OdbcDataAdapter(strAcct6, con);
                da.Fill(dt6);
                etotalinteres = Convert.ToDouble(dt6.Rows[0].ItemArray[0].ToString());
            }
            DataTable dt8 = new DataTable();
            string strAcct8 = "select * from personalloan where No ='" + id + "'";
            da = new OdbcDataAdapter(strAcct8, con);
            da.Fill(dt8);

            if (dt8.Rows.Count > 0)
            {
                DataTable dt6 = new DataTable();
                string strAcct6 = "select sum(TotalInterest) from personalloan where No='" + id + "'";
                da = new OdbcDataAdapter(strAcct6, con);
                da.Fill(dt6);
                ptotalinteres = Convert.ToDouble(dt6.Rows[0].ItemArray[0].ToString());
            }

            /*
            DataTable dt2 = new DataTable();
            string strAcct2 = "select sum(a.interestpayment), (select sum(TotalInterest) from emergencyloan where No=a.id)," +
            "(select sum(TotalInterest) from personalloan where No=a.id) from payment as a where a.id ='" + id + "'";
            da = new OdbcDataAdapter(strAcct2, con);
            da.Fill(dt2);
            */
            con.Close();
            int number = Convert.ToInt32(dt.Rows[0].ItemArray[1].ToString());
            if (number != 0)
            {
                double sumborrow = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                double avelend = sumborrow / number;
                label12.Text = "Average Lend Amount: " + avelend.ToString("n2");
                label15.Text = "Lend Issued: " + sumborrow.ToString("n2");
                con.Open();
                DataTable dt3 = new DataTable();
                string strAcct3 = "select * from personalloan where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct3, con);
                da.Fill(dt3);
                DataTable dt4 = new DataTable();
                string strAcct4 = "select * from emergencyloan where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct4, con);
                da.Fill(dt4);
                con.Close();
                double interestpersonal = 0;
                double interestemergency = 0;
                if (dt3.Rows.Count > 0)
                {
                    interestpersonal = ptotalinteres;
                }
                if (dt4.Rows.Count > 0)
                {
                    interestemergency = etotalinteres;
                }
                double interestpayment = tinterestpayment;
                double totalinterest = interestemergency + interestpersonal;
                double e = totalinterest / 100;
                double f = interestpayment / e;
                label3.Text = "Net Return: " + f.ToString("n2")+"%";
                con.Open();
                DataTable dt9 = new DataTable();
                string strAcct9 = "select (select count(id) from payment where id = a.No) as customerschedno, (select count(id) from payment where id=a.No and typeofpayment = 'Delay Payment')" +
                "from customerinfo as a where a.No = '"+id+"'";
                da = new OdbcDataAdapter(strAcct9, con);
                da.Fill(dt9);
                con.Close();
                double a = Convert.ToInt32(dt9.Rows[0].ItemArray[0].ToString());
                if (a == 0)
                {
                    label17.Text = "Borrower Behavior: " + 100 + "%";
                    return;
                }
                double b = Convert.ToInt32(dt9.Rows[0].ItemArray[1].ToString());
                double c = a / 100;
                double d = 100 - (b / c);
                label17.Text = "Borrower Behavior: " + d.ToString("n2") + "%";
                               
            }
            else
            {
 
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            search = textBox1.Text;
            dialogsearch_bi d = new dialogsearch_bi();
            d.ShowDialog();
            if (d.DialogResult == DialogResult.OK)
            {
                display();
                statistic();
                loaninfo();
                activity();
            }
        }

        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'View Borrower Information','" + fullname.Replace("'","''")+ "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void loaninfo()
        {
            con.Open();
            DataTable dt1 = new DataTable();
            string strAcct1 = "select Accid from loan where No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
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
                comboBox1.Enabled = false;
            }
        }

        string type;
        public void displaytype()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select Type from loan where No='" + id + "' and Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label18.Text = "Loan Type: " + dt.Rows[0].ItemArray[0].ToString();
            type = dt.Rows[0].ItemArray[0].ToString();
        }

        DateTime now = DateTime.Now;
        double v_principal, v_interest;
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
            if (dt.Rows.Count > 0)
            {
                v_interest = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
                v_principal = (Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString()) - Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()));
                double weeklyinterest = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    if (dt1.Rows.Count > 0)
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
                            dataGridView1.Rows[x].Cells[5].Value = penaltyp.ToString("n2");
                            dataGridView1.Rows[x].Cells[0].Style.ForeColor = System.Drawing.Color.Red;
                            dataGridView1.Rows[x].Cells[1].Style.ForeColor = System.Drawing.Color.Red;
                            DateTime d = Convert.ToDateTime(Convert.ToDateTime(dt1.Rows[x].ItemArray[9].ToString()));
                            DateTime datedelay = d;
                            DateTime date = d;
                            int delayno = 0;
                            double balanceinterest = balance * 0.1;
                            while (date < now)
                            {
                                delayno++;
                                if (date == datedelay.AddDays(4))
                                {
                                    penalty += balanceinterest;
                                    datedelay = datedelay.AddDays(7);
                                }
                                date = d.AddDays(delayno);
                            }
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
                        DateTime d = Convert.ToDateTime(dt.Rows[x].ItemArray[2].ToString());
                        double penalty = 0;
                        if (d > now)
                        {
                            typeofpaid = "Early Payment";
                        }
                        else if (d < now)
                        {
                            typeofpaid = "Delay Payment";
                            DateTime datedelay = d;
                            DateTime date = d;
                            int delayno = 0;
                            while (date < now)
                            {
                                delayno++;
                                if (date == datedelay.AddDays(4))
                                {
                                    penalty += weeklyinterest;
                                    datedelay = datedelay.AddDays(7);
                                }
                                date = d.AddDays(delayno);
                            }
                        }
                        else
                        {
                            typeofpaid = "On Time Payment";
                        }
                        dataGridView1.Rows.Add(dt.Rows[x].ItemArray[2].ToString(), typeofpaid, (Convert.ToDouble(dt.Rows[x].ItemArray[1].ToString()) - Convert.ToDouble(dt.Rows[x].ItemArray[0].ToString())).ToString(), Convert.ToDouble(dt.Rows[x].ItemArray[0].ToString()), "0", penalty.ToString(), "0", "On Going", "On Going");
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
        }

        public void accountinfo_p()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.No,a.Accid, b.date," +
            "(Select MonthlyInterest from personalloan where No = a.No && Accid = a.Accid) as MonthlyInterest," +
            "(Select MonthlyPrincipal from personalloan where No = a.No && Accid = a.Accid) as MonthlyPrincipal " +
            "from loan as a, customersched as b where a.No = b.No and b.acctno = a.Accid and " +
            "a.Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and a.No = '" + id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select * from payment where acctid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and id = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            con.Close();
            dataGridView1.Rows.Clear();
            v_interest = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString());
            v_principal = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());
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
                        dataGridView1.Rows[x].Cells[5].Value = penaltyp.ToString("n2");
                        dataGridView1.Rows[x].Cells[0].Style.ForeColor = System.Drawing.Color.Red;
                        dataGridView1.Rows[x].Cells[1].Style.ForeColor = System.Drawing.Color.Red;

                        DateTime duedate = Convert.ToDateTime(dt1.Rows[x].ItemArray[2].ToString());
                        DateTime date = duedate;
                        int delayno = 0;
                        while (date < now)
                        {
                            delayno++;
                            date = duedate.AddDays(delayno);
                        }
                        penalty = 10 * (delayno - 1);
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
                    else if (duedate < now)
                    {
                        typeofpaid = "Delay Payment";
                        DateTime date = duedate;
                        int delayno = 0;
                        while (date < now)
                        {
                            delayno++;
                            date = duedate.AddDays(delayno);
                        }
                        penalty = 10 * (delayno - 1);
                    }
                    else
                    {
                        typeofpaid = "On Time Payment";
                    }
                    dataGridView1.Rows.Add(dt.Rows[x].ItemArray[2].ToString(), typeofpaid, v_principal, v_interest, balance, penalty, (v_principal + v_interest + penalty), "On Going", "On Going");
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
        public void acountinfo_e()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select Percent,Frequency,Term,WeeklyInterest,TotalPayment from emergencyloan where Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and No = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select BorrowedMoney,LendDate from loan where Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and No = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close();
            label19.Text = "Principal: " + dt1.Rows[0].ItemArray[0].ToString();
            label20.Text = "Interest Rate: " + dt.Rows[0].ItemArray[0].ToString() + "%";
            label21.Text = "Frequency: " + dt.Rows[0].ItemArray[1].ToString();
            label22.Text = "Term: " + dt.Rows[0].ItemArray[2].ToString();
            label23.Text = "Weekly Interest: " + dt.Rows[0].ItemArray[3].ToString();
            label25.Text = "Total Lend: " + dt.Rows[0].ItemArray[4].ToString();
            label27.Text = "Lend Date: " + Convert.ToDateTime(dt1.Rows[0].ItemArray[1].ToString()).ToShortDateString();
            label27.Location = new Point(57, label27.Location.Y);
            label25.Location = new Point(54, label25.Location.Y);
            label23.Location = new Point(20, label23.Location.Y);
        }
        public void acountinfo_p()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select Percent,Frequency,Term,MonthlyInterest,MonthlyPrincipal,TotalInterest,TotalGrandPayment from personalloan where Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and No = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            DataTable dt1 = new DataTable();
            string strAcct1 = "select BorrowedMoney,LendDate from loan where Accid = '" + (Convert.ToInt32(comboBox1.Text) - 1).ToString() + "' and No = '" + id + "'	";
            da = new OdbcDataAdapter(strAcct1, con);
            da.Fill(dt1);
            con.Close(); 
            label19.Text = "Principal: " + dt1.Rows[0].ItemArray[0].ToString();
            label20.Text = "Interest Rate: " + dt.Rows[0].ItemArray[0].ToString() + "%";
            label21.Text = "Frequency: " + dt.Rows[0].ItemArray[1].ToString();
            label22.Text = "Term: " + dt.Rows[0].ItemArray[2].ToString();
            label23.Text = "Monthly Payment: " + (Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString()) + Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString())).ToString("n2");
            label23.Location = new Point(10, label23.Location.Y);
            label25.Text = "Monthly Interest: " + dt.Rows[0].ItemArray[3].ToString();
            label25.Location = new Point(10, label25.Location.Y);
            label27.Text = "Total Interest: " + dt.Rows[0].ItemArray[5].ToString();
            label27.Location = new Point(36, label27.Location.Y);
            label28.Text = "Total Lend: " + dt.Rows[0].ItemArray[6].ToString();
            label29.Text = "Lend Date: " + Convert.ToDateTime(dt1.Rows[0].ItemArray[1].ToString()).ToShortDateString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            displaytype(); 
            if (type == "Personal Loan")
            {
                accountinfo_p();
                acountinfo_p();
                label29.Visible = true;
                label28.Visible = true;
            }
            else
            {
                label29.Visible = false;
                label28.Visible = false;
                accountinfo_e();
                acountinfo_e();
            }
        
        }
    }
}

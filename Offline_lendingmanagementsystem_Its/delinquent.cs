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
    public partial class delinquent : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public delinquent()
        {
            InitializeComponent();
        }

        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.No, a.LastName, a.FirstName, a.MiddleName,(select count(id) from payment where id = a.No) as customerschedno, (select count(id) from payment where id=a.No and typeofpayment = 'Delay Payment')" +
            "from customerinfo as a";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            int index = 0;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                double a = Convert.ToInt32(dt.Rows[x].ItemArray[4].ToString());
                if (a > 0)
                {
                    con.Open();
                    DataTable dt1 = new DataTable();
                    string strAcct1 = "select avg(BorrowedMoney), sum(BorrowedMoney) from loan where No = '" + dt.Rows[x].ItemArray[0].ToString() + "'";
                    da = new OdbcDataAdapter(strAcct1, con);
                    da.Fill(dt1);
                    DataTable dt2 = new DataTable();
                    string strAcct2 = "select sum(a.interestpayment), (select sum(TotalInterest) from emergencyloan where No=a.id)," +
                    "(select sum(TotalInterest) from personalloan where No=a.id) from payment as a where a.id ='" + dt.Rows[x].ItemArray[0] + "'";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();
                    double b = Convert.ToInt32(dt.Rows[x].ItemArray[5].ToString());
                    double c = a / 100;
                    double d = 100 - (b / c);
                    d = Convert.ToDouble(d.ToString("n2"));
                    if (Convert.ToDecimal(d) <= Convert.ToDecimal(per))
                    {
                        con.Open();
                        DataTable dt3 = new DataTable();
                        string strAcct3 = "select * from personalloan where No = '" + dt.Rows[x].ItemArray[0].ToString() + "'";
                        da = new OdbcDataAdapter(strAcct3, con);
                        da.Fill(dt3);
                        DataTable dt4 = new DataTable();
                        string strAcct4 = "select * from emergencyloan where No = '" + dt.Rows[x].ItemArray[0].ToString() + "'";
                        da = new OdbcDataAdapter(strAcct4, con);
                        da.Fill(dt4);
                        con.Close();
                        double interestpersonal = 0;
                        double interestemergency = 0;
                        if (dt3.Rows.Count > 0)
                        {
                            interestpersonal = Convert.ToDouble(dt2.Rows[0].ItemArray[2].ToString());
                        }
                        if (dt4.Rows.Count > 0)
                        {
                            interestemergency = Convert.ToDouble(dt2.Rows[0].ItemArray[1].ToString());
                        }
                        double interestpayment = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString());
                        double totalinterest = interestemergency + interestpersonal;
                        double e = totalinterest / 100;
                        double f = interestpayment / e;
                        dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), d.ToString("n2") + " %", dt1.Rows[0].ItemArray[0].ToString(), dt1.Rows[0].ItemArray[1].ToString(), f.ToString("n2") + " %");
                        dataGridView1.Rows[index].Cells[4].Style.ForeColor = System.Drawing.Color.Red;
                        index++;
                    }
                }

            }
        }
        public void display1()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.No, a.LastName, a.FirstName, a.MiddleName,(select count(id) from payment where id = a.No) as customerschedno, (select count(id) from payment where id=a.No and typeofpayment = 'Delay Payment')" +
            "from customerinfo as a";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            int index = 0;
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                double a = Convert.ToInt32(dt.Rows[x].ItemArray[4].ToString());
                if (a > 0)
                {
                    con.Open();
                    DataTable dt1 = new DataTable();
                    string strAcct1 = "select avg(BorrowedMoney), sum(BorrowedMoney) from loan where No = '" + dt.Rows[x].ItemArray[0].ToString() + "'";
                    da = new OdbcDataAdapter(strAcct1, con);
                    da.Fill(dt1);
                    DataTable dt2 = new DataTable();
                    string strAcct2 = "select sum(a.interestpayment), (select sum(TotalInterest) from emergencyloan where No=a.id)," +
                    "(select sum(TotalInterest) from personalloan where No=a.id) from payment as a where a.id ='" + dt.Rows[x].ItemArray[0] + "'";
                    da = new OdbcDataAdapter(strAcct2, con);
                    da.Fill(dt2);
                    con.Close();
                    double b = Convert.ToInt32(dt.Rows[x].ItemArray[5].ToString());
                    double c = a / 100;
                    double d = 100 - (b / c);
                    d = Convert.ToDouble(d.ToString("n2"));
                    if (d > per)
                    {
                        con.Open();
                        DataTable dt3 = new DataTable();
                        string strAcct3 = "select * from personalloan where No = '" + dt.Rows[x].ItemArray[0].ToString() + "'";
                        da = new OdbcDataAdapter(strAcct3, con);
                        da.Fill(dt3);
                        DataTable dt4 = new DataTable();
                        string strAcct4 = "select * from emergencyloan where No = '" + dt.Rows[x].ItemArray[0].ToString() + "'";
                        da = new OdbcDataAdapter(strAcct4, con);
                        da.Fill(dt4);
                        con.Close();
                        double interestpersonal = 0;
                        double interestemergency = 0;
                        if (dt3.Rows.Count > 0)
                        {
                            interestpersonal = Convert.ToDouble(dt2.Rows[0].ItemArray[2].ToString());
                        }
                        if (dt4.Rows.Count > 0)
                        {
                            interestemergency = Convert.ToDouble(dt2.Rows[0].ItemArray[1].ToString());
                        }
                        double interestpayment = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString());
                        double totalinterest = interestemergency + interestpersonal;
                        double e = totalinterest / 100;
                        double f = interestpayment / e;
                        dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), d.ToString("n2") + " %", dt1.Rows[0].ItemArray[0].ToString(), dt1.Rows[0].ItemArray[1].ToString(), f.ToString("n2") + " %");
                        dataGridView1.Rows[index].Cells[4].Style.ForeColor = System.Drawing.Color.Blue;
                        index++;
                     
                    }

                }

            }
        }
        private void delinquent_Load(object sender, EventArgs e)
        {
            button5.Visible = false;
            comboBox1.SelectedIndex = 0;
            userlevel();
        }

        public void userlevel()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select reports from userlevel where usertype = '" + Form1.usertype + "' ";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (dt.Rows[0].ItemArray[0].ToString() == "no")
            {
                button5.Enabled = false;
            }
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            clif();
            if (comboBox1.SelectedIndex == 0)
            {
                display1();
            }
            else
            {
                display();
            }
        }
        double per;
        public void clif()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select delinquent from loanmaintenance";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            per = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString());
        }
        private void button5_Click(object sender, EventArgs e)
        {
            BorrowerReport b = new BorrowerReport();
            BorrowerReport.data = new string[dataGridView1.Rows.Count, 3];
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                BorrowerReport.data[x, 0] = dataGridView1.Rows[x].Cells[0].Value.ToString();
                BorrowerReport.data[x, 1] = dataGridView1.Rows[x].Cells[1].Value.ToString() + " " + dataGridView1.Rows[x].Cells[2].Value.ToString() + " " + dataGridView1.Rows[x].Cells[3].Value.ToString();
                BorrowerReport.data[x, 2] = dataGridView1.Rows[x].Cells[4].Value.ToString();
            }
            BorrowerReport.length = dataGridView1.Rows.Count;
            BorrowerReport.type = comboBox1.Text;
            b.ShowDialog();
        }

        
    }
}

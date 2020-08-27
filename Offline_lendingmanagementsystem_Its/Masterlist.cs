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
    public partial class Masterlist : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Masterlist()
        {
            InitializeComponent();
        }

        private void Masterlist_Load(object sender, EventArgs e)
        {
            button5.Visible = false;
            display();
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
        public void display()
        {

            string search = textBox3.Text.Trim().Replace("'", "''");
            dataGridView1.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.No,concat(a.LastName,' ',a.FirstName,' ',a.MiddleName) as Name,a.Address,a.CompanyName,a.Ocupation, "+
            "(select concat(LastName,' ',FirstName,' ',MiddleName) from comakerinfo where No=a.Comaker) as comaker from customerinfo as a where concat(a.LastName,' ',a.FirstName,' ',a.MiddleName) like '%" + search + "%' || a.No like '%" + search + "%'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                con.Open();
                DataTable dt1 = new DataTable();
                string strAcct1 = "select count(No), sum(BorrowedMoney) from loan where No = '"+dt.Rows[x].ItemArray[0].ToString()+"'";
                da = new OdbcDataAdapter(strAcct1, con);
                da.Fill(dt1);
                con.Close(); 
                con.Open();
                DataTable dt2 = new DataTable();
                string strAcct2 = "select count(a.id), (select count(id) from payment where typeofpayment = 'Delayed Payment' and id = a.id) from payment as a where a.id = '"+dt.Rows[x].ItemArray[0].ToString()+"'";
                da = new OdbcDataAdapter(strAcct2, con);
                da.Fill(dt2);
                con.Close();
                int No = Convert.ToInt32(dt1.Rows[0].ItemArray[0].ToString());
                double sum = 0;
                double avelendamount = 0;
               
                if (No != 0)
                {
                    sum = Convert.ToDouble(dt1.Rows[0].ItemArray[1].ToString());
                    avelendamount = sum / No;
                }
                string comaker= string.Empty;
                if (dt.Rows[x].ItemArray[5].ToString() != string.Empty)
                    comaker = dt.Rows[x].ItemArray[5].ToString();
                else
                    comaker = "None";
                string borrowerstatus;
                double a = Convert.ToDouble(dt2.Rows[0].ItemArray[0].ToString());
                if (a > 0)
                {
                    double b = Convert.ToInt32(dt2.Rows[0].ItemArray[1].ToString());
                    double c = a / 100;
                    double d = 100 - (b / c);
                    if (d > 50)
                    {
                        borrowerstatus = "Good Payer";
                    }
                    else
                    {
                        borrowerstatus = "Delinquent Payer";
                    }
                }
                else
                {
                    borrowerstatus = "None";
                }
                dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[4].ToString(), comaker,avelendamount.ToString("n2"),borrowerstatus);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            display();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            masterlistreport m = new masterlistreport();
            masterlistreport.length = dataGridView1.Rows.Count;
            masterlistreport.data = new string[dataGridView1.Rows.Count,5];;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                masterlistreport.data[x, 0] = dataGridView1.Rows[x].Cells[0].Value.ToString();
                masterlistreport.data[x, 1] = dataGridView1.Rows[x].Cells[1].Value.ToString();
                masterlistreport.data[x, 2] = dataGridView1.Rows[x].Cells[3].Value.ToString();
                masterlistreport.data[x, 3] = dataGridView1.Rows[x].Cells[4].Value.ToString();
                masterlistreport.data[x, 4] = dataGridView1.Rows[x].Cells[6].Value.ToString(); 
            }
            m.ShowDialog();
        }
    }
}

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
    public partial class Activitylog : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Activitylog()
        {
            InitializeComponent();
        }

        private void Activitylog_Load(object sender, EventArgs e)
        {
            display();
        }
        public void display()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select a.userid, concat (b.lname,' ',b.fname,' ',b.mname) as fullname, b.userlevel ,a.userprocess,a.userdescription, concat (a.dateofprocess,' ',a.timeofprocess) as dateofprocess from activitylog as a,user as b where a.userid = b.id and a.dateofprocess >= '" + Convert.ToDateTime(dateTimePicker1.Text).ToShortDateString() + "' and a.dateofprocess <= '" + Convert.ToDateTime(dateTimePicker2.Text).ToShortDateString() + "' order by number desc";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                string date= Convert.ToDateTime(dt.Rows[x].ItemArray[5].ToString()).ToShortDateString()+" "+Convert.ToDateTime(dt.Rows[x].ItemArray[5].ToString()).ToShortTimeString();
                dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString(), dt.Rows[x].ItemArray[3].ToString(), dt.Rows[x].ItemArray[4].ToString(), date);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            display();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            display();
        }
    }
}

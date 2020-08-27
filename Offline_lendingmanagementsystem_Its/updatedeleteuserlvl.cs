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
    public partial class updatedeleteuserlvl : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public updatedeleteuserlvl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public static int id;

        private void updatedeleteuserlvl_Load(object sender, EventArgs e)
        {
            display();
        }
        string userlevel;
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from userlevel where id='"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label1.Text = "User Type " + dt.Rows[0].ItemArray[1].ToString();
            label2.Text = "User level No: " + dt.Rows[0].ItemArray[0].ToString();
            userlevel = dt.Rows[0].ItemArray[1].ToString();
            if (dt.Rows[0].ItemArray[2].ToString() == "yes")
            {
                checkBox1.Checked = true;
            }
            if (dt.Rows[0].ItemArray[3].ToString() == "yes")
            {
                checkBox2.Checked = true;
            }
            if (dt.Rows[0].ItemArray[4].ToString() == "yes")
            {
                checkBox3.Checked = true;
            }
            if (dt.Rows[0].ItemArray[5].ToString() == "yes")
            {
                checkBox4.Checked = true;
            }
            if (dt.Rows[0].ItemArray[6].ToString() == "yes")
            {
                checkBox5.Checked = true;
            }
            if (dt.Rows[0].ItemArray[7].ToString() == "yes")
            {
                checkBox6.Checked = true;
            }
            if (dt.Rows[0].ItemArray[8].ToString() == "yes")
            {
                checkBox7.Checked = true;
            }
            if (dt.Rows[0].ItemArray[9].ToString() == "yes")
            {
                checkBox8.Checked = true;
            }
            if (dt.Rows[0].ItemArray[10].ToString() == "yes")
            {
                checkBox10.Checked = true;
            }
            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true && checkBox4.Checked == true && checkBox5.Checked == true && checkBox6.Checked == true && checkBox7.Checked == true && checkBox8.Checked == true && checkBox10.Checked == true)
            {
                checkBox9.Checked = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update_delete();
            delete();
            deleteactivity();
            this.DialogResult = DialogResult.OK;
        }

        public void delete()
        {
            con.Open();
            string delete = "delete from userlevel where id='" + id.ToString() + "'";
            cmd = new OdbcCommand(delete, con);
            cmd.ExecuteNonQuery();
            con.Close(); 
        }
        public void update_delete()
        {
            con.Open();
            string delete = "update user set userlevel = 'Null'  where userlevel ='" + userlevel + "'";
            cmd = new OdbcCommand(delete, con);
            cmd.ExecuteNonQuery();
            con.Close(); 
        }

        public void update(string r1, string r2, string r3, string r4, string r5, string r6, string r7, string r8, string r9)
        {
            con.Open();
            string update = "update userlevel set monitoring ='" + r1 + "',borrowing ='" + r2 + "', transaction ='" + r3 + "',reports ='" + r4 + "',lending ='" + r5 + "',assets ='" + r6 + "',b_r= '" + r7 + "',user= '" + r8 + "',a_d = '" + r9 + "' where id = '" + id + "'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string r1 = "no", r2 = "no", r3 = "no", r4 = "no", r5 = "no", r6 = "no", r7 = "no", r8 = "no", r9 = "no";
            if (checkBox1.Checked == true)
            {
                r1 = "yes";
            }
            if (checkBox2.Checked == true)
            {
                r2 = "yes";
            }
            if (checkBox3.Checked == true)
            {
                r3 = "yes";
            }
            if (checkBox4.Checked == true)
            {
                r4 = "yes";
            }
            if (checkBox5.Checked == true)
            {
                r5 = "yes";
            }
            if (checkBox6.Checked == true)
            {
                r6 = "yes";
            }
            if (checkBox7.Checked == true)
            {
                r7 = "yes";
            }
            if (checkBox8.Checked == true)
            {
                r8 = "yes";
            }
            if (checkBox10.Checked == true)
            {
                r9 = "yes";
            }
            update(r1, r2, r3, r4, r5, r6, r7, r8, r9);
            activity();
            this.DialogResult = DialogResult.OK;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox10.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox10.Checked = false;
            }
        }

        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Update User Previledge','" + userlevel + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void deleteactivity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Delete User Previledge','" + userlevel + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

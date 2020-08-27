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
    public partial class viewattachment : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public viewattachment()
        {
            InitializeComponent();
        }
        public static string id;
        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from attachments where No = '" + CreditInvistigator.id + "' && id = '"+id+"'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            label1.Text += " "+dt.Rows[0].ItemArray[1].ToString();
            textBox2.Text = dt.Rows[0].ItemArray[3].ToString();
            filename = dt.Rows[0].ItemArray[2].ToString().Replace('*','\\');
            pbpic.Image = Image.FromFile(filename);

        }
        string filename;
        private void viewattachment_Load(object sender, EventArgs e)
        {
            textBox2.ShortcutsEnabled = false;
            textBox2.Enabled = false;
            butb1.Enabled = false;
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Update")
            {
                button1.Text = "Save";
                textBox2.Enabled = true;
                butb1.Enabled = true;
            }
            else 
            {
                update();
                button1.Text = "Update";
                activitylog();
                this.DialogResult = DialogResult.OK;
            }
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
            string text = "Update Attachment";
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'" + text + "','" + fn + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void deleteactivitylog()
        {
            string fn = string.Empty;
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No = '" + CreditInvistigator.id + "'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            fn = dt.Rows[0].ItemArray[1].ToString().Trim() + " " + dt.Rows[0].ItemArray[2].ToString().Trim() + " " + dt.Rows[0].ItemArray[3].ToString().Trim();
            string text = "Delete Attachment";
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'" + text + "','" + fn.Replace("'","''") + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string update = "delete from attachments where No='" + CreditInvistigator.id + "'&&id = '"+id+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
            deleteactivitylog();
            this.DialogResult = DialogResult.OK;
        }

        private void butb1_Click(object sender, EventArgs e)
        {
            opb1.Filter = "Image files (*.jpg,*.png) | *.jpg; *.png";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                filename = opb1.FileName.ToString();
                pbpic.Image = Image.FromFile(filename);
            }
        }

        public void update()
        {
            con.Open();
            string replace = filename.Replace('\\','*');
            string update = "update attachments set comment = '"+textBox2.Text+"', filename = '"+replace+"' where id = '"+id+"' and No = '"+CreditInvistigator.id+"'";
            cmd = new OdbcCommand(update, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void viewattachment_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

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
using System.IO;
using System.Reflection;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class Form1 : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public Form1()
        {
            InitializeComponent();
        }
        public static string userid, user,usertype, logintime,filename;
       
        private void Form1_Load(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Form3 p1 = new Form3();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
            label2.Text = "Name: " + user;
            label3.Text = "User Type: " + usertype;
            label1.Text = usertype;
            if (filename != "null")
            {
                string replace = filename.Replace('*', '\\');
                pictureBox2.Image = Image.FromFile(replace);
            }
            panel6.Visible = false;
            panel8.Visible = false;
            timer3.Start();
            timer2.Start();
            button2.TabStop = false;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button21.TabStop = false;
            button21.FlatStyle = FlatStyle.Flat;
            button21.FlatAppearance.BorderSize = 0;

            button7.TabStop = false;
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;

            button8.TabStop = false;
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;

            button9.TabStop = false;
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;

            button10.TabStop = false;
            button10.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderSize = 0;


            button1.TabStop = false;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            panel7.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel5.Visible = false;
            panel12.Visible = false;
            userlevel();
        }
        int ctr2;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ctr2 == 0)
            {
                panel8.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                panel5.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel10.Visible = false;
                panel9.Visible = false;
            }
            ctr2++;
            if (panel1.Location.X <= -20)
            {

                panel1.Location = new Point(panel1.Location.X + 30, panel1.Location.Y);
            }
            else if ((panel1.Location.X + 30) <= -50 && panel1.Location.X <= -10)
            {
                panel1.Location = new Point(panel1.Location.X + 1, panel1.Location.Y);
            }
            else
            {
                ctr++;
                if (ctr == 1)
                {
                    int y = 185;
                    button7.Location = new Point(button7.Location.X, button7.Location.Y + y);
                    button8.Location = new Point(button8.Location.X, button8.Location.Y + y);
                    button9.Location = new Point(button9.Location.X, button9.Location.Y + y);
                    button10.Location = new Point(button10.Location.X, button10.Location.Y + y);
                    button21.Location = new Point(button21.Location.X, button21.Location.Y + y);
                }
                panel3.Visible = true;
            }
        }
        int ctr;
        int ctr1;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ctr1 == 0)
            {
                panel9.Visible = false;
                panel8.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel5.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            }
            ctr1++;
            if (panel1.Location.X >= -210)
            {
                panel1.Location = new Point(panel1.Location.X-30,panel1.Location.Y);
            }
            else
            {
                ctr++;
                if (ctr==1)
                {
                    int y = 185;
                    button7.Location = new Point(button7.Location.X, button7.Location.Y - y);
                    button8.Location = new Point(button8.Location.X, button8.Location.Y - y);
                    button9.Location = new Point(button9.Location.X, button9.Location.Y - y);
                    button10.Location = new Point(button10.Location.X, button10.Location.Y - y);
                    button21.Location = new Point(button21.Location.X, button21.Location.Y - y);
                }
                panel3.Visible = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (timer2.Enabled != true)
            {
                ctr1 = 0;
                ctr = 0;
                timer1.Stop();
                timer2.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctr = 0;
            ctr2 = 0;
            timer2.Stop();
            timer1.Start();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel6.Location = new Point(button7.Location.X+305, button7.Location.Y);
                }
                else
                {
                    panel6.Location = new Point(button7.Location.X + 65, button7.Location.Y);
                }
                panel5.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel9.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel12.Visible = false;
                panel6.Visible = true;
            }
            else
            {
                panel5.Visible = false;
                panel8.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            }
        }
        public static int modes;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
        }

        private void timer4_Tick(object sender, EventArgs e)
        {

            if (modes == 1)
            {
                modes = 0;
                panel4.Controls.Clear();
                Addcus p1 = new Addcus();
                p1.Owner = this;
                p1.TopLevel = false;
                panel4.Controls.Add(p1);
                p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                p1.Dock = DockStyle.Fill;
                p1.Show();
                timer4.Stop();
            }
            else if (modes == 2)
            {
                modes = 0;
                CreditInvistigator.process = 1;
                panel4.Controls.Clear();
                CreditInvistigator p1 = new CreditInvistigator();
                p1.Owner = this;
                p1.TopLevel = false;
                panel4.Controls.Add(p1);
                p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                p1.Dock = DockStyle.Fill;
                p1.Show();
                timer4.Stop();
            }
            else if (modes == 3)
            {
                modes = 0;
                panel4.Controls.Clear();
                AddComaker p1 = new AddComaker();
                p1.Owner = this;
                p1.TopLevel = false;
                panel4.Controls.Add(p1);
                p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                p1.Dock = DockStyle.Fill;
                p1.Show();
                timer4.Stop();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            userlevel p1 = new userlevel();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
            timer4.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            panel4.Controls.Clear();
            user p1 = new user();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
            timer4.Stop();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Form3 p1 = new Form3();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
            timer4.Stop();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            logoutactivity();
            l.Show();
            this.Hide();
        }
        public void logoutactivity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + userid + ",'Logout','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Activitylog p1 = new Activitylog();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        public void userlevel()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select monitoring,borrowing,transaction,reports,lending,assets,b_r,user from userlevel where usertype = '"+usertype+"' ";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            if (dt.Rows[0].ItemArray[0].ToString() == "no")
            {
                button8.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[1].ToString() == "no")
            {
                button19.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[2].ToString() == "no")
            {
                button9.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[3].ToString() == "no")
            {
                button21.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[4].ToString() == "no")
            {
                button23.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[5].ToString() == "no")
            {
                button22.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[6].ToString() == "no")
            {
                button10.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[7].ToString() == "no")
            {
                button18.Enabled = false;
            }
            if (dt.Rows[0].ItemArray[1].ToString() == "no" && dt.Rows[0].ItemArray[4].ToString() == "no" && dt.Rows[0].ItemArray[5].ToString() == "no" && dt.Rows[0].ItemArray[7].ToString() == "no")
            {
                button7.Enabled = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            loanmaintenance p1 = new loanmaintenance();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (panel10.Visible == false)
            {
                if (timer2.Enabled == true)
                    panel10.Location = new Point(button9.Location.X + 83, button9.Location.Y);
                else
                    panel10.Location = new Point(button9.Location.X + 323, button9.Location.Y);
                panel8.Visible = false;
                panel7.Visible = false;
                panel6.Visible = false;
                panel5.Visible = false;
                panel12.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel9.Visible = false;
                panel11.Visible = false;
                panel10.Visible = true;
            }
            else
                panel10.Visible = false;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (panel7.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel7.Location = new Point(button19.Location.X + 490, button19.Location.Y + 234);
                }
                else
                {
                    panel7.Location = new Point(button19.Location.X + 250, button19.Location.Y + 50);
                }
                panel5.Visible = false;
                panel8.Visible = false;
                panel7.Visible = true;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Underline, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            }
            else
            {
                panel7.Visible = false;
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {   
            panel6.Visible = false;
            panel4.Controls.Clear();
            CreditInvistigator p1 = new CreditInvistigator();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel8.Location = new Point(button18.Location.X + 490, button19.Location.Y + 294);
                }
                else
                {
                    panel8.Location = new Point(button18.Location.X + 250, button19.Location.Y + 109);
                }
                panel7.Visible = false;

                panel5.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Underline, GraphicsUnit.Point);
                panel8.Visible = true;
            }
            else
            {
                panel8.Visible = false;
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            if (panel8.Visible == false)
            {
                button20.Font = new Font("Palatino Linotype", button20.Font.Size, FontStyle.Regular, GraphicsUnit.Point);
                button17.Font = new Font("Palatino Linotype", button17.Font.Size, FontStyle.Regular, GraphicsUnit.Point);
                panel8.Visible = true;
            }
            else
            {
                panel8.Visible = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel4.Controls.Clear();
            Goodpayer p1 = new Goodpayer();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel4.Controls.Clear();
            delinquent p1 = new delinquent();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {

            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            user p1 = new user();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();

        }

        private void button17_Click(object sender, EventArgs e)
        {

            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            userlevel p1 = new userlevel();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel4.Controls.Clear();
            Back_up_Restore p1 = new Back_up_Restore();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (panel11.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel11.Location = new Point(button10.Location.X + 314, button10.Location.Y);
                }
                else
                {
                    panel11.Location = new Point(button10.Location.X + 74, button10.Location.Y);
                }
                panel5.Visible = false;
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel8.Visible = false;
                panel7.Visible = false;
                panel12.Visible = false;
                panel6.Visible = false;
                panel10.Visible = false;
                panel9.Visible = false;
                panel11.Visible = true;
            }
            else
            {
                panel11.Visible = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (panel9.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel9.Location = new Point(button8.Location.X + 314, button8.Location.Y);
                }
                else
                {
                    panel9.Location = new Point(button8.Location.X + 74, button8.Location.Y);
                }
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);

                panel5.Visible = false;
                panel12.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel6.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel9.Visible = true;
            }
            else
            {
                panel9.Visible = false;
            }
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            Addcus p1 = new Addcus();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            updateborrowerinfo p1 = new updateborrowerinfo();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel6.Visible = false;
            button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            CreditInvistigator p1 = new CreditInvistigator();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            /*
            panel8.Visible = false;
            panel7.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Regular, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Regular, GraphicsUnit.Point);
            panel4.Controls.Clear();
            loanmaintenance p1 = new loanmaintenance();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
             */
            if (panel5.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel5.Location = new Point(button23.Location.X + 490, button23.Location.Y + 230);
                }
                else
                {
                    panel5.Location = new Point(button23.Location.X + 250, button23.Location.Y + 50);
                }
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Underline, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel7.Visible = false;
                panel8.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel9.Visible = false;
                panel5.Visible = true;
            }
            else
            {
                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel5.Visible = false;
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel4.Controls.Clear();
            delinquent p1 = new delinquent();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
            activity_borrow();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            activity_account();
            panel9.Visible = false;
            panel4.Controls.Clear();
            accountreports p1 = new accountreports();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            activity_master();
            panel9.Visible = false;
            panel4.Controls.Clear();
            Masterlist p1 = new Masterlist();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {

            panel10.Visible = false;
            panel4.Controls.Clear();
            borrow p1 = new borrow();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            panel10.Visible = false;
            panel4.Controls.Clear();
            payment p1 = new payment();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            activity_acitivity();
            panel11.Visible = false;
            panel4.Controls.Clear();
            Activitylog p1 = new Activitylog();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {


            panel11.Visible = false;
            panel4.Controls.Clear();
            Back_up_Restore p1 = new Back_up_Restore();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login l = new Login();
            logoutactivity();
            l.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            panel9.Visible = false;
            panel4.Controls.Clear();
            Borrowerinformation p1 = new Borrowerinformation();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            panel5.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            loanmaintenance p1 = new loanmaintenance();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            attachment_maintenance p1 = new attachment_maintenance();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        public void activity_borrow()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'View Borrower Reports','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void activity_account()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'View Account Reports','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void activity_master()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'View Master List Reports','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void activity_acitivity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'View Activity Log','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            Deduction_m p1 = new Deduction_m();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            panel4.Controls.Clear();
            max_loanmaintenance p1 = new max_loanmaintenance();
            p1.Owner = this;
            p1.TopLevel = false;
            panel4.Controls.Add(p1);
            p1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            p1.Dock = DockStyle.Fill;
            p1.Show();
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            if (panel12.Visible == false)
            {
                if (timer1.Enabled == true)
                {
                    panel12.Location = new Point(button21.Location.X + 314, button21.Location.Y);
                }
                else
                {
                    panel12.Location = new Point(button21.Location.X + 74, button21.Location.Y);
                }

                button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
                panel5.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel6.Visible = false;
                panel10.Visible = false;
                panel11.Visible = false;
                panel9.Visible = false; 
                panel12.Visible = true;
            }
            else
            {
                panel12.Visible = false;
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            breport b = new breport();
            panel12.Visible = false;
            b.ShowDialog();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            areport a = new areport();
            panel12.Visible = false;
            a.ShowDialog();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            mreport m = new mreport();
            panel12.Visible = false;
            m.ShowDialog();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel6.Visible = false;
            button19.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button18.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            button23.Font = new Font("Palatino Linotype", button19.Font.Size, FontStyle.Bold, GraphicsUnit.Point);
            Delinquent_Percentage d = new Delinquent_Percentage();
            d.ShowDialog();
        }
    }
}

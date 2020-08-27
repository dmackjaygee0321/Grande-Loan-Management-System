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
    public partial class statementofact : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public statementofact()
        {
            InitializeComponent();
        }
        int page;
        int refresh;
        int x = 0;
        int length;
        int bound;
        int ebound;
        int y_axis;
        int y_axis1;
        public static string [] data;
        public static string id;
        public static List<string> schedlist;
        double interest = 0;
        double principal = 0;
        string fullname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PointF p1;
            PointF p2;
            Pen blackpen = new Pen(Color.Black, 2);
            if (qweqwe == 1)
            {
                nextpage(e);
                return;
            }
            if (page == 0)
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "Select LastName,FirstName,MiddleName,PhoneNumber from customerinfo where No = '" + id + "'";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                fullname = dt.Rows[0].ItemArray[0].ToString() + " " + dt.Rows[0].ItemArray[1].ToString() + " " + dt.Rows[0].ItemArray[2].ToString();
                e.Graphics.DrawString(id, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(30, 245));
                e.Graphics.DrawString(dt.Rows[0].ItemArray[0].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(170, 245));
                e.Graphics.DrawString(dt.Rows[0].ItemArray[1].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(310, 245));
                e.Graphics.DrawString(dt.Rows[0].ItemArray[2].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 245));
                e.Graphics.DrawString(dt.Rows[0].ItemArray[3].ToString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(610, 245));
                char a = '/';
                Assembly s = Assembly.GetExecutingAssembly();
                Stream ss = s.GetManifestResourceStream("Offline_lendingmanagementsystem_Its.grandeloan.jpg");
                Bitmap img1 = new Bitmap(ss);
                e.Graphics.DrawImage(img1, 250, -10, img1.Width, img1.Height);
                p1 = new PointF(30, 220);
                p2 = new PointF(810, 220);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = p2;
                p2 = new PointF(810, 270);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = p2;
                p2 = new PointF(30, p1.Y);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = p2;
                p2 = new PointF(p1.X, 220);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(170, 220);
                p2 = new PointF(p1.X, 270);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("CustomerID", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(30, 220));
                p1 = new PointF(310, 220);
                p2 = new PointF(p1.X, 270);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Lastname", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(170, 220));
                p1 = new PointF(450, 220);
                p2 = new PointF(p1.X, 270);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Firstname", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(310, 220));
                p1 = new PointF(610, 220);
                p2 = new PointF(p1.X, 270);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Middlename", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(450, 220));
                e.Graphics.DrawString("Contact Number", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(610, 220));
                p1 = new PointF(30, 270);
                p2 = new PointF(p1.X, 480);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(810, 270);
                p2 = new PointF(p1.X, 480);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(30, 480);
                p2 = new PointF(810, p1.Y);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(400, 293);
                p2 = new PointF(400, 480);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(30, 293);
                p2 = new PointF(810, 293);
                StringFormat sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                int point = 350;
                int point1 = 350 + 430;
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Account Information", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(318, 270));
                e.Graphics.DrawString("Acount No:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 300));
                e.Graphics.DrawString(data[0], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 300), sf);
                e.Graphics.DrawString("Type:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 325));
                e.Graphics.DrawString(data[1], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 325), sf);
                e.Graphics.DrawString("Borrow Money: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 350));
                e.Graphics.DrawString(data[2], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 350), sf);
                e.Graphics.DrawString("Interest Percentage:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 375));
                e.Graphics.DrawString(data[3], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 375), sf);
                e.Graphics.DrawString("Frequency: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 400));
                e.Graphics.DrawString(data[4], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 400), sf);
                e.Graphics.DrawString("Terms: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 425));
                e.Graphics.DrawString(data[5], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 425), sf);
                e.Graphics.DrawString("LendDate:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, 450));
                e.Graphics.DrawString(data[6], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point, 450), sf);
                e.Graphics.DrawString("Total Interest:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 300));
                e.Graphics.DrawString(data[7], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point1, 300), sf);
                e.Graphics.DrawString("Principal: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 325));
                e.Graphics.DrawString(data[8], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point1, 325), sf);
                e.Graphics.DrawString("Total Lend: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 350));
                e.Graphics.DrawString(data[9], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point1, 350), sf);

                if (data[1] == "Personal Loan")
                {
                    principal = Convert.ToDouble(data[10]);
                    interest = Convert.ToDouble(data[11]);
                    e.Graphics.DrawString("Monthly Payment: ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 375));
                    e.Graphics.DrawString((Convert.ToDouble(data[10]) + Convert.ToDouble(data[11])).ToString("n2"), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point1, 375), sf);
                    e.Graphics.DrawString("Monthly Interest:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 400));
                    e.Graphics.DrawString(data[11], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point1, 400), sf);
                }
                else
                {
                    principal = Convert.ToDouble(data[8]);
                    interest = Convert.ToDouble(data[7]);
                    e.Graphics.DrawString("Weekly Interest:", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(430, 370));
                    e.Graphics.DrawString(data[11], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(point1, 370), sf);
                }
                e.Graphics.DrawString("Borrower Payment Schedule", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(290, 480));
                p1 = new PointF(30, 505);
                p2 = new PointF(810, p1.Y);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Schedule", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 510));
                e.Graphics.DrawString("Principal", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 510));
                e.Graphics.DrawString("Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 510));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 510));
                p1 = new PointF(30, 530);
                p2 = new PointF(810, p1.Y);
                e.Graphics.DrawLine(blackpen, p1, p2);
                ebound = 720;
                y_axis = 535;
                y_axis1 = 480;
                bound = 815;
            }
            else
            {
                p1 = new PointF(30, 40);
                p2 = new PointF(810, 40);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Borrower Payment Schedule", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(290, 40));
                p1 = new PointF(30, 65);
                p2 = new PointF(810, p1.Y);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Schedule", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(120, 75));
                e.Graphics.DrawString("Principal", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(400, 75));
                e.Graphics.DrawString("Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, 75));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(700, 75));
                p1 = new PointF(30, 95);
                p2 = new PointF(810, p1.Y);
                e.Graphics.DrawLine(blackpen, p1, p2);
                ebound = 378;
                y_axis = 100;
                y_axis1 = 40;
                bound = 0;

            }
            int current = 0;
            length = schedlist.Count;
            Font f = new Font("Arial", 12, FontStyle.Regular);
            double total = interest + principal;
            for (; x < length; x++)
            {
                e.Graphics.DrawString(schedlist[x], f, Brushes.Black, new Point(60, y_axis + (25 * (refresh))));
                e.Graphics.DrawString(principal.ToString("n2"), f, Brushes.Black, new Point(400, y_axis + (25 * (refresh))));
                e.Graphics.DrawString(interest.ToString("n2"), f, Brushes.Black, new Point(550, y_axis + (25 * (refresh))));
                e.Graphics.DrawString(total.ToString("n2"), f, Brushes.Black, new Point(700, y_axis + (25 * (refresh))));
                refresh++;
                current += f.Height;
                if (current > e.PageBounds.Height - ebound)
                {
                    e.HasMorePages = true;
                    page++;
                    break;
                }
            }
            int y = y_axis + (25 * (refresh));
            p1 = new PointF(30, y);
            p2 = new PointF(810, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(810, y_axis1);
            p2 = new PointF(810, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(30, y_axis1);
            p2 = new PointF(30, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            refresh = 0;
            if (x == length && current <= e.PageBounds.Height - bound)
            {
                p1 = new PointF(30, y);
                p2 = new PointF(30, y + 150);
                e.Graphics.DrawLine(blackpen, p1, p2);//leftline
                p1 = new PointF(810, y);
                p2 = new PointF(810, y + 150);
                e.Graphics.DrawLine(blackpen, p1, p2);//rightline
                p1 = new PointF(30, y + 150);
                p2 = new PointF(810, y + 150);
                e.Graphics.DrawLine(blackpen, p1, p2);//bottomline
                StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
                StringFormat formatcenter = new StringFormat(formatleft);
                formatcenter.Alignment = StringAlignment.Center;
                string text = fullname;
                e.Graphics.DrawString(text, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(600, y + 50), formatcenter);
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, y + 70), formatcenter);
                e.Graphics.DrawString(Form1.user, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(200, y + 50), formatcenter);
                e.Graphics.DrawString("Proccess By", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, y + 70), formatcenter);
            }
            else if (x == length && current > e.PageBounds.Height - bound)
            {

                e.HasMorePages = true;
                qweqwe = 1;
            }
        

        }

        int qweqwe;
        public void nextpage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Pen blackpen = new Pen(Color.Black, 2);
            int y = 40;
            PointF p1, p2;
            p1 = new PointF(30, y);
            p2 = new PointF(30, y + 150);
            e.Graphics.DrawLine(blackpen, p1, p2);//leftline
            p1 = new PointF(810, y);
            p2 = new PointF(810, y + 150);
            e.Graphics.DrawLine(blackpen, p1, p2);//rightline
            p1 = new PointF(30, y + 150);
            p2 = new PointF(810, y + 150);
            e.Graphics.DrawLine(blackpen, p1, p2);//bottomline
            p1 = new PointF(30, y);
            p2 = new PointF(810, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//topline
            StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatcenter = new StringFormat(formatleft);
            formatcenter.Alignment = StringAlignment.Center;
            string text = fullname;
            e.Graphics.DrawString(text, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(600, y + 50), formatcenter);
            e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, y + 70), formatcenter);
            e.Graphics.DrawString(Form1.user, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(200, y + 50), formatcenter);
            e.Graphics.DrawString("Proccess By", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, y + 70), formatcenter);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void statementofact_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            page = 0;
            refresh = 0;
            x = 0;
            length = 0;
            bound = 0;
            ebound = 0;
            y_axis= 0;
            y_axis1 = 0;
            printDocument1.Print();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

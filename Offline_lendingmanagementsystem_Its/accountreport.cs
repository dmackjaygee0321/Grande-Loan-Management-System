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
    public partial class accountreport : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        
        public accountreport()
        {
            InitializeComponent();
        }

        int refresh;
        int x;
        int qwe;
        int page;
        int y_axis;
        int y_axisline;
        int ebound;
        int bound;
        int length;
        int lastpage_nextpage = 0;
        public static string [] accountinfo;
        public static string [,] data;
        public static int datalength;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            if (lastpage_nextpage == 1)
            {
                lastpage(e);
                return;
            }
            PointF p1;
            PointF p2;
            StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatcenter = new StringFormat(formatleft);
            formatcenter.Alignment = StringAlignment.Center;
            Font f = new Font("Arial", 12, FontStyle.Regular);
            Pen blackpen = new Pen(Color.Black, 2);
            if (page == 0)
            {
                char a = '/';
                Assembly s = Assembly.GetExecutingAssembly();
                Stream ss = s.GetManifestResourceStream("Offline_lendingmanagementsystem_Its.grandeloan.jpg");
                Bitmap img1 = new Bitmap(ss);
                e.Graphics.DrawImage(img1, 400, -25, img1.Width, img1.Height);
                e.Graphics.DrawString("Blk 7 Lot 39 Northridge Subdivision S.J.D.M Bulacan (09477856030)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 195), formatcenter);
                p1 = new PointF(30, 220);
                p2 = new PointF(1060, 220);
                e.Graphics.DrawLine(blackpen, p1, p2); //1line horizontal
                p1 = new PointF(30, 250);
                p2 = new PointF(1060, 250);
                e.Graphics.DrawLine(blackpen, p1, p2);//2line horizontal
                p1 = new PointF(30, 275);
                p2 = new PointF(1060, 275);
                e.Graphics.DrawLine(blackpen, p1, p2);//3line horizontal
                e.Graphics.DrawString(accountinfo[0], new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(470, 225));
                e.Graphics.DrawString("ID No.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(40, 255));
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 255));
                e.Graphics.DrawString("Principal", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 255));
                e.Graphics.DrawString("Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(650, 255));
                e.Graphics.DrawString("Penalty", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(820, 255));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(970, 255));
                y_axis = 285;
                y_axisline = 250;
                ebound = 500;
                bound = 660;
            }
            else
            {

                p1 = new PointF(30, 50);
                p2 = new PointF(1060, 50);
                e.Graphics.DrawLine(blackpen, p1, p2); //1line horizontal
                p1 = new PointF(30, 80);
                p2 = new PointF(1060, 80);
                e.Graphics.DrawLine(blackpen, p1, p2);//2line horizontal
                p1 = new PointF(30, 105);
                p2 = new PointF(1060, 105);
                e.Graphics.DrawLine(blackpen, p1, p2);//3line horizontal
                e.Graphics.DrawString(accountinfo[0], new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(480, 55));
                e.Graphics.DrawString("ID No.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(40, 85));
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 85));
                e.Graphics.DrawString("Principal", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(480, 85));
                e.Graphics.DrawString("Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(650, 85));
                e.Graphics.DrawString("Penalty", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(820, 85));
                e.Graphics.DrawString("Total", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(970, 85));
                y_axis = 115;
                y_axisline = 80;
                ebound = 350;
                bound = 527;
            }
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            length = datalength;
            int current = 0;
            for (; x < length; x++)
            {
                string text = string.Empty;
                e.Graphics.DrawString(data[x,0], f, Brushes.Black, new Point(40, y_axis + (refresh * 25)));
                e.Graphics.DrawString(text = data[x, 1], new Font("Arial", namesize(text.Length), FontStyle.Regular), Brushes.Black, new Point(115, y_axis + (refresh * 25)));
                e.Graphics.DrawString(text = data[x, 2], f, Brushes.Black, new Point(585, y_axis + (refresh * 25)), sf);
                e.Graphics.DrawString(text = data[x, 3], f, Brushes.Black, new Point(745, y_axis + (refresh * 25)), sf);
                e.Graphics.DrawString(text = data[x, 4], f, Brushes.Black, new Point(900, y_axis + (refresh * 25)), sf);
                e.Graphics.DrawString(text = data[x, 5], f, Brushes.Black, new Point(1050, qwe = (y_axis + (refresh * 25))), sf);
                current += f.Height;
                refresh++;
                if (current >= e.PageBounds.Height - ebound)
                {
                    e.HasMorePages = true;
                    refresh = 0;
                    page++;
                    break;
                }
            }
            /*
            for (; x < 13;x++ )
                e.Graphics.DrawString("Monthly Payment: ", f, Brushes.Black, new Point(430, y = 375+(x*25)));
            MessageBox.Show(x.ToString());
            PointF p1 = new PointF(30, y+50);
            PointF p2 = new PointF(810, y + 50);
            Pen blackpen = new Pen(Color.Black, 2);
            e.Graphics.DrawLine(blackpen, p1, p2);
             * */
            int y = qwe + 50;
            p1 = new PointF(30, y_axisline - 30);
            p2 = new PointF(30, y);
            e.Graphics.DrawLine(blackpen, p1, p2); //leftline
            p1 = new PointF(1060, y_axisline - 30);
            p2 = new PointF(1060, y);
            e.Graphics.DrawLine(blackpen, p1, p2); //rightline
            p1 = new PointF(100, y_axisline);
            p2 = new PointF(100, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//idline
            p1 = new PointF(450, y_axisline);
            p2 = new PointF(450, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//nameline
            p1 = new PointF(600, y_axisline);
            p2 = new PointF(600, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//principalline
            p1 = new PointF(780, y_axisline);
            p2 = new PointF(780, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//interestline
            p1 = new PointF(920, y_axisline);
            p2 = new PointF(920, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//penaltyline
            p1 = new PointF(30, y);
            p2 = new PointF(1060, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//penaltyline
            if (x == length && current <= e.PageBounds.Height - bound)
            {
                p1 = new PointF(30, y);
                p2 = new PointF(30, y + 265);
                e.Graphics.DrawLine(blackpen, p1, p2);//accountinfoleftline
                p1 = new PointF(1060, y);
                p2 = new PointF(1060, y + 265);
                e.Graphics.DrawLine(blackpen, p1, p2);//accountinforightline
                p1 = new PointF(30, y + 265);
                p2 = new PointF(1060, y + 265);
                e.Graphics.DrawLine(blackpen, p1, p2);//accountinfobottomline
                p1 = new PointF(30, y + 30);
                p2 = new PointF(1060, y + 30);
                e.Graphics.DrawLine(blackpen, p1, p2);//accountinfo2line
                p1 = new PointF(30, y + 55);
                p2 = new PointF(1060, y + 55);
                e.Graphics.DrawLine(blackpen, p1, p2);//accountinfo3line
                p1 = new PointF(560, y + 30);
                p2 = new PointF(560, y + 265);
                e.Graphics.DrawLine(blackpen, p1, p2);//accountinfocenterline
                e.Graphics.DrawString("Account Information", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(480, y + 5));
                e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 35));
                e.Graphics.DrawString("Details", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(800, y + 35));
                e.Graphics.DrawString("Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 90));
                e.Graphics.DrawString("Total Compound Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 115));
                e.Graphics.DrawString("Total Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 140));
                e.Graphics.DrawString("Total Principal", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 165));
                e.Graphics.DrawString("Total Amount Isued", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 190));
                e.Graphics.DrawString("Report by", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 215));
                e.Graphics.DrawString("Process Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 240));
                e.Graphics.DrawString(accountinfo[2], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(740, y + 90));
                e.Graphics.DrawString(accountinfo[3], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 115), sf);
                e.Graphics.DrawString(accountinfo[4], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 140), sf);
                e.Graphics.DrawString(accountinfo[5], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 165), sf);
                e.Graphics.DrawString(accountinfo[6], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 190), sf);
                e.Graphics.DrawString(Form1.user, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(740, y + 215));
                e.Graphics.DrawString(DateTime.Now.ToLongDateString(), new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(740, y + 240));

                if (accountinfo[0] != "Account Revenue")
                {
                    e.Graphics.DrawString("Emergency Loan", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(780, y + 65));
                    e.Graphics.DrawString(accountinfo[1], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 65));
                }
            }
            else if (x == length && current > e.PageBounds.Height - bound)
            {
                e.HasMorePages = true;
                lastpage_nextpage = 1;
            }
        }
        public void lastpage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            int y = 30;
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            PointF p1;
            PointF p2;
            Font f = new Font("Arial", 12, FontStyle.Regular);
            Pen blackpen = new Pen(Color.Black, 2);
            p1 = new PointF(30, y);
            p2 = new PointF(1060, y);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinfotopline
            p1 = new PointF(30, y);
            p2 = new PointF(30, y + 265);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinfoleftline
            p1 = new PointF(1060, y);
            p2 = new PointF(1060, y + 265);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinforightline
            p1 = new PointF(30, y + 265);
            p2 = new PointF(1060, y + 265);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinfobottomline
            p1 = new PointF(30, y + 30);
            p2 = new PointF(1060, y + 30);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinfo2line
            p1 = new PointF(30, y + 55);
            p2 = new PointF(1060, y + 55);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinfo3line
            p1 = new PointF(560, y + 30);
            p2 = new PointF(560, y + 265);
            e.Graphics.DrawLine(blackpen, p1, p2);//accountinfocenterline
            e.Graphics.DrawString("Account Information", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(480, y + 5));
            e.Graphics.DrawString("Description", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 35));
            e.Graphics.DrawString("Details", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(800, y + 35));
            e.Graphics.DrawString("Loan Type", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 65));
            e.Graphics.DrawString("Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 90));
            e.Graphics.DrawString("Total Compound Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 115));
            e.Graphics.DrawString("Total Interest", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 140));
            e.Graphics.DrawString("Total Principal", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 165));
            e.Graphics.DrawString("Total Amount Isued", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 190));
            e.Graphics.DrawString("Report by", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 215));
            e.Graphics.DrawString("Process Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, y + 240));
            e.Graphics.DrawString("12,10,2019 to 12-12-2019", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(740, y + 90));
            e.Graphics.DrawString("Emergency Loan", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(780, y + 65));
            e.Graphics.DrawString(accountinfo[2], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(740, y + 90));
            e.Graphics.DrawString(accountinfo[3], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 115), sf);
            e.Graphics.DrawString(accountinfo[4], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 140), sf);
            e.Graphics.DrawString(accountinfo[5], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 165), sf);
            e.Graphics.DrawString(accountinfo[6], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(900, y + 190), sf);
            e.Graphics.DrawString("Mack Jaygee Delos Santos Grande", new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(740, y + 215));
            e.Graphics.DrawString("Monday, September 10, 2019", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(740, y + 240));
        }
        public int namesize(int size)
        {
            double fontsize = 12;
            if (size > 36)
            {
                fontsize = fontsize - ((size - 36) * 0.3);
            }
            return Convert.ToInt32(fontsize);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            refresh = 0;
            x = 0;
            qwe = 0;
            page = 0;
            lastpage_nextpage = 0;
        

            PrintPreviewDialog d = new PrintPreviewDialog();
            printDocument1.DefaultPageSettings.Landscape = true;
            d.Document = printDocument1;
            ((Form)d).WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            d.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activity();
            refresh = 0;
            x = 0;
            qwe = 0;
            page = 0;
            lastpage_nextpage = 0;
            printDocument1.Print();
            this.Close();
        }
        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Print Account Reports','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

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
    public partial class BorrowerReport : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public BorrowerReport()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            page = 0;
            PrintPreviewDialog d = new PrintPreviewDialog();
            d.Document = printDocument1;
            ((Form)d).WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            d.ShowDialog();
            
        }

        public static string[,] data;
        public static int length;
        public static string type;

        int x = 0;
        int y = 0;
        int page = 0;
        int bound;
        int y_axis1;
        int y_axis;
        int ebound;
            StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatcenter;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            if (qweqwe == 1)
            {
                nextpage(e);
                return;
            }
            y = 0;
            Font f = new Font("Arial", 12, FontStyle.Regular);
            int current = 0;
            char a = '/';
            PointF p1;
            PointF p2;
            formatcenter = new StringFormat(formatleft);
            formatcenter.Alignment = StringAlignment.Center;
            Pen blackpen = new Pen(Color.Black, 2);
            if (page == 0)
            {
                Assembly s = Assembly.GetExecutingAssembly();
                Stream ss = s.GetManifestResourceStream("Offline_lendingmanagementsystem_Its.grandeloan.jpg");
                Bitmap img1 = new Bitmap(ss);
                e.Graphics.DrawImage(img1, 250, -25, img1.Width, img1.Height);
                e.Graphics.DrawString("Blk 7 Lot 39 Northridge Subdivision S.J.D.M Bulacan (09477856030)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(410, 195), formatcenter);
                p1 = new PointF(30, 230);
                p2 = new PointF(818, 230);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("Good Payer Borrowers", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(310, 235));
                p1 = new PointF(30, 260);
                p2 = new PointF(818, 260);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(30, 290);
                p2 = new PointF(818, 290);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("ID No.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 268));
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, 268));
                e.Graphics.DrawString("Customer Behavior", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 268));
                y_axis = 300;
                y_axis1 = 230;
                bound = 682;
                ebound = 630;
            }
            else
            {
                p1 = new PointF(30, 50);
                p2 = new PointF(818, 50);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString(type+" Borrowers", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(310, 55));
                p1 = new PointF(30, 80);
                p2 = new PointF(818, 80);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(30, 110);
                p2 = new PointF(818, 110);
                e.Graphics.DrawLine(blackpen, p1, p2);
                e.Graphics.DrawString("ID No.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(50, 86));
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, 86));
                e.Graphics.DrawString("Customer Behavior", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, 86));
                y_axis = 120;
                y_axis1 = 50;
                bound = 568;
                ebound = 511;
            }
            
            for (; x < length; x++)
            {

                e.Graphics.DrawString(data[x, 0], f, Brushes.Black, new Point(50, y_axis + (30 * (y))));
                e.Graphics.DrawString(data[x, 1], f, Brushes.Black, new Point(200, y_axis + (30 * (y))));
                if (type == "Good Payer")
                {
                    e.Graphics.DrawString(data[x, 2], f, Brushes.Blue, new Point(650, y_axis + (30 * (y))));
                }
                else
                {
                    e.Graphics.DrawString(data[x, 2], f, Brushes.Red, new Point(650, y_axis + (30 * (y))));
                }
                current += f.Height;
                y++;
                if (current > e.PageBounds.Height - ebound)
                {
                    e.HasMorePages = true;
                    page++;
                    break;
                }

            }
            y = y_axis + (30 * y);
            p1 = new PointF(150, (y_axis1 + 30));
            p2 = new PointF(150, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(550, (y_axis1 + 30));
            p2 = new PointF(550, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(30, y);
            p2 = new PointF(818, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(818, y_axis1);
            p2 = new PointF(818, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(30, y_axis1);
            p2 = new PointF(30, y);
            e.Graphics.DrawLine(blackpen, p1, p2);

            if (x == length && current <= e.PageBounds.Height - bound)
            {
                p1 = new PointF(30, y);
                p2 = new PointF(30, y + 120);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(818, y);
                p2 = new PointF(818, y + 120);
                e.Graphics.DrawLine(blackpen, p1, p2);
                p1 = new PointF(30, y + 120);
                p2 = new PointF(818, y + 120);
                e.Graphics.DrawLine(blackpen, p1, p2);
                string text = Form1.user;
                formatcenter.Alignment = StringAlignment.Center;
                e.Graphics.DrawString(text, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(600, y + 50), formatcenter);
                e.Graphics.DrawString("Printed By", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, y + 70), formatcenter);
                e.Graphics.DrawString(DateTime.Now.ToLongDateString(), new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(200, y + 50), formatcenter);
                e.Graphics.DrawString("Printed Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, y + 70), formatcenter);
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
            Font f = new Font("Arial", 12, FontStyle.Regular);
            PointF p1;
            PointF p2;
            y = 30;
            Pen blackpen = new Pen(Color.Black, 2);
            p1 = new PointF(30, y);
            p2 = new PointF(818, y);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(30, y);
            p2 = new PointF(30, y + 120);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(818, y);
            p2 = new PointF(818, y + 120);
            e.Graphics.DrawLine(blackpen, p1, p2);
            p1 = new PointF(30, y + 120);
            p2 = new PointF(818, y + 120);
            e.Graphics.DrawLine(blackpen, p1, p2);
            string text = Form1.user;
            e.Graphics.DrawString(text, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(600, y + 50), formatcenter);
            e.Graphics.DrawString("Printed By", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(600, y + 70), formatcenter);
            e.Graphics.DrawString(DateTime.Now.ToLongDateString(), new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(200, y + 50), formatcenter);
            e.Graphics.DrawString("Printed Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, y + 70), formatcenter);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activity();
            x = 0;
            y = 0;
            page = 0;
            printDocument1.Print();
            this.Close();
        }
        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Print Borrow Reports','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

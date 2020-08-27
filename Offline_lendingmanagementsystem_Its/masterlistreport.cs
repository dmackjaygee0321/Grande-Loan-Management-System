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
    public partial class masterlistreport : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public masterlistreport()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            current = 0;
            bound = 0;
            page = 0;
            y = 0;
            x = 0;


            PrintPreviewDialog d = new PrintPreviewDialog();
            printDocument1.DefaultPageSettings.Landscape = true;
            d.Document = printDocument1;
            ((Form)d).WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterParent;
            d.ShowDialog();
        }

        int current;
        int bound;
        int page;
        int y;
        int x = 0;
        int y_axis;
        int ebound;
        int qweqwe;
        public static string[,] data;
        public static int length;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatcenter = new StringFormat(formatleft);
            formatcenter.Alignment = StringAlignment.Center;
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            PointF p1;
            PointF p2;
            Font f = new Font("Arial", 12, FontStyle.Regular);
            Pen blackpen = new Pen(Color.Black, 2);
            e.HasMorePages = false;
            if (qweqwe == 1)
            {
                lastpage(e);
                return;
            }

            if (page == 0)
            {
                Assembly s = Assembly.GetExecutingAssembly();
                Stream ss = s.GetManifestResourceStream("Offline_lendingmanagementsystem_Its.grandeloan.jpg");
                Bitmap img1 = new Bitmap(ss);
                e.Graphics.DrawImage(img1, 400, -25, img1.Width, img1.Height);
                e.Graphics.DrawString("Blk 7 Lot 39 Northridge Subdivision S.J.D.M Bulacan (09477856030)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(580, 195), formatcenter);
                p1 = new PointF(30, 220);
                p2 = new PointF(1060, 220);
                e.Graphics.DrawLine(blackpen, p1, p2); //firstline
                p1 = new PointF(30, 250);
                p2 = new PointF(1060, 250);
                e.Graphics.DrawLine(blackpen, p1, p2); //2ndline
                p1 = new PointF(30, 220);
                p2 = new PointF(30, 275);
                e.Graphics.DrawLine(blackpen, p1, p2); //leftline
                p1 = new PointF(1060, 220);
                p2 = new PointF(1060, 275);
                e.Graphics.DrawLine(blackpen, p1, p2); //rightline
                p1 = new PointF(30, 275);
                p2 = new PointF(1060, 275);
                e.Graphics.DrawLine(blackpen, p1, p2); //3rdline
                e.Graphics.DrawString("Master List", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(500, 225));
                e.Graphics.DrawString("No "+length, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(40, 225));
                e.Graphics.DrawString("ID No.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(40, 255));
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, 255));
                e.Graphics.DrawString("Company Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(490, 255));
                e.Graphics.DrawString("Occupation", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(720, 255));
                e.Graphics.DrawString("Average Lend Amount", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(880, 255));
                y_axis = 280;
                bound = 520;
                ebound = 565;
            }
            else
            {
                p1 = new PointF(30, 25);
                p2 = new PointF(1060, 25);
                e.Graphics.DrawLine(blackpen, p1, p2); //1stline
                p1 = new PointF(30, 50);
                p2 = new PointF(1060, 50);
                e.Graphics.DrawLine(blackpen, p1, p2); //2ndline
                y_axis = 55;
                e.Graphics.DrawString("ID No.", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(40, 30));
                e.Graphics.DrawString("Borrower Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(220, 30));
                e.Graphics.DrawString("Company Name", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(490, 30));
                e.Graphics.DrawString("Occupation", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(720, 30));
                e.Graphics.DrawString("Average Lend Amount", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(880, 30));
                bound = 360;
                ebound = 413;
            }
            current = 0;
            y = 0;
            for (; x < length; x++)
            {
                e.Graphics.DrawString(data[x,0], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(40, y_axis + (30 * y)));
                e.Graphics.DrawString(data[x, 1], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, y_axis + (30 * y)), formatcenter);
                e.Graphics.DrawString(data[x, 2], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(550, y_axis + (30 * y)), formatcenter);
                e.Graphics.DrawString(data[x, 3], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(765, y_axis + (30 * y)), formatcenter);
                e.Graphics.DrawString(data[x, 4], new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(1030, y_axis + (30 * y)), sf);
                current += f.Height;
                y++;
                if (current >= e.PageBounds.Height - bound)
                {
                    x++;
                    page++;
                    e.HasMorePages = true;
                    break;
                }
            }
            int p = y_axis + (30 * y);
            p1 = new PointF(30, y_axis - 30);
            p2 = new PointF(30, p);
            e.Graphics.DrawLine(blackpen, p1, p2); //leftline
            p1 = new PointF(1060, y_axis - 30);
            p2 = new PointF(1060, p);
            e.Graphics.DrawLine(blackpen, p1, p2); //rightline
            p1 = new PointF(30, p);
            p2 = new PointF(1060, p);
            e.Graphics.DrawLine(blackpen, p1, p2); //lastline
            if (x == length && current <= e.PageBounds.Height - ebound)
            {
                p1 = new PointF(30, p);
                p2 = new PointF(30, p + 90);
                e.Graphics.DrawLine(blackpen, p1, p2); //leftline
                p1 = new PointF(1060, p);
                p2 = new PointF(1060, p + 90);
                e.Graphics.DrawLine(blackpen, p1, p2); //rightline
                p1 = new PointF(30, p + 90);
                p2 = new PointF(1060, p + 90);
                e.Graphics.DrawLine(blackpen, p1, p2); //lastline
                e.Graphics.DrawString(Form1.user, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(280, p + 25), formatcenter);
                e.Graphics.DrawString("Printed By", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, p + 45), formatcenter);
                e.Graphics.DrawString(DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToLongDateString(), new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(800, p + 25), formatcenter);
                e.Graphics.DrawString("Printed Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(800, p + 45), formatcenter);
            }
            else if (x == length && current > e.PageBounds.Height - ebound)
            {
                e.HasMorePages = true;
                qweqwe = 1;
            }
        
        }
        public void lastpage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            int p = 30;
            StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatcenter = new StringFormat(formatleft);
            formatcenter.Alignment = StringAlignment.Center;
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            PointF p1;
            PointF p2;
            Font f = new Font("Arial", 12, FontStyle.Regular);
            Pen blackpen = new Pen(Color.Black, 2);
            p1 = new PointF(30, p);
            p2 = new PointF(1060, p);
            e.Graphics.DrawLine(blackpen, p1, p2); //1stline
            p1 = new PointF(30, p);
            p2 = new PointF(30, p + 90);
            e.Graphics.DrawLine(blackpen, p1, p2); //leftline
            p1 = new PointF(1060, p);
            p2 = new PointF(1060, p + 90);
            e.Graphics.DrawLine(blackpen, p1, p2); //rightline
            p1 = new PointF(30, p + 90);
            p2 = new PointF(1060, p + 90);
            e.Graphics.DrawLine(blackpen, p1, p2); //lastline
            e.Graphics.DrawString(Form1.user, new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(280, p + 25), formatcenter);
            e.Graphics.DrawString("Printed By", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(280, p + 45), formatcenter);
            e.Graphics.DrawString(DateTime.Now.ToShortTimeString() + " " + DateTime.Now.ToLongDateString(), new Font("Arial", 12, FontStyle.Underline), Brushes.Black, new Point(800, p + 25), formatcenter);
            e.Graphics.DrawString("Printed Date", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(800, p + 45), formatcenter);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activity();
            current = 0;
            bound = 0;
            page = 0;
            y = 0;
            x = 0;
            y_axis = 0;
            ebound = 0;
            qweqwe = 0;
            printDocument1.Print();
            this.Close();
        }

        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Print Master List Reports','" + Form1.usertype + "','" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void masterlistreport_Load(object sender, EventArgs e)
        {

        }
    }
}

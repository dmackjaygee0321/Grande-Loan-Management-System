using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class reciept : Form
    {
        public reciept()
        {
            InitializeComponent();
        }
        public static string[] data;
        public static string[] sched;
        public static string[] bsched;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            StringFormat formatleft = new StringFormat(StringFormatFlags.NoClip);
            StringFormat formatcenter;
            formatcenter = new StringFormat(formatleft);
            formatcenter.Alignment = StringAlignment.Center;
            char a = '/';
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            Pen blackpen = new Pen(Color.Black, 2);
            Assembly s = Assembly.GetExecutingAssembly();
            Stream ss = s.GetManifestResourceStream("Offline_lendingmanagementsystem_Its.grandeloan.jpg");
            Bitmap img1 = new Bitmap(ss); ;
            e.Graphics.DrawImage(img1, 250, -25, img1.Width, img1.Height);
            e.Graphics.DrawString("Blk 7 Lot 39 Northridge Subdivision S.J.D.M Bulacan (09477856030)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(410, 195), formatcenter);

            e.Graphics.DrawString("Name: "+data[0], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, 235));
            e.Graphics.DrawString("Acount No.: " + data[1], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, 260));
            e.Graphics.DrawString("Payment Date: " + data[2], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(50, 285));
            e.Graphics.DrawString("Schedule: " + sched[0] + function(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, 235));
            if (sched.Length > 1)
            {
                //e.Graphics.DrawString(sched[1], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(600, 260));
            }
            PointF p1 = new PointF(30, 315);
            PointF p2 = new PointF(818, 315);
            e.Graphics.DrawLine(blackpen, p1, p2);//1stline
            p1 = new PointF(30, 340);
            p2 = new PointF(818, 340);
            e.Graphics.DrawLine(blackpen, p1, p2);//2ndline
            p1 = new PointF(30, 445);
            p2 = new PointF(818, 445);
            e.Graphics.DrawLine(blackpen, p1, p2);//3ndline
            p1 = new PointF(30, 475);
            p2 = new PointF(818, 475);
            e.Graphics.DrawLine(blackpen, p1, p2);//4thline
            p1 = new PointF(30, 315);
            p2 = new PointF(30, 475);
            e.Graphics.DrawLine(blackpen, p1, p2);//leftline
            p1 = new PointF(818, 315);
            p2 = new PointF(818, 475);
            e.Graphics.DrawLine(blackpen, p1, p2);//rightline
            e.Graphics.DrawString("Payment Description", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(80, 317));
            e.Graphics.DrawString("Amount", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(680, 317));
            e.Graphics.DrawString("Principal", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, 345));
            e.Graphics.DrawString("Interest", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, 370));
            e.Graphics.DrawString("Balance", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, 395));
            e.Graphics.DrawString("Penalty", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, 420));
            e.Graphics.DrawString("Total Payment", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(90, 450));
            e.Graphics.DrawString(data[3], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(770, 345), sf);
            e.Graphics.DrawString(data[4], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(770, 370), sf);
            e.Graphics.DrawString(data[5] + " " + balance(), new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(770, 395), sf);
            e.Graphics.DrawString(data[6], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(770, 420), sf);
            e.Graphics.DrawString(data[7], new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(770, 450), sf);


            e.Graphics.DrawString(data[0], new Font("Arial", 14, FontStyle.Underline), Brushes.Black, new Point(230, 495), formatcenter);
            e.Graphics.DrawString("Borrower", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(230, 515), formatcenter);

            e.Graphics.DrawString(Form1.user, new Font("Arial", 14, FontStyle.Underline), Brushes.Black, new Point(630, 495), formatcenter);
            e.Graphics.DrawString("Proccess By", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(630, 515), formatcenter);
        }
        public string function()
        {
            string t=string.Empty;
            if (sched.Length > 1)
            {
                t = " - "+sched[1];
            }
            return t;
        }
        public static int balancealert;
        public string balance()
        {
            string t=string.Empty;
            if(balancealert == 1)
            {
            t = "(" + bsched[0];
            if (bsched.Length > 1)
            {
                t += " - " + bsched[1];
            }
            t += ")";
            }
            return t;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            printDocument1.Print();
            this.Close();
        }
    }
}

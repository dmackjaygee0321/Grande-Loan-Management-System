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
    public partial class dialogsearch_bi : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public dialogsearch_bi()
        {
            InitializeComponent();
        }

        public void display()
        {
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "Select * from customerinfo where No like '%" + Borrowerinformation.search.Replace("'", "''") + "%' || concat (LastName,' ',FirstName,' ',MiddleName) like '%" + Borrowerinformation.search.Replace("'", "''") + "%'";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString() + " " + dt.Rows[x].ItemArray[2].ToString() + " " + dt.Rows[x].ItemArray[3].ToString());
            }

        }
        private void dialogsearch_bi_Load(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Borrowerinformation.id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }
    }
}

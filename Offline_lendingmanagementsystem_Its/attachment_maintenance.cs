﻿using System;
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
    public partial class attachment_maintenance : Form
    {
        OdbcConnection con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};SERVER=localhost;USER=root;PWD=sa;DB=its_lendingsystem");
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public attachment_maintenance()
        {
            InitializeComponent();
        }

        private void attachment_maintenance_Load(object sender, EventArgs e)
        {
            textBox1.ShortcutsEnabled = false;
            textBox2.ShortcutsEnabled = false;
            clear();
            display();
        }
        public void display()
        {
            dataGridView1.Rows.Clear();
            con.Open();
            DataTable dt = new DataTable();
            string strAcct = "select * from attachment_tbl";
            da = new OdbcDataAdapter(strAcct, con);
            da.Fill(dt);
            con.Close();
            for (int x = 0; x < dt.Rows.Count; x++)
            {
                dataGridView1.Rows.Add(dt.Rows[x].ItemArray[0].ToString(), dt.Rows[x].ItemArray[1].ToString(), dt.Rows[x].ItemArray[2].ToString());
            }
        }
        public void add()
        {
            con.Open();
            string strAdd = "Insert into attachment_tbl values(Null,'"+textBox1.Text+"','"+textBox2.Text+"')";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty)
            {
                con.Open();
                DataTable dt = new DataTable();
                string strAcct = "select * from attachment_tbl";
                da = new OdbcDataAdapter(strAcct, con);
                da.Fill(dt);
                con.Close();
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    if (textBox1.Text.ToLower().Trim() == dt.Rows[x].ItemArray[1].ToString().ToLower().Trim())
                    {
                        MessageBox.Show("type is already existed!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        break;
                    }
                    else if (x == dt.Rows.Count - 1)
                    {
                        add();
                        activity();
                        clear();
                        display();
                    }
                }
            }
            else
            {
                MessageBox.Show("Fill out all fields","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            attachment_updatedelte a = new attachment_updatedelte();
            attachment_updatedelte.id = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
            a.ShowDialog();
            if(a.DialogResult ==  DialogResult.OK)
            {
                display();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox1.Text);
            textBox1.Select(textBox1.Text.Length, 0);
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validation(e, sender, textBox1.Text);
        }
        public void validation(KeyPressEventArgs e, object sender, string text)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            if (!Char.IsLetter(ch) && ch != 8 && ch != 32 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 32)
            {
                if (cursorposition == 0)
                {
                    e.Handled = true;
                }
                if (text.Length > cursorposition)
                {
                    if (text[cursorposition - 1] == 32 || text[cursorposition] == 32)
                    {
                        e.Handled = true;

                    }
                }
                if (text.Length == 0)
                {
                    e.Handled = true;
                }
                else
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                    }
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(this.textBox2.Text);
            textBox2.Select(textBox2.Text.Length, 0);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            int cursorposition = (sender as TextBox).SelectionStart;
            string text = textBox2.Text;
            if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && ch != 8 && ch != 32 && ch != 127)
            {
                e.Handled = true;
            }
            if (ch == 32)
            {
                if (cursorposition == 0)
                {
                    e.Handled = true;
                }
                if (text.Length > cursorposition)
                {
                    if (text[cursorposition - 1] == 32 || text[cursorposition] == 32)
                    {
                        e.Handled = true;

                    }
                }
                if (text.Length == 0)
                {
                    e.Handled = true;
                }
                if (text.Length != 0)
                {
                    if (text[cursorposition - 1] == 32)
                    {
                        e.Handled = true;
                    }
                }
            }
        }
        public void activity()
        {
            con.Open();
            string strAdd = "Insert Into activitylog values(" + Form1.userid + ",'Add Attachment type','" + textBox1.Text.Trim() + "' ,'" + DateTime.Now.ToShortDateString() + "','" + DateTime.Now.ToShortTimeString() + "',null)";
            cmd = new OdbcCommand(strAdd, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

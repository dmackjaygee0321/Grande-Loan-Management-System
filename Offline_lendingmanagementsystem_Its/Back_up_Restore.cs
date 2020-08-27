using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Offline_lendingmanagementsystem_Its
{
    public partial class Back_up_Restore : Form
    {
        public Back_up_Restore()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox8.Text = dlg.SelectedPath;
                button2.Enabled = true;
                file = dlg.SelectedPath;
            }
        }

        private void Back_up_Restore_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
        }

        FolderBrowserDialog dlg1 = new FolderBrowserDialog();
        string file;
        private void button4_Click(object sender, EventArgs e)
        {
            opb1.Filter = "sql|*.sql";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                textBox1.Text = opb1.FileName.ToString(); 
                button3.Enabled = true;
                file = opb1.FileName.ToString(); 
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string constring = "server = localhost; user=root;password=sa;database=its_lendingsystem;charset=utf8";
                string file = this.file + "\\Backup_" + DateTime.Now.Year.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Day.ToString() + ".sql";
                MessageBox.Show(file);
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using(MySqlCommand cmd=new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ExportToFile(file);
                            conn.Close();
                            MessageBox.Show("Complete");
                        }
                    }
                }
                /*
                Server dbserver = new Server(new ServerConnection("localhost", "root", "sa"));
                Backup dbbackup = new Backup()
                {
                    Action = BackupActionType.Database,
                    Database = "mack"
                };
                dbbackup.Devices.AddDevice("@C:\\Users\\HP\\Desktop\\1\\qwezxczxc.bak",DeviceType.File);
                dbbackup.Initialize = true;
                dbbackup.SqlBackupAsync(dbserver);
                MessageBox.Show("Ok");
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                string constring = "server = localhost; user=root;password=sa;database=its_lendingsystem;charset=utf8";
                using (MySqlConnection conn = new MySqlConnection(constring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            mb.ImportFromFile(file);
                            conn.Close();
                            MessageBox.Show("Complete");
                        }
                    }
                }
                /*
                Server dbserver = new Server(new ServerConnection("localhost", "root", "sa"));
                Backup dbbackup = new Backup()
                {
                    Action = BackupActionType.Database,
                    Database = "mack"
                };
                dbbackup.Devices.AddDevice("@C:\\Users\\HP\\Desktop\\1\\qwezxczxc.bak",DeviceType.File);
                dbbackup.Initialize = true;
                dbbackup.SqlBackupAsync(dbserver);
                MessageBox.Show("Ok");
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

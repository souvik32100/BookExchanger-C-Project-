using BookExchanger.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookExchanger.UserInterFaces
{
    public partial class Notification : Form
    {
        int userId;
        public Notification(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            update();
        }

        BookRepo r = new BookRepo();

        public void update()
        {
            
            SqlDataReader sqlDataReader;
            sqlDataReader = r.showOfferedBooks(userId);
            while (sqlDataReader.Read())
            {
                ListViewItem item = new ListViewItem("" + (int)sqlDataReader.GetValue(1));
                item.SubItems.Add("" + (int)sqlDataReader.GetValue(3));
                item.SubItems.Add("" + (int)sqlDataReader.GetValue(2));
                listView1.Items.Add(item);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Search s = new Search(userId);
            //s.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(listView1.Items.Count>0)
            {
                r.accepted( int.Parse(listView1.SelectedItems[0].Text));
                MessageBox.Show("Done");
                Notification n = new Notification(userId);
                n.Show();
                this.Dispose();
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                r.rejected(int.Parse(listView1.SelectedItems[0].Text));
                MessageBox.Show("Rejected");
                Notification n = new Notification(userId);
                n.Show();
                this.Dispose();
               
                
            }
        }
    }
}

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
    public partial class Search : Form
    {
        int userId,point;
        UserRepo u = new UserRepo();
        BookRepo p = new BookRepo();
        public Search(int userId)
        {
            this.userId = userId;
            InitializeComponent();
            update();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            SqlDataReader sqlDataReader;
            sqlDataReader = p.searchBookInfo("" + textBox1.Text + "%");
            listView1.Items.Clear();
            if (sqlDataReader!=null) {
                
                while (sqlDataReader.Read())
                {
                  
                    ListViewItem item = new ListViewItem("" + (int)sqlDataReader.GetValue(0));
                    item.SubItems.Add("" + (string)sqlDataReader.GetValue(1));
                    item.SubItems.Add("" + (int)sqlDataReader.GetValue(6));
                    listView1.Items.Add(item);
                }
            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {

               
                BookFullDetails b = new BookFullDetails(userId,int.Parse(listView1.SelectedItems[0].Text));
                b.Show();
                this.Dispose();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SellBook s = new SellBook(this,userId);
            s.Show();
            //this.Hide();
        }
        public void update()
        {
            
            SqlDataReader sqlDataReader;
            sqlDataReader=p.showAllBooks();
            while(sqlDataReader.Read())
            {
                ListViewItem item = new ListViewItem(""+(int)sqlDataReader.GetValue(0));
                item.SubItems.Add(""+(string)sqlDataReader.GetValue(1));
                item.SubItems.Add("" + (int)sqlDataReader.GetValue(6));
                listView1.Items.Add(item);
            }
            point= u.userPoint(userId);
            label1.Text = "" + point;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
           
            update();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RequestBook r = new RequestBook(userId);
            r.Show();
            //this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RequestedBook r = new RequestedBook(userId);
            r.Show();
            //this.Dispose();
        }

        private void btnNotify_Click(object sender, EventArgs e)
        {
            Notification n = new Notification(userId);
            n.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CheckOut c = new CheckOut(userId,point);
            c.Show();
            //this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Profile p = new Profile(this,userId);
            p.Show();
            //this.Dispose();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

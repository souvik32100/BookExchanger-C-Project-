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
    public partial class CheckOut : Form
    {
        int sellerId;
        int totalPoint=0;
        int pointS;
        BookRepo r = new BookRepo();
        UserRepo u = new UserRepo();
        int userId,point;
        public CheckOut(int userId,int point)
        {
            this.userId = userId;
            this.point = point;
            InitializeComponent();
            update();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            r.checkOut(userId);

            u.updatePoint(userId,(point-totalPoint));
            int x = u.userPoint(sellerId);
            u.updatePoint(sellerId,(x+pointS));
            this.Dispose();
            CheckOut c = new CheckOut(userId,point);
            c.Show();
            this.Hide();
        }

        private void CheckOut_Load(object sender, EventArgs e)
        {
            

        }
        public void update()
        {

            SqlDataReader sqlDataReader;
            sqlDataReader = r.showConfirmedBooks(userId);
            while (sqlDataReader.Read())
            {
                String s = r.bookName((int)sqlDataReader.GetValue(1));
                ListViewItem item = new ListViewItem(s);
                sellerId = (int)sqlDataReader.GetValue(4);
                s = u.userName(sellerId);
                item.SubItems.Add(s );
                pointS = (int)sqlDataReader.GetValue(2);
                item.SubItems.Add("" + (int)sqlDataReader.GetValue(2));

                if((int)sqlDataReader.GetValue(5)==1)
                {
                    item.SubItems.Add("Confirmed");
                    totalPoint = totalPoint + (int)sqlDataReader.GetValue(2);
                }
                if ((int)sqlDataReader.GetValue(5) == 2)
                {
                    item.SubItems.Add("Pending Delevery");
                }
                if ((int)sqlDataReader.GetValue(5) == 3)
                {
                    item.SubItems.Add("Rejected");
                }
                if ((int)sqlDataReader.GetValue(5) == 4)
                {
                    item.SubItems.Add("Delevered");
                }

                listView1.Items.Add(item);
            }

            
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            //Search s = new Search(userId);
            //s.Show();
            this.Hide();
        }
    }
}

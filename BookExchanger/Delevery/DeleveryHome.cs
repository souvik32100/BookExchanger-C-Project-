using BookExchanger.Admin;
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

namespace BookExchanger.Delevery
{
    public partial class DeleveryHome : Form
    {
        BookRepo r = new BookRepo();
        UserRepo u = new UserRepo();
        public DeleveryHome()
        {
            InitializeComponent();
            update();
        }
        public void update()
        {

            SqlDataReader sqlDataReader;
            sqlDataReader = r.showPendingdBooks();
            while (sqlDataReader.Read())
            {
                ListViewItem item = new ListViewItem("" + (int)sqlDataReader.GetValue(1));

                string adress = u.userAdress((int)sqlDataReader.GetValue(4));
                item.SubItems.Add(adress );
                adress = u.userAdress((int)sqlDataReader.GetValue(3));
                item.SubItems.Add(adress);

                
                listView1.Items.Add(item);
            }


        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                r.delever(int.Parse(listView1.SelectedItems[0].Text));
                MessageBox.Show("Done");
                
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            //AdminHome a = new AdminHome();
            //a.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleveryHome_Load(object sender, EventArgs e)
        {

        }
    }
}

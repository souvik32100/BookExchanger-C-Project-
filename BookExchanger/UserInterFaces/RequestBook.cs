using BookExchanger.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookExchanger.UserInterFaces
{
    public partial class RequestBook : Form
    {
        int userID;
        public RequestBook(int userID)
        {
            this.userID = userID;
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Search s = new Search(userID);
            //s.Show();
            this.Hide();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            BookRepo r = new BookRepo();
            r.insertRequestBook(txtTitle.Text,txtAuthor.Text,int.Parse(TxtPoint.Text),userID);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class Profile : Form
    {
        int userId;
        UserRepo r=new UserRepo();
        Form f;
        public Profile(Form f,int userId)
        {
            this.f = f;
            this.userId = userId;
            InitializeComponent();
            update();
        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }
        public void update()
        {
            SqlDataReader sqlDataReader;
            sqlDataReader = r.userInfo(userId);
            while (sqlDataReader.Read())
            {
                
                txtName.Text= (string)sqlDataReader.GetValue(2);
                txtAdress.Text= (string)sqlDataReader.GetValue(5);
                txtMail.Text = (string)sqlDataReader.GetValue(3);
                txtPhone.Text = ""+(int)sqlDataReader.GetValue(4);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Search s = new Search(userId);
            //s.Show();
            this.Hide();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            r.updateUser(userId, txtName.Text, int.Parse(txtPhone.Text), txtAdress.Text, txtMail.Text);
            MessageBox.Show(this, "Change Done");
            this.Hide();
        }

        private void btnCngPass_Click(object sender, EventArgs e)
        {
            ChangePassword c = new ChangePassword(f,this,userId);
            c.Show();
            this.Hide();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

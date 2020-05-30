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
    public partial class ChangePassword : Form
    {
        int userId;
        UserRepo r = new UserRepo();
        Profile p;
        Form f;
        public ChangePassword(Form f,Profile p,int userId)
        {
            this.f = f;
            this.userId = userId;
            this.p = p;
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string pass = r.passInfo(userId);
            Console.WriteLine(pass);
            if(textBox1.Text==pass)
            {
                if(textBox2.Text==textBox3.Text)
                {
                    r.updatePass(userId, textBox3.Text);
                    MessageBox.Show(this, "Sucsess");
                    Login l = new Login();
                    l.Show();
                    this.Hide();
                    f.Dispose();
                }
                else
                {
                    MessageBox.Show(this, "Password Not match");
                }
            }
            else
            {
                MessageBox.Show(this,"Wrong Old Password");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            p.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}

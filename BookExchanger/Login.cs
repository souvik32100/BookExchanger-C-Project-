using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookExchanger.Admin;
using BookExchanger.Repository;
using BookExchanger.UserInterFaces;

namespace BookExchanger
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserRepo c = new UserRepo();
                if (txtId.Text == "a" && txtPass.Text == "a")
                {
                    AdminHome a = new AdminHome();
                    a.Show();
                    this.Hide();
                }
                else
                {
                    int x = c.checkLogin(int.Parse(txtId.Text), txtPass.Text);
                    if (x != 0)
                    {
                        Search s = new Search(x);
                        s.Show();
                        this.Hide();
                    }
                    if (x == 0)
                    {
                        MessageBox.Show("INVALID ID OR PASSWORD");
                    }
                    else { }
                }
            }
            catch(Exception exc)
            {
                MessageBox.Show("INVALID ID OR PASSWORD");

            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp(this);
            signUp.Show();
            this.Hide();
        }

        private void userLabel_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

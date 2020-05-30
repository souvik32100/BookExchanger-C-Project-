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
    public partial class SignUp : Form
    {
        Login l;
        public SignUp(Login l)
        {
            this.l = l;
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            l.Show();
            this.Hide();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            l.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ConfirmSign c = new ConfirmSign(this,txtName.Text,txtAdress.Text,txtEmail.Text,txtId.Text,txtPass.Text,txtPhone.Text,textBox4.Text);
            c.Show();
        }
    }
}

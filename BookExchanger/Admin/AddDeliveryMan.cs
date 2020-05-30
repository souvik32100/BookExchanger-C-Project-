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

namespace BookExchanger.Admin
{
    public partial class AddDeliveryMan : Form
    {
        public AddDeliveryMan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleverRepo d = new DeleverRepo();
            if (txtPass.Text == textBox4.Text)
            {
                d.insertDetails(txtId.Text, txtPass.Text, txtName.Text, txtEmail.Text, txtPhone.Text, txtAdress.Text);
                MessageBox.Show("Done");

                AdminHome ah = new AdminHome();
                ah.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password Does not Match");
            }
        }

        private void txtAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AdminHome ah = new AdminHome();
            //ah.Show();
            this.Hide();

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void AddDeliveryMan_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}

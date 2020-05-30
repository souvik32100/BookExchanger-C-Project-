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
    public partial class ConfirmSign : Form
    {
        string txtName, txtAdress, txtEmail, txtId, txtPass, txtPhone, textBox4;

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }

        Form f;

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepo r = new UserRepo();
            if (txtPass == textBox4)
            {
                r.insertUserDetails(txtId, txtPass, txtName, txtEmail, txtPhone, txtAdress);
                MessageBox.Show("Done\nPlease Login to continue");
                this.Dispose();
                Login l = new Login();
                l.Show();
                f.Dispose();
                
            }
            else
            {
                MessageBox.Show("Password Does not Match");
            }

        }

        public ConfirmSign(Form f,string txtName,string txtAdress,string txtEmail,string txtId,string txtPass,string txtPhone,string textBox4)
        {
            this.f = f;
            this.txtAdress = txtAdress;
            this.txtEmail = txtEmail;
            this.txtId = txtId;
            this.txtName = txtName;
            this.txtPass = txtPass;
            this.txtPhone = txtPhone;
            this.textBox4 = textBox4;
            InitializeComponent();
            update();
        }

        private void ConfirmSign_Load(object sender, EventArgs e)
        {

        }
        public void update()
        {
            label1.Text = txtName;
            label2.Text = txtId;
            label3.Text = txtEmail;
            label4.Text = txtPhone;
        }
    }
}

using BookExchanger.Delevery;
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
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TotalBookInformation t = new TotalBookInformation();
            t.Show();
            //this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDeliveryMan a = new AddDeliveryMan();
            a.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowDeleveryMan s = new ShowDeleveryMan();
            s.Show();
            //this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleveryHome d = new DeleveryHome();
            d.Show();
            //this.Hide();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login l=new Login();
            l.Show();
            this.Hide();
        }

        private void AdminHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

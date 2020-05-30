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
    public partial class TotalBookInformation : Form
    {
        public TotalBookInformation()
        {
            InitializeComponent();
            update();
        }
        public void update()
        {
            BookRepo b = new BookRepo();
            dataGridView1.DataSource=b.info();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AdminHome ah = new AdminHome();
            //ah.Show();
            this.Hide();
        }
    }
}

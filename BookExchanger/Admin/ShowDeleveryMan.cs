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
    public partial class ShowDeleveryMan : Form
    {
        public ShowDeleveryMan()
        {
            InitializeComponent();
            update();
        }
        public void update()
        {
            DeleverRepo b = new DeleverRepo();
            dataGridView1.DataSource = b.info();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AdminHome ah = new AdminHome();
            //ah.Show();
            this.Hide();

        }
    }
}

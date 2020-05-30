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
    public partial class SellBook : Form
    {
        string fileName;
        string fileLoc;
        int userId;
        Form f;
        public SellBook(Form f,int userId)
        {
            this.userId = userId;
            this.f = f;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookRepo b = new BookRepo();
            b.insertBookDetails(fileName,fileLoc,txtTitle.Text,txtEdition.Text,int.Parse(txtDate.Text),userId,txtAuthor.Text,int.Parse(txtPoints.Text));
            MessageBox.Show("Done");
            f.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        OpenFileDialog ofd = new OpenFileDialog();
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                fileName = ofd.SafeFileName;
                fileLoc = ofd.FileName;
                this.pictureBox1.ImageLocation = fileLoc;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // f.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

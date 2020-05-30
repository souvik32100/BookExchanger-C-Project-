﻿using BookExchanger.Repository;
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
    public partial class RequestedBook : Form
    {
        int userID;
        public RequestedBook(int userID)
        {
            this.userID = userID;
            InitializeComponent();
            update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search s = new Search(userID);
            //s.Show();
            this.Hide();
        }
        public void update()
        {
            BookRepo p = new BookRepo();
            SqlDataReader sqlDataReader;
            sqlDataReader = p.showAllReqBooks();
            while (sqlDataReader.Read())
            {
                ListViewItem item = new ListViewItem((string)sqlDataReader.GetValue(1));
                item.SubItems.Add("" + (int)sqlDataReader.GetValue(3));
                item.SubItems.Add("" + (string)sqlDataReader.GetValue(2));
                listView1.Items.Add(item);
            }
        }
    }
}

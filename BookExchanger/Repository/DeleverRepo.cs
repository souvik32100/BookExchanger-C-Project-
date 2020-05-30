using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookExchanger.Repository
{
    class DeleverRepo
    {
        public void insertDetails(string id, string password, string name, string email, string phone, string adress)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlCommand cd1;


                cnn.Open();

                string sql1 = string.Format("INSERT INTO login(userid,password,type) VALUES('{0}','{1}','{2}')", id, password, 1);
                string sql2 = string.Format("INSERT INTO DeleveryManDetail(userid,name,email,phone,adress) VALUES('{0}','{1}','{2}','{3}','{4}')", id, name, email, phone, adress);
                cd = new SqlCommand(sql1, cnn);
                int rows = -1;
                rows = cd.ExecuteNonQuery();
                cd1 = new SqlCommand(sql2, cnn);
                int rows2 = -1;
                rows2 = cd1.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }
        public DataTable info()
        {

            DataTable dt = new DataTable();
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);



                cnn.Open();

                string sql = "Select * from DeleveryManDetail";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, cnn);
                sqlDataAdapter.Fill(dt);




            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return dt;
        }
    }
}

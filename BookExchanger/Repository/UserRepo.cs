using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BookExchanger.Repository
{
    class UserRepo
    {
        public int checkLogin(int userId,string password)
        {
            int s=0;
            string pass;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlDataReader sqlDataReader;
                
                cnn.Open();

                string sql = "Select * from login where userId='"+userId+"' and password='"+password+"'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    s = (int)sqlDataReader.GetValue(1);
                    pass = (string)sqlDataReader.GetValue(2);
                    
                    Console.WriteLine("" + s + "" + pass);
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return s;
        }

        public void insertUserDetails(string id,string password,string name,string email,string phone,string adress)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlCommand cd1;


                cnn.Open();

                string sql1 = string.Format("INSERT INTO login(userid,password,type) VALUES('{0}','{1}','{2}')", id,password, 0); 
                string sql2 = string.Format("INSERT INTO UserDetails(userid,name,email,phone,adress,point) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", id,name, email,phone,adress,100);
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
        public SqlDataReader userInfo(int userID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from userDetails where userId='"+userID+"'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public void updateUser(int userId,string name,int phone,string adress,string mail)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql1 = "Update userDetails set name='"+name+"',phone="+phone+",email='"+mail+"',adress='"+adress+"' where userId='" + userId + "'";
                

                cd = new SqlCommand(sql1, cnn);
                int rows = -1;
                rows = cd.ExecuteNonQuery();
                

                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }
        public string passInfo(int userID)
        {
            SqlDataReader sqlDataReader = null;
            string pass = "";
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from login where userId='" + userID + "'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    pass = (string)sqlDataReader.GetValue(2);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return pass;
        }
        public void updatePass(int userId, string pass)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql1 = "Update login set password='" + pass + "' where userId='" + userId + "'";


                cd = new SqlCommand(sql1, cnn);
                int rows = -1;
                rows = cd.ExecuteNonQuery();


                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }
        public void updatePoint(int userId,int totalpoint)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql1 = "Update userdetails set point=" + totalpoint + " where userId='" + userId + "'";


                cd = new SqlCommand(sql1, cnn);
                int rows = -1;
                rows = cd.ExecuteNonQuery();


                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
        }
        public int userPoint(int userID)
        {
            int x = 0;
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from UserDetails where userId='"+ userID + "'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    x = (int)sqlDataReader.GetValue(6);
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return x;
        }


        public string userName(int userId)
        {
            SqlDataReader sqlDataReader = null;
            string userName = "";
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql = "Select * from userDetails where userid='" + userId + "'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    userName = (string)sqlDataReader.GetValue(2);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return userName;

        }

        public string userAdress(int userId)
        {
            SqlDataReader sqlDataReader = null;
            string userAdress = "";
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql = "Select * from userDetails where userid='" + userId + "'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    userAdress = (string)sqlDataReader.GetValue(5);
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return userAdress;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookExchanger.Repository
{
    class BookRepo
    {
        public void insertBookDetails(string photoName,string photoLoc,string title,string edition,int uDate,int userId,string author,int point )
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                SqlCommand cd1;


                cnn.Open();

                string sql1 = string.Format("INSERT INTO BookPhoto(PhotoName,photoLoc,userId) VALUES('{0}','{1}','{2}')", photoName, photoLoc, userId);
                string sql2 = string.Format("INSERT INTO BookDetails(title,Edition,UsedDate,UserId,Author,Point,status) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", title, edition, uDate, userId, author, point, 0);
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

        public SqlDataReader showAllBooks()
        {
            SqlDataReader sqlDataReader=null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                

                cnn.Open();

                string sql = "Select * from BookDetails where status=0";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                
                
            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public SqlDataReader showBookInfo(int bookid)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from BookDetails where id='"+bookid+"'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public SqlDataReader showBookPic(int bookid)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from BookPhoto where id='" + bookid + "'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public void insertRequestBook(string title,string author,int point,int userId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
                


                cnn.Open();

                string sql1 = string.Format("INSERT INTO RequestBook(title,author,point,userId) VALUES('{0}','{1}','{2}','{3}')", title, author, point, userId);
               
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
        public SqlDataReader showAllReqBooks()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from RequestBook";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }

        public void sellPosting(int BookId,int offeredPoint,int BuyerId,int SellerId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql1 = string.Format("INSERT INTO SellPosting(BookId,offeredPoint,BuyerId,SellerId,Status) VALUES('{0}','{1}','{2}','{3}','{4}')", BookId, offeredPoint, BuyerId, SellerId,0);

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

        public SqlDataReader showOfferedBooks(int userId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from sellPosting where sellerId='"+userId+"' and status=0";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public void accepted(int bookId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd,cd1;



                cnn.Open();

                string sql1 = "Update sellPosting set status=1 where bookId='" + bookId + "'";
                string sql2 = "Update BookDetails set status=1 where Id='" + bookId + "'";

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


        public SqlDataReader showConfirmedBooks(int userId)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from sellPosting where buyerId='" + userId + "' and (status=1 or status=2 or status=3 or status=4)";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }

        public void checkOut(int userId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql1 = "Update sellPosting set status=2 where buyerId='" + userId + "' and status=1";
               

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
        public void rejected(int bookId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd, cd1;



                cnn.Open();

                string sql1 = "Update sellPosting set status=3 where bookId='" + bookId + "'";
                string sql2 = "Update BookDetails set status=0 where Id='" + bookId + "'";

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


        public SqlDataReader searchBookInfo(string bookName)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;
               


                cnn.Open();

                string sql = "Select * from BookDetails where title LIKE '"+bookName+"' and status=0";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public DataTable info()
        {
            
            DataTable dt = new DataTable();
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
               


                cnn.Open();

                string sql = "Select * from BookDetails";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql,cnn);
                sqlDataAdapter.Fill(dt);




            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return dt;
        }
        public SqlDataReader showPendingdBooks()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;


                cnn.Open();

                string sql = "Select * from sellPosting where status=2";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();


            }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return sqlDataReader;
        }
        public void delever(int bookId)
        {
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql1 = "Update sellPosting set status=4 where bookId='" + bookId + "'";
                

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
        public string bookName(int bookId)
        {
            SqlDataReader sqlDataReader = null;
            string bookName = "";
            try
            {
                string connection = "Data Source=DESKTOP-CHSIH61;Initial Catalog=BookExchanger;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connection);
                SqlCommand cd;



                cnn.Open();

                string sql = "Select * from BookDetails where id='"+bookId+"'";
                cd = new SqlCommand(sql, cnn);
                sqlDataReader = cd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    bookName = (string)sqlDataReader.GetValue(1);
                }


                }
            catch (Exception e)
            {
                Console.WriteLine("" + e.Message);
            }
            return bookName;

        }



    }
}

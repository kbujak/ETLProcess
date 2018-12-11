using ETL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Process.Helpers.Database
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=SSPI;AttachDBFilename=C:\\Projekty\\ETL_Proces\\ETL_Process\\Model\\DB\\ETLdb.mdf"; //change string for your own xD

        public static bool saveBeersToDB(IList<Beer> beerList)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);

            cmd.Connection = conn;

            try
            {
                conn.Open();
                foreach (var beer in beerList)
                {
                    cmd.CommandText = "INSERT INTO Beer Values('" + beer.Name + "','" + beer.Type
                        + "'," + beer.Percentages + "," + beer.Blg + ",'" + beer.Country + "',"
                        + beer.Rating + ",'" + beer.Url + "','" + beer.BeerHash + "')";
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public static bool saveCommentsToDatabase(CommentResult commentResult)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            cmd.Connection = conn;

            try
            {
                conn.Open();
                foreach (var userComment in commentResult.UserComments)
                {
                    //to remove after fixing comment parsing

                    if (!(userComment.Opinion == null) &&
                        userComment.Opinion.Contains('\''))
                    {
                        userComment.Opinion = userComment.Opinion.Substring(0, userComment.Opinion.IndexOf("'") - 1);
                    }

                    var date = DateTime.Parse(userComment.Date).Date.ToString("yyyy-MM-dd HH:mm:ss");
                    if(userComment.Rating == null)
                    {
                        userComment.Rating = 0;
                    }

                    cmd.CommandText = "INSERT INTO UserComment Values('" + userComment.Username  + "','" + userComment.Rating
                        + "','" + date + "','" + userComment.Opinion + "','" + userComment.BeerHash + "')";
                    cmd.ExecuteNonQuery();
                }

                foreach (var guestComment in commentResult.GuestComments)
                {
                    //to remove after fixing comment parsing
                    if (!(guestComment.Opinion == null) &&
                        guestComment.Opinion.Contains('\''))
                    {
                        guestComment.Opinion = guestComment.Opinion.Substring(0, guestComment.Opinion.IndexOf("'") - 1);
                    }

                    var date = DateTime.Parse(guestComment.Date).Date.ToString("yyyy-MM-dd HH:mm:ss");

                    cmd.CommandText = "INSERT INTO GuestComment Values('" + date + "','" + guestComment.Opinion
                        + "','" + guestComment.BeerHash + "')";
                    cmd.ExecuteNonQuery();
                }


                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return true;
        }

        public static void ClearDB()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connectionString);
            cmd.Connection = conn;

            try
            {
                cmd.CommandText = "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL' GO" +
                    "EXEC sp_MSForEachTable 'DELETE FROM ?'GO";
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

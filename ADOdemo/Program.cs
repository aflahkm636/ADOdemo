using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;

class Program

{
    static void Main(string[] args)
    {
        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True;";
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string insertQuery = "insert into students(Name,Age)values('asdsrttxx',17)";
            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} rows updated");
            }
        }
        using (SqlConnection conn = new SqlConnection(connStr))
        {
           
            
                conn.Open();
                string updatequery = "update students set age=20 where StudentId=1006 ";
                using (SqlCommand cmd=new SqlCommand(updatequery, conn))
            {
                int rowsAffected = cmd.ExecuteNonQuery(); Console.WriteLine($"{rowsAffected} rows affected");
            }

            
        }
        using (SqlConnection conn = new SqlConnection(connStr))
        {

            conn.Open();
            Console.WriteLine("connection open");
            string query = "select * from students";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Name:{reader.GetString(1)},Age:{reader.GetInt32(2)}");

                    }
                }
            }
        }
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            Console.WriteLine("coonection open");
            string deletequery = "delete from students where StudentId=1007";
            using(SqlCommand cmd=new SqlCommand(deletequery,conn))
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} {deletequery}");
            }

        }
       

       
    }
}
using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

class Program

{
    [Obsolete]
    static void Main(string[] args)
    {
        //string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True;";
        //using (SqlConnection conn = new SqlConnection(connStr))
        //{
        //    conn.Open();
        //    string insertQuery = "insert into students(Name,Age)values('asdsrttxx',17)";
        //    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
        //    {
        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        Console.WriteLine($"{rowsAffected} rows updated");
        //    }
        //}
        //using (SqlConnection conn = new SqlConnection(connStr))
        //{


        //        conn.Open();
        //        string updatequery = "update students set age=20 where StudentId=1006 ";
        //        using (SqlCommand cmd=new SqlCommand(updatequery, conn))
        //    {
        //        int rowsAffected = cmd.ExecuteNonQuery(); Console.WriteLine($"{rowsAffected} rows affected");
        //    }


        //}
        //using (SqlConnection conn = new SqlConnection(connStr))
        //{

        //    conn.Open();
        //    Console.WriteLine("connection open");
        //    string query = "select * from students";

        //    using (SqlCommand cmd = new SqlCommand(query, conn))
        //    {
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Console.WriteLine($"Name:{reader.GetString(1)},Age:{reader.GetInt32(2)}");

        //            }
        //        }
        //    }
        //}
        //using (SqlConnection conn = new SqlConnection(connStr))
        //{
        //    conn.Open();
        //    Console.WriteLine("coonection open");
        //    string deletequery = "delete from students where StudentId=1007";
        //    using(SqlCommand cmd=new SqlCommand(deletequery,conn))
        //    {
        //        int rowsAffected = cmd.ExecuteNonQuery();
        //        Console.WriteLine($"{rowsAffected} {deletequery}");
        //    }

        //}

        ///day2

        string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True;";
        using(SqlConnection conn =new SqlConnection(connStr))
        {
            conn.Open();

            SqlDataAdapter adapter = new SqlDataAdapter("select * from students",conn);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet,"students");


            //DataRow newrow = dataSet.Tables["students"].NewRow();
            //newrow["name"] = "allli";
            //newrow["Age"] = 35;
            //dataSet.Tables["students"].Rows.Add(newrow);

            //DataRow uprow = dataSet.Tables["students"].Rows[0];
            //uprow["age"] = 11;

            DataTable dt = dataSet.Tables["students"];
            DataView veiw = new DataView(dt);
            veiw.RowFilter = "Age>20";
          foreach(DataRowView row in veiw)
            {
                Console.WriteLine($"name:{row["Name"]},Age:{row["Age"]}");

            }

            //foreach (DataRow row in dataSet.Tables["students"].Rows)
            //{
            //    Console.WriteLine($"name:{row["Name"]},Age:{row["Age"]}");
            //}

            //DataRow deleterow = dataSet.Tables["students"].Rows[6];
            //deleterow.Delete();
            adapter.Update(dataSet, "students");

        }


    }
}
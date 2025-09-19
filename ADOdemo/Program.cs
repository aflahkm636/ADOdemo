using System;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;

class Program

{

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

        //string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SchoolDB;Integrated Security=True;";
        //using(SqlConnection conn =new SqlConnection(connStr))
        //{
        //    conn.Open();

        //    SqlDataAdapter adapter = new SqlDataAdapter("select * from students",conn);

        //    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

        //    DataSet dataSet = new DataSet();
        //    adapter.Fill(dataSet,"students");


        //DataRow newrow = dataSet.Tables["students"].NewRow();
        //newrow["name"] = "allli";
        //newrow["Age"] = 35;
        //dataSet.Tables["students"].Rows.Add(newrow);

        //DataRow uprow = dataSet.Tables["students"].Rows[0];
        //uprow["age"] = 11;

        //  DataTable dt = dataSet.Tables["students"];
        //  DataView veiw = new DataView(dt);
        //  veiw.RowFilter = "Age>20";
        //foreach(DataRowView row in veiw)
        //  {
        //      Console.WriteLine($"name:{row["Name"]},Age:{row["Age"]}");

        //  }

        //foreach (DataRow row in dataSet.Tables["students"].Rows)
        //{
        //    Console.WriteLine($"name:{row["Name"]},Age:{row["Age"]}");
        //}

        //DataRow deleterow = dataSet.Tables["students"].Rows[6];
        //deleterow.Delete();
        //adapter.Update(dataSet, "students");


        //day3

        string connstr = @"Data Source=(localdb)\MSSQLLocalDB ;Initial Catalog= SchoolDB ;Integrated security = True;";

        //using (SqlConnection conn = new SqlConnection(connstr))
        //{
           
        //    SqlCommand cmd = new SqlCommand("GetStudentById", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@StudentId" ,1);

        //    conn.Open();

        //    using (SqlDataReader reader = cmd.ExecuteReader()) {
        //        while (reader.Read())
        //        {
        //            Console.WriteLine($"name:{reader["Name"]},Age:{reader["Age"]}");
        //        }
        //    }
        //}

        //using(SqlConnection conn =new SqlConnection(connstr))
        //{
        //    SqlCommand cmd=new SqlCommand("AddStudent",conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Name", "qwerty");
        //    cmd.Parameters.AddWithValue("@Age", 32);
        //    cmd.Parameters.AddWithValue("@DOB", "2002-1-12");
        //    cmd.Parameters.AddWithValue("@Grade", "A");


        //    conn.Open();

        //    int rowsAffected=cmd.ExecuteNonQuery();
        //    Console.WriteLine($"{rowsAffected} rows inserted");

        //}

        //using (SqlConnection conn = new SqlConnection(connstr)) 
        //{
        //    SqlCommand updateCmd = new SqlCommand("UpdateAge", conn);
        //    updateCmd.CommandType = CommandType.StoredProcedure;
        //    updateCmd.Parameters.AddWithValue("@StudentId",4);
        //    updateCmd.Parameters.AddWithValue("@Age", 22);

        //    conn.Open( );

        //    int rowsAffected=updateCmd.ExecuteNonQuery();
        //    Console.WriteLine($"{rowsAffected} reos updated");
        //}

        //using (SqlConnection conn = new SqlConnection(connstr)) 
        //{
        //    SqlCommand deletecmd = new SqlCommand("deleteStudent", conn);
        //    deletecmd.CommandType = CommandType.StoredProcedure;
        //    deletecmd.Parameters.AddWithValue("@studentId", 3);

        //    conn.Open( );

        //    int rowsAffected=deletecmd.ExecuteNonQuery();
        //    Console.WriteLine($"{rowsAffected} rows deleted");
        //}


        using(SqlConnection conn =new SqlConnection(connstr))
        {
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                SqlCommand insertcmd = new SqlCommand("insert into students(Name,Age,DOB,Grade) values(@Name,@Age,@DOB,@Grade)",
                    conn, transaction);
                insertcmd.Parameters.AddWithValue("@Name", "ZXCVB");
                insertcmd.Parameters.AddWithValue("@Age ", 20);
                insertcmd.Parameters.AddWithValue("@DOB","2003-3-21");
                insertcmd.Parameters.AddWithValue("@Grade", "B");
                insertcmd.ExecuteNonQuery();
               
                SqlCommand updatecmd = new SqlCommand("update students set Name=@Name,Age=@Age where StudentId=@StudentId", conn, transaction);
                updatecmd.Parameters.AddWithValue("@StudentId", 1);
                updatecmd.Parameters.AddWithValue("@Name", "FASi");
                updatecmd.Parameters.AddWithValue("@Age", 2);
                updatecmd.ExecuteNonQuery();

                transaction.Commit();
                Console.WriteLine("transaction commited");
                
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("transaction rooled back.error:"+ex.Message);
            }
        }

    }
    }


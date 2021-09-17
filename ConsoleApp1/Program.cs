using System;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        public static SqlConnection con;
        public static SqlCommand cmd;

        static void main(string[] args)
        {
            //InsertData();
            //UpdateData();
            //DeleteData();
            //SelectData();
            DisconnectSelect();
        }

        private static void SelectData()
        {
            SqlConnection con = getCon();
            SqlCommand cmd = new SqlCommand("Select * from employee");
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Console.WriteLine(dr[i]);
                }
            }
        }

        private static void DisconnectSelect()
        {
            con = getCon();
            cmd = new SqlCommand("select * from employee");
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            foreach(DataRow dr in dt.Rows)
            {
                foreach(var item in dr.ItemArray)
                {
                    Console.Write(item + "    ");
                }
                Console.WriteLine();
            }

        }

        private static SqlConnection getCon()
        {
            SqlConnection con = new SqlConnection("Data Source=CIWE-MTP-SQL1;Initial Catalog=EDS; Integrated Security=true");
            con.Open();
            return con;
        }

        private static void InsertData()
        {
            con = getCon();
            Console.WriteLine("Enter Empid,Empname,Salary,Doj,Type,Deptid,Mgr");
            int eid = Convert.ToInt32(Console.ReadLine());
            string Empname = Console.ReadLine();
            float sal = float.Parse(Console.ReadLine());
            DateTime doj = Convert.ToDateTime(Console.ReadLine());
            bool etype = Convert.ToBoolean(Console.ReadLine());

            cmd = new SqlCommand("insert into employee values(@employeeID, @employeeName, @salary, @doj, @employeeType)");

            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@employeeID", eid);
            cmd.Parameters.AddWithValue("@employeeName", Empname);
            cmd.Parameters.AddWithValue("@salary", sal);
            cmd.Parameters.AddWithValue("@doj", doj);
            cmd.Parameters.AddWithValue("@employeeType", etype);

            cmd.ExecuteNonQuery();
        }
        private static void UpdateData()
        {
            con = getCon();
            Console.WriteLine("Enter Empid,Empname");
            int eid = Convert.ToInt32(Console.ReadLine());
            string Empname = Console.ReadLine();
            cmd = new SqlCommand("update employee set employeeName = @employeeName where employeeID = @employeeID");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@employeeID", eid);
            cmd.Parameters.AddWithValue("@employeeName", Empname);
            cmd.ExecuteNonQuery();
        }

        private static void DeleteData()
        {
            con = getCon();
            Console.WriteLine("Enter Empid");
            int eid = Convert.ToInt32(Console.ReadLine());
            cmd = new SqlCommand("delete from employee where employeeID = @employeeID");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@employeeID", eid);
            cmd.ExecuteNonQuery();
        }

    }
}

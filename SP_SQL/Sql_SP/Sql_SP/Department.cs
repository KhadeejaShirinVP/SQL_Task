using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_SP
{
    public class Department : Employee
    {
        SqlConnection sqlConnection;
        private string connectionString = @"Data Source=.;Initial Catalog=task1;Integrated Security=True";


        //insert deparment details
        public void InsertDepartment(int DepID, string DepName)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string insertQuery = "exec InsertDep '" + DepID + "'," + DepName + ";";
                SqlCommand EXECCommand = new SqlCommand(insertQuery, sqlConnection);
                EXECCommand.ExecuteNonQuery();
                Console.WriteLine("Insert Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //update of department details
        public void UpdateForDepartment(int DepID, string DepName)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string updateQuery = "EXEC UpdateDepartment " + DepID + ",'" + DepName + "';";
                SqlCommand EXECCommand = new SqlCommand(updateQuery, sqlConnection);
                EXECCommand.ExecuteNonQuery();
                Console.WriteLine("Update Successfully");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}

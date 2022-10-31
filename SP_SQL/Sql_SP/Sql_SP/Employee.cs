using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_SP
{
    public class Employee
    {

        SqlConnection sqlConnection;
        private string connectionString = @"Data Source=.;Initial Catalog=task1;Integrated Security=True";

        //insetEmployee
        public void InsertEmployee(int EmpID,string EmpName, int EmpAge, int SalaryID, int DepID)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
               
                string insertQuery = "exec InsertData '" + EmpID + "'," + EmpName + "," + EmpAge + "," + SalaryID + "," + DepID + ";";
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

        //display details of employee
        public void DisplayForEmployeeDetails()
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string displayQuery = "select * from GetEmplyeeDetails;";
                SqlCommand EXECCommand = new SqlCommand(displayQuery, sqlConnection);
                EXECCommand.ExecuteNonQuery();
                SqlDataReader dataReaders = EXECCommand.ExecuteReader();
                while (dataReaders.Read())
                {
                    Console.WriteLine("EmpName: " + dataReaders.GetValue(0).ToString());
                    Console.WriteLine("DepName: " + dataReaders.GetValue(1).ToString());
                    Console.WriteLine("SalaryAmt: " + dataReaders.GetValue(2).ToString());
                }

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

        //update employee Details
        public void UpdateForEmployee(int EmpID, string EmpName)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string updateQuery = "EXEC UpdateEmployee " + EmpID + ",'" + EmpName + "';";
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

        //delete employee details
        public void DeleteForEmployee(int EmpID)
        {
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                string deleteQuery = "EXEC DeleteDetails " + EmpID + ";";
                SqlCommand EXECCommand = new SqlCommand(deleteQuery, sqlConnection);
                EXECCommand.ExecuteNonQuery();
                Console.WriteLine("Delete Successfully");

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

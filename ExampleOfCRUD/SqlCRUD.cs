using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;
using System.Security.Cryptography.X509Certificates;

namespace ExampleOfCRUD
{
    internal class SqlCRUD
    {
        private SqlConnection sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=ConnectionProject;Integrated Security=True");
        public DataTable GetEngineers()
        {
            DataSet dataset = new DataSet();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "select * from Engineers";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataset, "Engineers");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                sqlConnection.Close();
            }
            return dataset.Tables["Engineers"];
        }

        //Get by using Data reader //Read
        public void GetEngineersUsingreader()
        {

            SqlDataReader sqlDataReader;
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "select * from Engineers";
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {


                    Console.WriteLine("Engineers ID: " + sqlDataReader.GetValue(0) + "\nEngineers name: " + sqlDataReader.GetValue(1));

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public void CreateEngineers()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                Console.WriteLine("\nenter Engineer name\n");
                string engineerName = Console.ReadLine();
                Console.WriteLine("\nenter Engineer age\n");
                int age = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("\nenter departmentid\n");
                //int departmentId = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("\nenter employee salaryid\n");
                //int salaryid = Convert.ToInt32(Console.ReadLine());

                sqlCommand.CommandText = "insert into Engineer values ('" + engineerName + "'," + age +")";
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //update
        public void UpdateEngineers()
        {

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                Console.WriteLine("\nenter Engineer id to update\n");
                int engineerId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\nenter engineer age \n");
                int engAge = Convert.ToInt32(Console.ReadLine());

                sqlCommand.CommandText = "update engineer set empage =" + engAge + " where engid=" + engineerId;

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        //Delete
        public void DeleteEngineer()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                Console.WriteLine("\nenter engineer id to delete\n");
                int engineerId = Convert.ToInt32(Console.ReadLine());
                sqlCommand.CommandText = "delete from engineer where empid=" + engineerId;

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;       //for connection sql

namespace CrudApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string connectionString = @"Data Source=.;Initial Catalog=ConnectionProject;Integrated Security=True";
            SqlConnection sqlConnection= new SqlConnection(connectionString);
            sqlConnection.Open();
            // Data Source is server name ' . '
            //ConnectionProject is DB name
            try 
            {  
                Console.WriteLine("Connection established successfully..");
                string input;

                do
                {

                        Console.WriteLine("Select from the options below..\n1.CREATION \n2.RETRIEVE \n3.UPDATE \n4.DELETE");
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:

                                // CREATE path in CRED operation
                                Console.WriteLine("Enter your Name");
                                string EngineerName = Console.ReadLine();
                                Console.WriteLine("Enter your Age");
                                int EngineerAge = int.Parse(Console.ReadLine());

                                string insertQuery = "INSERT INTO Engineers(Eng_Name,Eng_Age) VALUES('" + EngineerName + "'," + EngineerAge + ")";
                                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
                                insertCommand.ExecuteNonQuery();
                                Console.WriteLine("Data is Successfully inserted into Table");
                                break;


                            case 2:
                                //RETRIEVE IN CRED OPERATION
                                string displayQuery = "SELECT * FROM Engineers";
                                SqlCommand displayCommand = new SqlCommand(displayQuery, sqlConnection);
                                SqlDataReader dataReader = displayCommand.ExecuteReader();
                                while (dataReader.Read())     //read one data at a time from the table when we read the data
                                {
                                    Console.WriteLine("Id: " + dataReader.GetValue(0).ToString());
                                    Console.WriteLine("Name: " + dataReader.GetValue(1).ToString());
                                    Console.WriteLine("Age: " + dataReader.GetValue(2).ToString());
                                }
                                dataReader.Close();
                                break;

                            case 3:
                                //UPDATE IN CRED OPERATION
                                int u_Id;
                                int u_Age;
                                Console.WriteLine("Enter the Engineer ID that you would like to update");
                                u_Id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter the Age of the Engineer to update");
                                u_Age = int.Parse(Console.ReadLine());
                                string updateQuery = "UPDATE Engineers SET Eng_Age= " + u_Age + "WHERE Eng_ID= " + u_Id + "";
                                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
                                updateCommand.ExecuteNonQuery();
                                Console.WriteLine("Data updated Successfully");
                                break;

                            case 4:
                                //DELETE IN CRED OPERATION
                                int d_Id;
                                Console.WriteLine("Enter the ID of the record that is to be Deleted");
                                d_Id = int.Parse(Console.ReadLine());
                                string deleteQuery = "DELETE FROM Engineers WHERE Eng_ID= " + d_Id;
                                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                                deleteCommand.ExecuteNonQuery();
                                Console.WriteLine("Delete successfully..");
                                break;

                            default:
                                Console.WriteLine("Invalid input");
                                break;
                        }
                        Console.WriteLine("Do you want to continue?");
                        input = Console.ReadLine();
                }
                while (input != "no");
                
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

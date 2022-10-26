using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExampleOfCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SqlCRUD sql_CRUD= new SqlCRUD();

            DataTable dt = sql_CRUD.GetEngineers();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine("Engineers ID: " + dr[0].ToString() + " Engineers name: " + dr[1].ToString());
            //}
            sql_CRUD.CreateEngineers();
            sql_CRUD.UpdateEngineers();
            sql_CRUD.DeleteEngineer();
        }
    }
}

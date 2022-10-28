using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sql_SP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee sp=new Employee();
            //sp.InsertEmployee(106, "shyam", 31, 212, 3);
            sp.DisplayForEmployeeDetails();
            //sp.UpdateForEmployee(105,"Mallika");
            //sp.DeleteForEmployee(105);
        }
    }
}

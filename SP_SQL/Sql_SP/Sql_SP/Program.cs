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
            Employee emp=new Employee();
            //emp.InsertEmployee(106, "shyam", 31, 212, 3);
            emp.DisplayForEmployeeDetails();
            //emp.UpdateForEmployee(105,"Mallika");
            //emp.DeleteForEmployee(105);


            //Department dep=new Department();
            // dep.InsertDepartment(7, "abcdef");
            //dep.DisplayForEmployeeDetails();
            //dep.UpdateForDepartment(7, "fdstdgj");


            // Salary sal=new Salary();
            // sal.InsertSalaryDetails(216, 564327);
            //sal.DisplayForEmployeeDetails();
            // sal.UpdateForSalary(215, 234987);



        }
    }
}

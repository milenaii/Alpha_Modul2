using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee
    {
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public List<Employee> Employees
        {
            get
            {
                return EmployeesList;
            }
        }

        public void isEmployeeOf(Employee e)
        {
            EmployeesList.Add(e);
        }

        List<Employee> EmployeesList = new List<Employee>();

        public override string ToString()
        {
            return Name;
        }
    }
}

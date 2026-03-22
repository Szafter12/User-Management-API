using System;
using System.Collections.Generic;

namespace User_Management_API.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}

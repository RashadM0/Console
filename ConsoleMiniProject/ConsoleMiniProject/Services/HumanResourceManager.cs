using System;
using System.Collections.Generic;
using System.Text;
using ConsoleMiniProject.Interfaces;
using ConsoleMiniProject.Models;
using System.Linq;
using ConsoleMiniProject.Enums;

namespace ConsoleMiniProject.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        private Department[] _departments;

        public Department[] Departments
        {
            get
            {
                return _departments;
            }
        }
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }

        #region Department
        public void AddDepartment(string name, double salaryLimit, int workerLimit)
        {
            Department department = new Department(name , salaryLimit , workerLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
               Console.WriteLine("\n\n***************************************\n\nDepartment successfully added!\n");
        }
        public void EditDepartments(string name, string newDepartmentName)
        {
            Department department = Departments.First(department => name == department.Name);
            if (department != null)
            {
                department.Name = newDepartmentName;
            }
            else
                Console.WriteLine("Not Such Department Found!");
        }

        public Department[] GetDepartments()
        {
            return Departments;
        }
        #endregion

        #region Employee
        public void AddEmployee(Employee employee, Employee[] employees, Department department)

        {
            Array.Resize(ref department.Employees, department.Employees.Length + 1);
            department.Employees[department.Employees.Length - 1] = employee;

            Console.WriteLine("Employee successfully added!");
        }

        public void DeleteEmployee(string departmentName, string id)
        {
            Department department = null;

            foreach (Department item in Departments)
            {
                if (item.Name.ToLower() == departmentName.ToLower())
                {
                    department = item;
                    break;
                }
            }

            Employee employee = null;

            if (department != null)
            {
                foreach (Employee item in department.Employees)
                {
                    if (item.Id.ToLower() == id.ToLower())
                    {
                        employee = item;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Employee is not exist!");
                return;
            }

        }

        public void EditEmployee( string id, double salary, Positions positions)
        {
            foreach (var item in _departments)
            {
                foreach (var item1 in item.Employees)
                {
                    if (item1.Id == id)
                    {
                        Console.WriteLine("Employee Detected: ");
                        Console.WriteLine($"{item1.FullName} {item1.Salary} {item1.Position}");
                    }
                }
            }
        }

        #endregion
    }

}

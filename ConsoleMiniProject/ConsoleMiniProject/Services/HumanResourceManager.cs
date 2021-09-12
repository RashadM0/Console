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
        public Department[] Departments => _departments;
        public HumanResourceManager()
        {
            _departments = new Department[0];
        }
        //Department services
        #region Department
        //Method for create new department
        public void AddDepartment(string name, double salaryLimit, int workerLimit)
        {
            Department department = new Department(name , salaryLimit , workerLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
               Console.WriteLine("\n\n***************************************\n\nDepartment successfully added!\n");
        }
        //Method for make change on departments
        public void EditDepartments(string oldDepartmentname, string newDepartmentName)
        {
            foreach (Department item in Departments)
            {
                item.Name = newDepartmentName;
                //Console.WriteLine("\n\n***************************************\n\nDepartment successfully edited!\n");
                return;
            }

            //Department department = Departments.First(department => oldDepartmentname == department.Name);
            //if (department != null)
            //    department.Name = newDepartmentName;
            //else
            //    Console.WriteLine("Not Such Department Found!");
        }
        //Method for print departments
        public Department[] GetDepartments(Department[] departments)
        {
            return departments;
        }
        //Method for print informations department 
        public void InfoDepartment()
        {
            Console.Clear();
            if (Departments.Length == 0)
                Console.WriteLine("\nNo Such Department Found\n\n***************************************\n");
            else
            {
                foreach (var item in Departments)
                {
                    for (int i = 0; i < Departments.Length; i++)
                    {
                        if (item.Employees == null)
                            i++;
                        else
                        {
                            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                                $"\nDepartment Name: {item.Name}" +
                                "\n++++++++++++++++++++++++++++++++++++++" +
                                $"\nNumber of Workers: {item.Employees.Length}" +
                                "\n++++++++++++++++++++++++++++++++++++++" +
                                $"\nAverage Salary: {item.CalcSalaryAverage()}" +
                                "\n======================================\n");
                            break;
                        }
                    }
                }
            }
        }
        #endregion
        //Employee servicess
        #region Employee
        //Method for print employees in department array
        //public void ShowEmployeeOfDepartment(Employee[] employees)
        //{
        //        Console.Write("Enter the Department Name: ");
        //        string departmentName = Console.ReadLine();

        //        foreach (var item in Departments)
        //        {
        //            if (item.Name == departmentName)
        //            {
        //                for (int i = 0; i < item.Employees.Length; i++)
        //                {
        //                    foreach (var item1 in item.Employees)
        //                    {
        //                        if (item1.FullName != null)
        //                        {
        //                            Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
        //                        $"\nEmployee ID: {item1.Id}" +
        //                        "\n++++++++++++++++++++++++++++++++++++++" +
        //                        $"\nFull Name of Employee: {item1.FullName}" +
        //                        "\n++++++++++++++++++++++++++++++++++++++" +
        //                        $"\nPosition of Employee: {item1.Positions}" +
        //                        "\n++++++++++++++++++++++++++++++++++++++" +
        //                        $"\nSalary of Employee: {item1.Salary}" +
        //                        "\n======================================\n");
        //                            break;
        //                        }
        //                        else
        //                            i++;
        //                    }
        //                }
        //            }
        //        }
        //}
        //Mehtod for print employees 
        public void ShowEmployees(Employee[] employees)
        {
            Console.Clear();
            foreach (var item in Departments)
            {
                foreach (var item1 in item.Employees)
                {
                    if (item1 != null) 
                    {
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                        $"\nEmployee Id: {item1.Id}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nFull Name of Employee: {item1.FullName}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nPosition of Employee: {item1.Positions}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nDepartment Name: {item1.DepartmentName}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\nSalary of Employee: {item1.Salary}\n\n");
                    }                    
                }
            }
            //if (employees.Length == 0)
            //    Console.WriteLine("\nNo Such Employee Found\n\n***************************************\n");
            //else
            //{
            //    foreach (var item in Departments)
            //    {
            //        foreach (var item1 in item.Employees)
            //        {
            //            if (item1 != null)
            //            {
            //                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
            //                $"\nEmployee Id: {item1.Id}" +
            //                "\n++++++++++++++++++++++++++++++++++++++" +
            //                $"\nFull Name of Employee: {item1.FullName}" +
            //                "\n++++++++++++++++++++++++++++++++++++++" +
            //                $"\nPosition of Employee: {item1.Positions}" +
            //                "\n++++++++++++++++++++++++++++++++++++++" +
            //                $"\nDepartment Name: {item1.DepartmentName}" +
            //                "\n++++++++++++++++++++++++++++++++++++++" +
            //                $"\nSalary of Employee: {item1.Salary}\n\n");
            //            }
            //        }
            //    }
            //}        
        }
        //Method for create new employee
        public void AddEmployee(string fullName, Positions positions, double salary, int index)
        {
            Department department = _departments[index];
            if (department.WorkerLimit > department.Employees.Length)
            {
                if (department.SalaryLimit > salary)
                {
                    Employee employee = new Employee(fullName, salary, department, positions);
                    department.AddEmployee(employee);
                    Console.WriteLine("\n\n***************************************\n\nEmployee successfully added!\n");
                    return;
                }
                else
                {
                    Console.WriteLine("You have exceeded the salary limit. Please try again: ");
                    return;
                }
            }
            else
            {
                Console.WriteLine("You have exceeded the worker limit. Please try again: ");
                return;
            }
        }
        //Method for remove employee from department
        public void DeleteEmployee(string dName, string idEmp/*, string eName*/)
        {
            string addIndex = null;
            Department department = null;
            foreach (Department item in _departments)
            {
                if (item.Name.ToLower() == dName.ToLower())
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
                    if (item.Id.ToLower() == idEmp.ToLower())
                    {
                        employee = item;
                        Console.WriteLine("\nEmployee Detected: ");
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.FullName}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.Salary}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.Positions}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item.Id}\n\n");
                        Console.Write("If you want delete, PRESS any key: ");
                        Console.ReadLine();
                        break;
                    }
                }
            }
            else
                Console.WriteLine("Employee is not exist!");
            if (employee != null)
            {
                foreach (var item in department.Employees)
                {
                        int index = Array.IndexOf(department.Employees, employee);
                    if (item.Id.ToLower() == idEmp.ToLower())
                    {
                        Array.Clear(department.Employees, index, 1);
                        Console.WriteLine("\n\n***************************************\n\nEmployee Successfully Deleted!\n");
                        for (int i = 0; i < department.Employees.Length; i++)
                        {
                            if (department.Employees[i] != null)
                            {
                                continue;
                            }
                            for (int j = 0; j < department.Employees.Length; j++)
                            {
                                if (department.Employees[i] == null)
                                {
                                    continue;
                                    department.Employees[i] = department.Employees[j];
                                    department.Employees[j] = null;
                                    break;
                                }
                            }
                        }
                        //for (int i = 0; i < department.Employees.Length; i++)
                        //{
                        //    addIndex = item.Id;
                        //    i++;

                        //    Array.Resize(ref department.Employees, department.Employees.Length - 1);
                        //    department.Employees[department.Employees.Length - 1] = employee;
                        //    break;
                        //}



                        //Array.Clear(department.Employees, index, 1);
                        //Console.WriteLine("\n\n***************************************\n\nEmployee Successfully Deleted!\n");
                    }
                    
                    //for (int i = 0; i < department.Employees.Length; i++)
                    //{
                    //    if (department.Employees[i] == null)
                    //    {
                    //        //Array.Copy(null,);


                    //        Array.Resize(ref department.Employees, department.Employees.Length - 1);
                    //        department.Employees[department.Employees.Length - 1] = null;
                    //    }
                    //}
                }
            }
            else
                Console.WriteLine("Employee is not exist!");
        }
        //Method for make change on employees
        public void EditEmployee( string id, double salary, Positions positions)
        {
            //foreach (var item in _departments)
            //{
            //    foreach (var item1 in item.Employees)
            //    {
            //        if (item1.Id == id)
            //        {
            //            Console.WriteLine("Employee Detected: ");
            //            Console.WriteLine($"{item1.FullName} {item1.Salary} {item1.Positions}");
            //        }
            //    }
            //}
        }
        #endregion
    }

}

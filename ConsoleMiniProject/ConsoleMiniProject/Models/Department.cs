using System;
using System.Collections.Generic;
using System.Text;
using ConsoleMiniProject.Interfaces;
using ConsoleMiniProject.Services;

namespace ConsoleMiniProject.Models 
{
    class Department
    {
        private int _WorkerLimit;
        private string _Name;
        private double _SalaryLimit;
        public static int count = 0;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (value.Trim().Length >= 2)
                    _Name = value;
            }
        }
        public int WorkerLimit
        {
            get
            {
                return _WorkerLimit;
            }
            set
            {

                if (value >= 1)
                    _WorkerLimit = value;
                else
                   Console.WriteLine("Invalid Worker Limit! Limit has to set to 1");
            }
        }
        public double SalaryLimit
        {
            get
            {
                return _SalaryLimit;
            }
            set
            {
                if (value >= 250)
                    _SalaryLimit = value;
                else
                    Console.WriteLine("Invalid Salary Limit! Limit has to set to 250");
            }
        }
        public Employee[] Employees = new Employee[0];


        public Department(string name, double salaryLimit, int workerLimit)
        {
            Name = name;
            SalaryLimit = salaryLimit;
            WorkerLimit = workerLimit;
        }
        //Method for resize Employee array
        public void AddEmployee(Employee employee)
        {
            Array.Resize(ref Employees, Employees.Length + 1);
            Employees[Employees.Length - 1] = employee;
        }
        //Method for calculate employee salary average 
        public double CalcSalaryAverage()
        {
            double SalaryAverage = 0;
            foreach (Employee item in Employees)
            {
                if (item != null)
                {
                    SalaryAverage += item.Salary;
                }

            }
            return SalaryAverage = SalaryAverage / Employees.Length;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ConsoleMiniProject.Models;
using ConsoleMiniProject.Services;
using ConsoleMiniProject.Enums;

namespace ConsoleMiniProject.Interfaces
{
    interface IHumanResourceManager
    {
        //Departments array
        Department[] Departments { get; }
        //Method for print departments
        Department[] GetDepartments(Department[] departments);
        //Method for create new department
        void AddDepartment(string name, double salaryLimit, int workerLimit);
        //Method for make change on departments 
        void EditDepartments(string name, string NewDepartmentName);
        //Method for create new employee
        void AddEmployee(string fullName, Positions positions, double salary, int index);
        //Method for remove employee from departments
        void DeleteEmployee(string dName, string idEmp, string eName);
        //Method for make change on employee
        void EditEmployee(string id, double salary, Positions positions);
    }
}

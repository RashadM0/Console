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
        Department[] Departments { get; }
        Department[] GetDepartments(Department[] departments);
        void AddDepartment(string name, double salaryLimit, int workerLimit);
        void EditDepartments(string name, string NewDepartmentName);
        void AddEmployee(string fullName, Positions positions, double salary, int index, Employee employee);
        void DeleteEmployee(string departmentName, string id);
        void EditEmployee(string id, double salary, Positions positions);
    }
}

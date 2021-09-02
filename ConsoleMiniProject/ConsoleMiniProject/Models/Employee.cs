using System;
using System.Collections.Generic;
using System.Text;
using ConsoleMiniProject.Enums;
using ConsoleMiniProject.Interfaces;
using ConsoleMiniProject.Models;
using ConsoleMiniProject.Services;

namespace ConsoleMiniProject.Models
{
    class Employee
    {
        private static int count = 1000;
        private string _Position;
        private double _Salary;
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Position
        {
            get
            {
                return _Position;
            }
            set
            {
                if (value.Trim().Length >= 2)
                    _Position = value;
            }
        }
        public double Salary
        {
            get
            {
                return _Salary;
            }

            set
            {
                if (value >= 250)
                    _Salary = value;
            }
        }
        public string DepartmentName { get; set; }
        public Positions positions;
        public Employee(string fullName, double salary, string departmentName, string position, Positions positions)
        {
            FullName = fullName;
            Salary = salary;
            DepartmentName = departmentName;
            Position = position;
            Id = $"{position[0]}{position[1]}{++count}";

            switch (positions)
            {
                case Positions.GuitarBranch:
                    Id = "Gu" + count++;
                    break;
                case Positions.PianoBranch:
                    Id = "Pi" + count++;
                    break;
                case Positions.DrumBranch:
                    Id = "Dr" + count++;
                    break;
                case Positions.VocalBranch:
                    Id = "Vo" + count++;
                    break;
                default:
                    break;
            }
        }
    }
}

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
        private static int _id = 1000;
        private double _Salary;
        public string Id { get; set; }
        public string FullName { get; set; }
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
        public Positions Positions;
        public Employee(string fullName, double salary, Department departmentName, Positions positions)
        {
            FullName = fullName;
            Salary = salary;
            DepartmentName = departmentName.Name;
            Positions = positions;
            Id = departmentName.Name.Substring(0, 2).ToUpper() + _id++;
            ////Id = $"{positions[0]}{positions[1]}{++count}";
            //switch (positions)
            //{
            //    case Positions.GuitarBranch:
            //        Id = "Gu" + id++;
            //        break;
            //    case Positions.PianoBranch:
            //        Id = "Pi" + id++;
            //        break;
            //    case Positions.DrumBranch:
            //        Id = "Dr" + id++;
            //        break;
            //    case Positions.VocalBranch:
            //        Id = "Vo" + id++;
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}

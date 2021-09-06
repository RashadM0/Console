using System;
using ConsoleMiniProject.Services;
using ConsoleMiniProject.Enums;
using ConsoleMiniProject.Models;
using System.Linq;

namespace ConsoleMiniProject
{
    class Program
    {
        static void Main(string[] args)
        {
            
            HumanResourceManager humanResourceManager = new HumanResourceManager();
            Employee[] employees = new Employee[0];
            

        TryAgain:
            #region Welcoming
            Console.WriteLine(@"                ▄█     █▄     ▄████████  ▄█        ▄████████  ▄██████▄    ▄▄▄▄███▄▄▄▄      ▄████████ 
                ███     ███   ███    ███ ███       ███    ███ ███    ███ ▄██▀▀▀███▀▀▀██▄   ███    ███ 
                ███     ███   ███    █▀  ███       ███    █▀  ███    ███ ███   ███   ███   ███    █▀  
                ███     ███  ▄███▄▄▄     ███       ███        ███    ███ ███   ███   ███  ▄███▄▄▄     
                ███     ███ ▀▀███▀▀▀     ███       ███        ███    ███ ███   ███   ███ ▀▀███▀▀▀     
                ███     ███   ███    █▄  ███       ███    █▄  ███    ███ ███   ███   ███   ███    █▄  
                ███ ▄█▄ ███   ███    ███ ███▌    ▄ ███    ███ ███    ███ ███   ███   ███   ███    ███ 
                ▀███▀███▀    ██████████ █████▄▄██ ████████▀   ▀██████▀   ▀█   ███   █▀    ██████████ 
                                                                                     ");
            Console.WriteLine("\t***************************************************************************************************");
            #endregion
            #region Menu
            Console.WriteLine("======================================" +
                "\nPress '1' For Show Departments" +
                "\n======================================" +
                "\nPress '2' For Create a Department" +
                "\n======================================" +
                "\nPress '3' For Make Change on Departament" +
                "\n======================================" +
                "\nPress '4' For Show Workers" +
                "\n======================================" +
                "\nPress '5' For Get Workers of Department" +
                "\n======================================" +
                "\nPress '6' For Create a New Worker" +
                "\n======================================" +
                "\nPress '7' For Make Change on Workers" +
                "\n======================================" +
                "\nPress '8' For Delete Worker from Department" +
                "\n======================================" +
                "\nPress '0' For Exit" +
                "\n======================================");

            Console.Write("\n\n" +
                "\n--------------------------------------" +
                "\nYour choise: ");
            #endregion
            bool isDigit = false;

            ChoiseAgain:
            string Choise = Console.ReadLine().Trim();

            foreach (char item in Choise)
            {
                if (char.IsDigit(item) == true)
                    isDigit = true;
                else
                {
                    Console.Write("Please Enter a Digit: ");
                    goto ChoiseAgain;
                }

                switch (Choise)
                {
                    case "1":
                        humanResourceManager.InfoDepartment();
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    break;
                    case "2":
                        AddDepartment(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    break;
                    case "3":
                        EditDepartments(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                        break;
                    case "4":
                        humanResourceManager.ShowEmployees(employees);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                        break;
                    case "5":
                        humanResourceManager.ShowEmployeeOfDepartment(employees);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                        break;
                    case "6":
                        AddEmployee(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                        break;
                    case "7":
                        EditEmployee(ref humanResourceManager);
                    break;
                    case "0":
                    break;
                default:
                        Console.Clear();
                        
                        goto TryAgain;
                }
            }
        }


        
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {

            Console.Clear();
        AddAgain:
            Console.Write("Please Enter the Department Name: ");
        AddAgain2:
            string name = Console.ReadLine();
            if (name.Length <= 1)
            {
                Console.Write(
                    "\n" +
                    "Department name Cannot be Less than 2 Letters. Please Try Again: ");
                goto AddAgain2;
            }
            Console.Write("Please Enter the Worker Limit: ");
        ChoiseWorkerLimit:
            int workerLimit;
            bool number = int.TryParse(Console.ReadLine(), out workerLimit);
            if (!number)
            {
                Console.Write(
                    "\n" +
                    "Please Enter Integer Value: ");
                goto ChoiseWorkerLimit;
            }

            Console.Write("Please Enter the Salary Limit: ");
            ChoiseSalaryLimit:
            double salaryLimit;
            bool number1 = double.TryParse(Console.ReadLine(), out salaryLimit);
            if (!number1)
            {
                Console.Write(
                    "\n" +
                    "Please Enter Proper Value: ");
                goto ChoiseSalaryLimit;
            }
            
            if (salaryLimit >= 250 && workerLimit >= 1)
            {
                humanResourceManager.AddDepartment(name, salaryLimit, workerLimit);
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                $"\nDepartment Name: {name}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nSalary Limit: {salaryLimit}" +
                "\n++++++++++++++++++++++++++++++++++++++" +
                $"\nWorker Limit: {workerLimit}\n\n");
            }
            else
            {
                Console.Write("The Minimum Salary Should be 250. Please Try Again: ");
                goto ChoiseSalaryLimit;
            }

        }
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            
            Console.Write("Enter Full Name of Employee: ");
            string fullName = Console.ReadLine();

            for (int i = 0; i < humanResourceManager.Departments.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {humanResourceManager.Departments[i].Name}");
            }
            int Depart = int.Parse(Console.ReadLine());
            string[] positionType = Enum.GetNames(typeof(Positions));
            for (int j = 0; j < positionType.Length; j++)
            {
                Console.WriteLine($"{j + 1} - {positionType[j]}");
            }
            string typestr;
            int typeint;
            Console.Write("Choise Position: ");
            typestr = Console.ReadLine();
            while (!int.TryParse(typestr, out typeint) || typeint < 1 || typeint > positionType.Length)
            {
                Console.WriteLine("Please Try Again: ");
                typestr = Console.ReadLine();
            }
            Positions positions = (Positions)typeint;


            Console.Write("Enter Salary of Employee: ");
        tryagain:

            double salary = Convert.ToDouble(Console.ReadLine());
            if (salary < 250)
            {
                Console.Write("The Minimum Salary Should be 250. Please Try Again: ");
                goto tryagain;
            }
            else
                Console.WriteLine("\n\n***************************************\n\nEmployee successfully added!\n");

            humanResourceManager.AddEmployee(fullName, positions, salary, employee(Depart - 1));
        }
        static void EditDepartments(ref HumanResourceManager humanResourceManager)
        {
            Console.Write("Enter the name of the company you want to change: ");
        CreateAgain:
            string oldName = Console.ReadLine().ToLower();
            
                foreach (var item in humanResourceManager.Departments)
                {
                    if (item.Name == oldName)
                    {
                        Console.Write("Enter new Department Name: ");
                    EnterAgain:
                        string newName = Console.ReadLine();
                        foreach (var item1 in humanResourceManager.Departments)
                        {
                            if (item1.Name == newName)
                            {
                                Console.Write("The department you entered is exist.. Please Try Again: ");
                                goto EnterAgain;
                            }
                            if (item.Name == newName)
                            {
                                Console.Write("New Name and Old Name Cannot Be the Same. Please Try Again: ");
                                goto EnterAgain;
                            }
                            else
                            {
                                humanResourceManager.EditDepartments(oldName, newName);
                                foreach (var item3 in humanResourceManager.Departments)
                                {
                                    foreach (var item2 in item1.Employees)
                                    {
                                        item2.Id = item2.Id.Replace(item2.Id.Substring(0, 2), newName.ToUpper().Substring(0, 2));
                                        item2.DepartmentName = newName;
                                    }
                                }
                                Console.WriteLine("\n\n***************************************\n\nDepartment successfully editing!\n");
                                break;
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("\n\n***************************************\n\nNo such department found!\n");
                    }
                }
        }
            
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
            {
                Console.Write("Enter Employee ID: ");
                string id = Console.ReadLine();

                Console.Write("Enter Employee Salary: ");
                double salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Positions: ");
                string[] positionName = Enum.GetNames(typeof(Positions));
                for (int i = 0; i < positionName.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {positionName[i]}");
                }
                
                string typeStr;
                int typeInt;

                Console.Write("Select Position: ");
                typeStr = Console.ReadLine();
                
                while (!int.TryParse(typeStr,out typeInt) || typeInt < 0 || typeInt < positionName.Length)
                {
                    Console.WriteLine("Wrong Number!");
                    typeStr = Console.ReadLine();
                }

                Positions positions  = (Positions)typeInt;

                humanResourceManager.EditEmployee(id, salary, positions);
            }
    }
}

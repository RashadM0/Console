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
            //Process menu
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
                "\nPress '5' For Create a New Worker" +
                "\n======================================" +
                "\nPress '6' For Make Change on Workers" +
                "\n======================================" +
                "\nPress '7' For Delete Worker from Department" +
                "\n======================================" +
                "\nPress '0' For Exit" +
                "\n======================================");
            Console.Write("\n\n" +
                "\n--------------------------------------" +
                "\nYour choise: ");
            #endregion
            //Choise menu
            bool isDigit = false;
            ChoiseAgain:
            string Choise = Console.ReadLine().Trim();
            foreach (char item in Choise)
            {
                if (char.IsDigit(item) == true)
                    isDigit = true;
                else
                {
                    Console.Write("Please Enter Proper Value: ");
                    goto ChoiseAgain;
                }
                switch (Choise)
                {
                    case "1":
                        humanResourceManager.InfoDepartment();
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "2":
                        AddDepartment(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "3":
                        EditDepartments(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "4":
                        humanResourceManager.ShowEmployees(employees);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "5":
                        AddEmployee(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "6":
                        EditEmployee(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "7":
                        DeleteEmployee(ref humanResourceManager);
                        Console.WriteLine("Press any key for continue");
                        Console.ReadLine();
                        goto TryAgain;
                    case "0":
                        Console.WriteLine("Thank you for using our application :)");
                        Console.WriteLine(DateTime.Now);
                        Console.ReadLine();
                        break;
                default:
                        Console.Clear();
                        goto TryAgain;
                }
            }
        }
        // Method for add new department
        static void AddDepartment(ref HumanResourceManager humanResourceManager)
        {
            Console.Clear();
        AddAgain:
            Console.Write("Please Enter the Department Name: ");
        AddAgain2:
            string name = Convert.ToString(Console.ReadLine()).Trim();
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
            if (workerLimit < 0)
            {
                Console.Write("Please Enter Positive Number: ");
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
        // Method for add new employee
        static void AddEmployee(ref HumanResourceManager humanResourceManager)
        {
            string fullname;
            int typeint1;
            do
            {
                Console.Write("Enter Full Name of Employee: ");
                fullname = Console.ReadLine();
            } while (int.TryParse(fullname, out typeint1));
            for (int i = 0; i < humanResourceManager.Departments.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {humanResourceManager.Departments[i].Name}");
            }
            Console.Write("Choise Department: ");
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
                Console.Write("Please Try Again: ");
                typestr = Console.ReadLine();
            }
            Positions positions = (Positions)typeint;
            Console.Write("Enter Salary of Employee: ");
        tryagain:
            double salary;
            bool number1 = double.TryParse(Console.ReadLine(), out salary);
            if (!number1)
            {
                Console.Write(
                    "\n" +
                    "Please Enter Proper Value: ");
                goto tryagain;
            }
            if (salary < 250)
            {
                Console.Write("The Minimum Salary Should be 250. Please Try Again: ");
                goto tryagain;
            }
            humanResourceManager.AddEmployee(fullname, positions, salary, (Depart - 1));
        }
        //Method for make change on departments
        static void EditDepartments(ref HumanResourceManager humanResourceManager)
        {
            Console.Write("Enter the name of the company you want to change: ");
        CreateAgain:
            string oldName = Convert.ToString(Console.ReadLine()).Trim();
                foreach (var item in humanResourceManager.Departments)
                {
                    if (item.Name.ToLower() == oldName.ToLower())
                    {
                        Console.Write("Enter new Department Name: ");
                EnterAgain:
                    string newName = Convert.ToString(Console.ReadLine()).Trim();
                    foreach (var item1 in humanResourceManager.Departments) 
                    {
                        if (item1.Name.ToUpper() == newName.ToUpper())
                        {
                            Console.Write("The department you entered is already exist.. Please Try Again: ");
                            goto EnterAgain;
                        }
                    }
                    if (item.Name.ToUpper() == newName.ToUpper())
                    {
                        Console.Write("New Name and Old Name Cannot Be the Same. Please Try Again: ");
                        goto EnterAgain;
                    }
                    else
                    {
                        humanResourceManager.EditDepartments(oldName, newName);
                        foreach (var item1 in humanResourceManager.Departments) 
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
                else
                    Console.WriteLine("\n\n***************************************\n\nNo such department found!\n");


            }
        }
        //Method for make change on employee
        static void EditEmployee(ref HumanResourceManager humanResourceManager)
            {
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();
            foreach (var item in humanResourceManager.Departments)
            {
                foreach (var item1 in item.Employees)
                {
                    if (item1.Id.ToLower() == id.ToLower())
                    {
                        Console.WriteLine("Employee Detected: ");
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item1.FullName}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item1.Salary}" +
                        "\n++++++++++++++++++++++++++++++++++++++" +
                        $"\n{item1.Positions}\n\n");
                        string[] positionName = Enum.GetNames(typeof(Positions));
                        for (int i = 0; i < positionName.Length; i++)
                        {
                            Console.WriteLine($"{i + 1} {positionName[i]}");
                        }
                        string typeStr;
                        int typeInt;
                        Console.Write("\n***************************************\nSelect Position: ");
                        typeStr = Console.ReadLine();
                        while (!int.TryParse(typeStr, out typeInt) || typeInt < 1 || typeInt > positionName.Length)
                        {
                            Console.WriteLine("Wrong Number!");
                            typeStr = Console.ReadLine();
                        }
                        Positions positions = (Positions)typeInt;
                        item1.Positions = positions;
                        Console.Write("\n***************************************\nEnter new employee salary: ");
                        tryagain1:
                        double salary;/* = Convert.ToDouble(Console.ReadLine());*/
                        bool number = double.TryParse(Console.ReadLine(), out salary);
                        if (!number)
                        {
                            Console.Write(
                            "\n" +
                            "Please Enter Proper Value: ");
                            goto tryagain1;
                        }
                        if (salary < 250)
                        {
                            Console.Write("The Minimum Salary Should be 250. Please Try Again: ");
                            goto tryagain1;
                        }
                        else
                            item1.Salary = salary;
                        humanResourceManager.EditEmployee(id, salary, positions);
                        Console.WriteLine("\n\n***************************************\n\nEmployee successfully edited!\n");
                        return;
                    }
                }
            }
        }
        //Method for remove workers
        static void DeleteEmployee(ref HumanResourceManager humanResourceManager)
        {
            Console.Write("Enter Department Name: ");
            string dName = Console.ReadLine().Trim();
            Console.Write("Enter Employee ID you Want to Delete: ");
            string idEmp = Console.ReadLine().Trim();
            //Console.Write("Enter employee name you want to delete: ");
            //string ename = Console.ReadLine().Trim();
            humanResourceManager.DeleteEmployee(dName, idEmp/*, ename*/);
        }
    }
}

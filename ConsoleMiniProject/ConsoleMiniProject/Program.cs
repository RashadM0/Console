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
                "\nPress '4' For List of Workers" +
                "\n======================================" +
                "\nPress '5' For List Workers of Department" +
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
                        InfoDepartment(ref humanResourceManager);
                        break;

                    case "2":
                        AddDepartment(ref humanResourceManager);
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

        static void InfoDepartment(ref HumanResourceManager humanResourceManager)
        {

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
                Console.Write("The Minimum Salary Should be 250: ");
                goto ChoiseSalaryLimit;
            }

        }


        static void EditEmployee(ref HumanResourceManager humanResourceManager)
            {
                Console.Write("Enter Employee ID: ");
                string id = Console.ReadLine();

                Console.Write("Enter Employee Salary: ");
                double salary = double.Parse(Console.ReadLine());
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

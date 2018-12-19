using System;
using System.Collections.Generic;
using System.IO;

namespace Task___ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            string error = "Enter the correct number! ";
            string backToMainMenu = "You back to main menu. Choose the method number: ";
            string selectMethod = "Choose the method number: ";
            int number;
            string input;
            

            //MAIN PANEL
            MainPanel();

            do
            {
                // user choise input
                string choise = Console.ReadLine();

                //Cases
                switch (choise)
                {
                    case "1":
                        Console.Write("Select a number in the range of 1-1000: ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out number) && number <= 1000)
                        {
                            FizzBuzz(number);
                            Console.WriteLine(selectMethod);
                        }
                        else Console.Write(error + backToMainMenu);
                        break;
                    case "2":
                        Console.Write("Enter the number of folders to create: ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out number) && number <= 5)
                        {
                            DeepDive(number);
                            Console.Write(selectMethod);
                        }
                        else Console.WriteLine(error + "Remember max 5 folders. " + backToMainMenu);
                        break;
                    case "3":
                        // 3. DrownItDown
                        break;
                    case "4":
                        Exit();
                        break;
                    default:
                        Console.WriteLine(error);
                        break;
                }
            } while (true);
        }

        // Main Panel View
        public static void MainPanel()
        {
            Console.WriteLine("Choose the method number:");
            Console.WriteLine("");
            Console.WriteLine("1. FizzBuzz");
            Console.WriteLine("2. DeepDive");
            Console.WriteLine("3. DrownItDown");
            Console.WriteLine("4. Exit");
            Console.WriteLine("-------------------------------");
            Console.Write("Selected number: ");
        }

        //1. FizzBuzz
        public static void FizzBuzz(int number)
        {
            if (number % 2 == 0 & number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 2 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 3 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else Console.WriteLine(number);
        }

        //2. DeepDive
        public static void DeepDive(int number)
        {
            
            if (!Directory.Exists(FullFilePath()))
            {
                DirectoryInfo folder = new DirectoryInfo(FullFilePath()); // info about main path

                Directory.CreateDirectory(folder.ToString()); // if 1 folder than create
                

                for (int i = 1; i < number; i++) // create subfolders in main folder, if more than one folder
                {
                    var v = folder.CreateSubdirectory(Guid.NewGuid().ToString());
                    string newpath = Path.GetFullPath(v.ToString());
                    folder = new DirectoryInfo(newpath);
                    
                }
            }
            Console.WriteLine("Done! " + number + " folder/s have been created. Check your desktop.");
        }

        // Full file path for initial folder on desktop
        public static string FullFilePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // main path for desktop
            string yourGuid = Guid.NewGuid().ToString(); // GUID Folder name
            string pathToCreate = Path.Combine(path, yourGuid); // path to first folder with GUID name

            return pathToCreate;
        }

        //4. Exit 
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}

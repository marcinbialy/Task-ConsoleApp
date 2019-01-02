using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task___ConsoleApp
{
    class Program
    {
        private List<string> list = new List<string>(); // list to catch created folders

        static void Main(string[] args)
        {
            string error = "Enter the correct number! ";
            string backToMainMenu = "You back to main menu. Choose the method number: ";
            string selectMethod = "Choose the method number: ";
            int number;
            string input;
            Program p = new Program();
            
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
                        Console.Write("Select a number in the range of 0-1000: ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out number) && number >= 0 && number <= 1000)
                        {
                            FizzBuzz(number);
                            Console.WriteLine(selectMethod);
                        }
                        else
                        {
                            Console.WriteLine(error);
                            Console.Write(backToMainMenu);
                        }
                        break;
                    case "2":
                        Console.Write("Enter the number of folders to create: ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out number) && number > 0 && number <= 5)
                        {
                            p.DeepDive(number);
                            Console.Write(selectMethod);
                        }
                        else
                        {
                            Console.WriteLine(error + "Remember max 5 folders. ");
                            Console.Write(backToMainMenu);
                        }
                        break;
                    case "3":
                        Console.Write("Enter the folder level to create the file: ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out number) && number > 0 && number <= 5)
                        {
                            p.DrownItDown(number);
                            Console.Write(selectMethod);
                        }
                        else
                        {
                            Console.WriteLine(error);
                            Console.Write(backToMainMenu);
                        }
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
            if (number == 0)
            {
                Console.WriteLine("I do not divide by zero!");
            }
            else if (number % 2 == 0 & number % 3 == 0)
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
            else
            {
                Console.WriteLine(number);
            }
        }

        //2. DeepDive
        public void DeepDive(int number)
        {
            list.Clear(); // clear the list before repeat the method

            if (!Directory.Exists(FullFilePath()))
            {
                DirectoryInfo folder = new DirectoryInfo(FullFilePath()); // info about main path

                Directory.CreateDirectory(folder.ToString()); // if 1 folder than create
                list.Add(folder.ToString());

                for (int i = 1; i < number; i++) // create subfolders in main folder, if more than one folder
                {
                    var v = folder.CreateSubdirectory(Guid.NewGuid().ToString());
                    string newpath = Path.GetFullPath(v.ToString());
                    folder = new DirectoryInfo(newpath);
                    list.Add(v.ToString());
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

        //3. DrownItDown
        public void DrownItDown(int number)
        {
            if (list.Count != 0)
            {
                if (list.Count >= number)
                {
                    for (int i = 0; i < list.Count(); i++)
                    {
                        if (number - 1 == i)
                        {
                            //Console.WriteLine(list[i]); // path to save file

                            if (!File.Exists($"{list[i]}"+Path.DirectorySeparatorChar+"empty.txt"))
                            {
                                File.WriteAllText(Path.Combine(list[i], "empty.txt"), " "); // create empty file
                                Console.WriteLine("Empty file created successfully on " + number + " level!");
                            }
                            else // file overwritten
                            {
                                FileOverwriting(list[i]);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You do not have this level of folders!");
                }
            }
            else
            {
                Console.WriteLine("If you want to create a file, first create folders with --> 2. DeepDive function ");
            }
        }

        // File Overwriting if exsist
        public void FileOverwriting(string dirPath)
        {
            Console.WriteLine("The file already exists at this level!");
            Console.Write("Do you want to overwrite the file? Press y - for yes or n - for no: ");
            string input = Console.ReadLine();
            switch (input)
            {
                case "y":
                    File.WriteAllText(Path.Combine(dirPath, "empty.txt"), " ");
                    Console.WriteLine("The file has been successfully overwritten!");
                    break;
                case "n":
                    Console.WriteLine("Ok, you back to main menu.");
                    break;
                default:
                    Console.WriteLine("Invalid input! You back to main menu.");
                    break;
            }
        }

        //4. Exit 
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}

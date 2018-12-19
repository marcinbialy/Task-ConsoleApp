using System;

namespace Task___ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // varibles
            string error = "Enter the correct number! ";

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
                        // 1. FizzBuzz
                        break;
                    case "2":
                        // 2. DeepDive
                        break;
                    case "3":
                        // 3. DrownItDown
                        break;
                    case "4":
                        //4 Exit
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


    }
}

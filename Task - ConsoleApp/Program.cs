using System;

namespace Task___ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // varibles
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
                        // 2. DeepDive
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

        //4. Exit 
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}

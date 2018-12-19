using System;

namespace Task___ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //MAIN PANEL
            MainPanel();
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

using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete1_bankomaten
{
    public static class InputHelper
    {
        public static int ReadNumber(string prompt, int min, int max, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string? text = Console.ReadLine();

                if (text is null)
                    Environment.Exit(0);
                
                if (int.TryParse(text, out int value)  && value >= min &&  value <= max)
                    return value;
                
                ErrorHandler.Show(errorMessage);
            }
        }
        public static decimal ReadAmount(string prompt, decimal min, decimal max, string errorMessage)
        {
            while (true)
            {
                Console.Write(prompt);
                string? text = Console.ReadLine();

                if (text is null)
                    Environment.Exit(0);

                if (decimal.TryParse(text, out decimal value) && value >= min && value <= max)
                    return value;

                ErrorHandler.Show(errorMessage);
            }
        }
        public static void WaitForEnter()
        {
            Console.Write("Tryck Enter för att komma tillbaka till menyn.");
            Console.ReadLine();
        }
    }
}

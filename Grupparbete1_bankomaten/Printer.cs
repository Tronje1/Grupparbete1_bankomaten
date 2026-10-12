using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete1_bankomaten
{
    public static class Printer
    {
        
        //Bara placeholder
        private static readonly Account MainAccount = new("Lönekonto", 5000m);
        private static readonly Account SavingsAccount = new("Sparkonto", 1000m);
        public static void Run()
        {
            while (true)
            {
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("1. Visa Saldon");
                Console.WriteLine("2. Överföra Pengar");
                Console.WriteLine("3. Avsluta");

                int choice = InputHelper.ReadNumber("Val: ", 1, 3, ErrorHandler.InvalidChoice);

                if (choice == 3)
                    return;
                switch (choice)
                {
                    case 1: ShowBalance(); break;
                    case 2: Transfer(); break;
                }
            }
        }
        private static void ShowBalance()
        {
            Console.WriteLine($"{MainAccount.Name}: {MainAccount.Balance} kr");
            Console.WriteLine($"{SavingsAccount.Name}: {SavingsAccount.Balance} kr");
            InputHelper.WaitForEnter();
        }
        private static void Transfer()
        {
            Console.WriteLine($"Överför från {MainAccount.Name} till {SavingsAccount.Name}.");

            decimal amount = InputHelper.ReadAmount("Belopp: ", 0.01m, decimal.MaxValue, ErrorHandler.InvalidAmount);

            if (!MainAccount.TryTransfer(SavingsAccount, amount, out string error))
            {
                ErrorHandler.Show(error);
                InputHelper.WaitForEnter();
                return;
            }

            Console.WriteLine($"Klart. {MainAccount.Name}: {MainAccount.Balance} kr, {SavingsAccount.Name}: {SavingsAccount.Balance} kr.");
            InputHelper.WaitForEnter();
        }
    }
}

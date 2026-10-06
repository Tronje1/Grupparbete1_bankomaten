using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete1_bankomaten
{
    public static class ErrorHandler
    {
        public const string InvalidChoice = "Ogiltigt Val";

        public const string InsuficientFunds = "Du har inte tillräckligt med pengar på kontot.";

        public const string InvalidAmount = "Ogiltigt Belopp";

        public static void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}

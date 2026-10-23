using System;

namespace Grupparbete1_bankomaten
{
    public static class ErrorHandler
    {
        public const string InvalidChoice = "Ogiltigt Val";

        public const string InsuficientFunds = "Du har inte tillräckligt med pengar på kontot.";

        public const string InvalidAmount = "Ogiltigt Belopp";

        // Fel vid inloggningen.
        public const string InvalidLogin = "Fel användarnamn eller kod.";

        public const string TooManyAttempts = "För många felaktiga försök. Återgår till startmenyn.";

        public const string InvalidCode = "Koden måste vara ett heltal.";

        public const string EmptyInput = "Du måste skriva något.";

        // Fel vid överföring.
        public const string NeedTwoAccounts = "Du behöver minst två konton för att kunna föra över pengar.";

        public const string SameAccount = "Du kan inte föra över till samma konto.";

        public static void Show(string message)
        {
            Console.WriteLine(message);
        }
    }
}
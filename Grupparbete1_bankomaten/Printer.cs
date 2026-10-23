using System;
using System.Collections.Generic;

namespace Grupparbete1_bankomaten
{
    // internal (inte public) eftersom Run tar emot en List<User> och User är internal.
    internal static class Printer
    {
        // Hur många gånger man får skriva fel innan bankomaten ger upp.
        private const int MaxLoginAttempts = 3;

        // Startar bankomaten med de användare som Program.cs skickar in. Kontona
        // hämtas från den inloggade användarens egen lista (User.Kontoer) - den här
        // klassen har inga egna konton.
        public static void Run(List<User> users)
        {
            // Startmenyn ligger före inloggningen så man kan välja att avsluta
            // utan att först skriva in namn och kod.
            while (true)
            {
                Clear();
                Console.WriteLine("Välkommen till Bankomaten!");
                Console.WriteLine("1. Logga in");
                Console.WriteLine("2. Avsluta");

                int choice = InputHelper.ReadNumber("Val: ", 1, 2, ErrorHandler.InvalidChoice);

                if (choice == 2)
                {
                    Console.WriteLine("Tack för besöket!");
                    return;
                }

                User? user = Login(users);
                if (user is null)
                    continue; // För många fel: tillbaka till startmenyn.

                Meny(user); // Menyn returnerar när man loggar ut.
            }
        }

        // Rensar terminalen så den gamla utskriften inte ligger kvar ovanför
        // menyn. Console.Clear kastar IOException när utskriften är omdirigerad
        // (t.ex. till en fil eller ett test), så då hoppar vi över den.
        private static void Clear()
        {
            if (Console.IsOutputRedirected)
                return;

            Console.Clear();
        }

        // Inloggningsmenyn: frågar efter namn och kod och jämför med användarna
        // från User-klassen. Returnerar användaren, eller null om man misslyckades
        // MaxLoginAttempts gånger.
        private static User? Login(List<User> users)
        {
            Clear();

            for (int attempt = 1; attempt <= MaxLoginAttempts; attempt++)
            {
                Console.WriteLine();
                Console.WriteLine($"Inloggning {attempt} av {MaxLoginAttempts}");

                string namn = InputHelper.ReadText("Användarnamn: ");
                int kod = InputHelper.ReadNumber("Kod: ", int.MinValue, int.MaxValue, ErrorHandler.InvalidCode);

                User? user = FindUser(users, namn, kod);
                if (user is not null)
                    return user;

                ErrorHandler.Show(ErrorHandler.InvalidLogin);
            }

            ErrorHandler.Show(ErrorHandler.TooManyAttempts);
            InputHelper.WaitForEnter();
            return null;
        }

        // Letar upp användaren med rätt namn och kod.
        private static User? FindUser(List<User> users, string namn, int kod)
        {
            foreach (User user in users)
            {
                if (user.Namn == namn && user.Kod == kod)
                    return user;
            }

            return null;
        }

        private static void Meny(User user)
        {
            while (true)
            {
                Clear();
                Console.WriteLine($"Inloggad som {user.Namn}.");
                Console.WriteLine();
                Console.WriteLine("Huvudmeny");
                Console.WriteLine("1. Visa Saldon");
                Console.WriteLine("2. Överföra Pengar");
                Console.WriteLine("3. Ta ut Pengar");
                Console.WriteLine("4. sätt in Pengar");
                Console.WriteLine("5. Logga ut");

                int choice = InputHelper.ReadNumber("Val: ", 1, 5, ErrorHandler.InvalidChoice);

                if (choice == 5)
                    return;
                switch (choice)
                {
                    case 1: ShowBalance(user); break;
                    case 2: Transfer(user); break;
                    case 3: Account.TaUt(user); break;
                    case 4: Account.SetIn(user); break;
                }
            }
        }

        // Skriver ut den inloggades egna konton, med nummer så de går att välja.
        public static void ShowAccounts(User user)
        {
            Console.WriteLine("Dina konton:");
            for (int i = 0; i < user.Kontoer.Count; i++)
            {
                Account konto = user.Kontoer[i];
                Console.WriteLine($"  {i + 1}. {konto.KontoNamn}: {konto.Saldo} kr");
            }
        }

        private static void ShowBalance(User user)
        {
            ShowAccounts(user);
            InputHelper.WaitForEnter();
        }

        private static void Transfer(User user)
        {
            // Man behöver minst två konton för att kunna föra över något.
            if (user.Kontoer.Count < 2)
            {
                ErrorHandler.Show(ErrorHandler.NeedTwoAccounts);
                InputHelper.WaitForEnter();
                return;
            }

            ShowAccounts(user);

            int franNummer = InputHelper.ReadNumber("Från (nummer): ", 1, user.Kontoer.Count, ErrorHandler.InvalidChoice);
            int tillNummer = InputHelper.ReadNumber("Till (nummer): ", 1, user.Kontoer.Count, ErrorHandler.InvalidChoice);

            if (franNummer == tillNummer)
            {
                ErrorHandler.Show(ErrorHandler.SameAccount);
                InputHelper.WaitForEnter();
                return;
            }

            // Samma objekt som användaren har i sin lista, så saldot ändras på riktigt.
            Account fran = user.Kontoer[franNummer - 1];
            Account till = user.Kontoer[tillNummer - 1];

            decimal amount = InputHelper.ReadAmount("Belopp: ", 0.01m, decimal.MaxValue, ErrorHandler.InvalidAmount);

            if (amount > fran.Saldo)
            {
                ErrorHandler.Show(ErrorHandler.InsuficientFunds);
                InputHelper.WaitForEnter();
                return;
            }

            fran.Saldo -= amount;
            till.Saldo += amount;

            Console.WriteLine($"Klart. {fran.KontoNamn}: {fran.Saldo} kr, {till.KontoNamn}: {till.Saldo} kr.");
            InputHelper.WaitForEnter();
        }

    }
}
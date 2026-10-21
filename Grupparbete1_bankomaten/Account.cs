using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Grupparbete1_bankomaten
{
    internal class Account
    {
        public string KontoNamn { get; set; }
        public decimal Saldo { get; set; }

        public Account(string kontonamn, decimal saldo)
        {
            this.KontoNamn = kontonamn;

            this.Saldo = saldo;
        }

        public static void TaUt(User user)
        {
            Printer.ShowAccounts(user);

            int franNummer = InputHelper.ReadNumber("Från (nummer): ", 1, user.Kontoer.Count, ErrorHandler.InvalidChoice);

            Account fran = user.Kontoer[franNummer - 1];

            decimal amount = InputHelper.ReadAmount("Belopp: ", 0.01m, decimal.MaxValue, ErrorHandler.InvalidAmount);

            if (amount > fran.Saldo)
            {
                ErrorHandler.Show(ErrorHandler.InsuficientFunds);
                InputHelper.WaitForEnter();
                return;
            }
            fran.Saldo -= amount;

            Console.WriteLine($"Klart. {fran.KontoNamn}: {fran.Saldo} kr.");

            InputHelper.WaitForEnter();
        }
        public static void SetIn(User user)
        {
            Printer.ShowAccounts(user);

            int franNummer = InputHelper.ReadNumber("till (nummer): ", 1, user.Kontoer.Count, ErrorHandler.InvalidChoice);

            Account fran = user.Kontoer[franNummer - 1];

            decimal amount = InputHelper.ReadAmount("Belopp: ", 0.01m, decimal.MaxValue, ErrorHandler.InvalidChoice);

            fran.Saldo += amount;

            Console.WriteLine($"Klart. {fran.KontoNamn}: {fran.Saldo} kr.");

            InputHelper.WaitForEnter();
        }


        //public void TaUt() // låter deig ta ut pengar.
        //{
        //    int summa = int.Parse(Console.ReadLine());
        //    if (summa <= Saldo)
        //    {
        //        Saldo -= summa;
        //        Console.WriteLine($"Du tog ut {summa} kr.");
        //        Console.WriteLine($"Nytt saldo: {Saldo} kr");
        //    }
        //    else if (summa > Saldo) // om du inte har tillräckligt med pengar.
        //    {
        //        ErrorHandler.Show(ErrorHandler.InvalidAmount);
        //    }
        //}
        //public void SetIn() // låter dig sätta in pengar.
        //{
        //    int summa = int.Parse(Console.ReadLine());
        //    Saldo += summa;
        //    Console.WriteLine($"Du sätte in {summa} kr.");
        //    Console.WriteLine($"Nytt saldo: {Saldo} kr");
        //}
    }
}
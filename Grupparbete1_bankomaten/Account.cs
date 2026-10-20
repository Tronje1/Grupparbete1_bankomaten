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
        public decimal SparSaldo { get; set; }

        public Account(string kontonamn, decimal saldo)
        {
            this.KontoNamn = kontonamn;

            this.Saldo = saldo;
        }

        public void VisaKonton() // visar hur mycket pengar du har,
        {
            Console.WriteLine($"Du har {Saldo} kr i dit kontot");
            Console.WriteLine($"Du har {SparSaldo} kr i dit sparkontot");
        }
        public void TaUt() // låter deig ta ut pengar.
        {
            int summa = int.Parse(Console.ReadLine());
            if (summa <= Saldo)
            {
                Saldo -= summa;
                Console.WriteLine($"Du tog ut {summa} kr.");
                Console.WriteLine($"Nytt saldo: {Saldo} kr");
            }
            else if (summa > Saldo) // om du inte har tillräckligt med pengar.
            {
                ErrorHandler.Show(ErrorHandler.InvalidAmount);
            }
        }
        public void SetIn() // låter dig sätta in pengar.
        {
            int summa = int.Parse(Console.ReadLine());
            Saldo += summa;
            Console.WriteLine($"Du sätte in {summa} kr.");
            Console.WriteLine($"Nytt saldo: {Saldo} kr");
        }
        public void TTF() // låter dig välja att föröver mellan spar och privat konto (TTF() är inte nödvändig)
        {
            string vall = Console.ReadLine();
            switch (vall)
            {
                case "1":
                    SpaSaldo();
                    break;
                case "2":
                    SaldoSpar();
                    break;
                default:
                    ErrorHandler.Show(ErrorHandler.InvalidChoice);
                    break;
            }

        }
        public bool SpaSaldo() // låter dig föra över mellan spar till pivat.
        {
            Console.Write("Hur mycket vill du förra övar?");
            int summa = int.Parse(Console.ReadLine());
            if (summa > Saldo)
            {
                ErrorHandler.Show(ErrorHandler.InvalidAmount);
                return false;
            }
            Saldo += summa;
            SparSaldo -= summa;
            Console.WriteLine($"Du tog ut {summa} kr.");
            Console.WriteLine($"Nytt saldo: {Saldo} kr");
            Console.WriteLine($"Nytt Spar saldo: {SparSaldo} kr");
            return true;
        }
        public bool SaldoSpar()// låter dig föra över mellan privat till spar.
        {
            Console.Write("Hur mycket vill du förra övar?");
            int summa = int.Parse(Console.ReadLine());
            if (summa > Saldo)
            {
                ErrorHandler.Show(ErrorHandler.InvalidAmount);
                return false;
            }
            Saldo -= summa;
            SparSaldo += summa;
            Console.WriteLine($"Du tog ut {summa} kr.");
            Console.WriteLine($"Nytt saldo: {Saldo} kr");
            Console.WriteLine($"Nytt Spar saldo: {SparSaldo} kr");
            return true;
        }
    }
}
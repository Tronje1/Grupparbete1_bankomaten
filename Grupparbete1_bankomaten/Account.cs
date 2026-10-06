using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete1_bankomaten
{
    internal class Account
    {
        public string AnvändarNamn { get; set; }
        public int PinKod { get; set; }
        public int Saldo { get; set; }

        public void VisaKonton()
        {
            Console.WriteLine($"Du har {Saldo} kr på kontot");
        }
        public void TaUt()
        {
            int summa = int.Parse(Console.ReadLine());
            if (summa <= Saldo)
            {
                Saldo -= summa;
                Console.WriteLine($"Du tog ut {summa} kr.");
                Console.WriteLine($"Nytt saldo: {Saldo} kr");
            }
            else if (summa > Saldo)
            {
                Console.WriteLine("Du har inte tillräckligt med pengar.");
            }
        }
        public void SetIn()
        {
            int summa = int.Parse(Console.ReadLine());
            Saldo += summa;
            Console.WriteLine($"Du sätte in {summa} kr.");
            Console.WriteLine($"Nytt saldo: {Saldo} kr");
        }
    }
}

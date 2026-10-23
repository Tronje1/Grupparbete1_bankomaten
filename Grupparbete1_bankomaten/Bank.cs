using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Grupparbete1_bankomaten
{
    internal class Bank
    {
        // Bank klassen ansvarar för att hantera bankens användare och innehåller metoder för inloggning.
        private List<User> users;

        public Bank(List<User> users)
        {
            this.users = users;
        }
        // Returnerar användaren om uppgifterna stämmer, annars null.
        public User? LoggaIn(string namn, int kod)
        {
            foreach (User user in users)
            {
                if (user.Namn == namn)
                {
                    if (user.Kod == kod)
                    {
                        return user;
                    }
                }
            }
            return null;
        }
        // Returnerar användaren om uppgifterna stämmer, annars null.
        public User? HittaUser(string namn)
        {
            foreach (User user in users)
            {
                if (user.Namn == namn)
                {
                    return user;
                }
            }
            return null;
        }
        // Returnerar true om överföringen lyckades, annars false.
        public bool OverforPengar(Account fran, Account till, decimal belopp)
        {
            if (belopp > 0 && fran.Saldo >= belopp)
            {
                fran.Saldo = fran.Saldo - belopp;
                till.Saldo = till.Saldo + belopp;
                return true;
            }
            return false;
        }
    }
}
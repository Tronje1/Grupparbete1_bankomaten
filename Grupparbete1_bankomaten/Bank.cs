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
    }
}
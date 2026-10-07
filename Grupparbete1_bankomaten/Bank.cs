using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete1_bankomaten
{
    internal class Bank
    {
        private List<User> users;

        public Bank(List<User> users)
        {
            this.users = users;
        }
        public User? LoggaIn(string namn, int kod)
        {
            foreach (User user in users)
            {
                if (User.namn == namn)
                {
                    if (User.kod == kod)
                    {
                        return user;
                    }
                }
            }
            return null;
        }
    }
}

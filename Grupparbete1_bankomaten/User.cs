using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Grupparbete1_bankomaten
{
    // Enkel definition av User-klassen
    private List<User> users;
    { 
        this.users = users;
    }
    public class User
    {
        

        public User? LoggaIn(string namn, int kod)
        {
            foreach (User user in users)
            {
                if (User.namn == namn)
                {
                    if (User.kod == kod)
                    {
                        return User;
                    }
                }


            }    
            return null;
        }
    }



    /*internal class User
    {
        //Lister till namn till brukarna             
        List<User> bankusers = new List<User> ()
        { 
          new User("Ola","1234"),
          new User("Kari","2345"), 
          new User("Per","3456"), 
          new User("Paal","4567"), 
          new User("Hans","5678") 
        };
        //Lister till konto information
        List<string> accountstype = new List<string> { "personkonto", "sparkonto", "lönekonto", "speciellkonto" };
        //
        
    }
    */
}


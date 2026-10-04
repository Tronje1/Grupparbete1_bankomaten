using System;
using System.Collections.Generic;
using System.Text;

namespace Grupparbete1_bankomaten
{
    internal class User
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
}

using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Grupparbete1_bankomaten
{
    public class User
    {
        // Variabel (egenskap) som ska hålla användarens namn.
        public string Namn { get; set; }

        // Variabel som ska hålla användarens kod (lösenord).
        public string Kod { get; set; }

        // Lista som ska hålla reda på alla användarens konton.
        public List<Konto> Kontoer { get; set; }

        // Detta är konstruktorn. Den körs automatiskt när vi skapar en ny användare.
        public User(string namn, string kod)
        {
            // Sparar namnet som skickades in i klassens egen Namn-variabel.
            this.Namn = namn;
            // Sparar koden som skickades in i klassens egen Kod-variabel.
            this.Kod = kod;

            // Skapar själva listan i minnet så att vi kan lägga till konton i den.
            this.Kontoer = new List<Konto>
        {
            // Lönekonto i listan direkt från start.
            new Konto("Lönekonto"),

            // Brukskonto i listan direkt från start.
            new Konto("Brukskonto"),

            // Sparkonto i listan direkt från start.
            new Konto("Sparkonto"),
        }; // Här stängs listan.
        }

        // Metod (en funktion) för att kunna lägga till ännu fler konton senare.
        public void LeggTilKonto(string kontoNavn)
        {
            // Lägger till ett nytt konto i listan med det namn som skickas med.
            this.Kontoer.Add(new Konto(kontoNavn));
        } 
    } 

    // Separat klass "Konto" (en mall för hur ett konto ser ut).
    /* raderat för att göra om i account.cs som var avtalt i teammöte den 12.10.2026
    public class Konto
    {
        // Varje konto måste ha ett namn (t.ex. "Sparkonto").
        public string Navn { get; set; }

        // Varje konto måste ha ett saldo (hur mycket pengar som finns på kontot).
        public decimal Saldo { get; set; }

        // Detta är konstruktorn för kontot. Den körs när ett nytt konto skapas.
        public Konto(string navn)
        {
            // Namnet på kontot i kontots egen Navn-variabel.
            Navn = navn;

            // Startpengarna på kontot till 0 kronor.
            Saldo = 0.0m;
        } 
    }*/ 



}    
    
    
    
    /* 
     // tidligare versjon av kod for å test upbygning.
     
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


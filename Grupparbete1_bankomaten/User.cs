using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;

namespace Grupparbete1_bankomaten
{
    internal class User
    {
        public string Namn { get; set; }

        public int Kod { get; set; }

        public List<Account> Kontoer { get; set; }
        public User(string namn, int kod, List<Account> kontoer)
        {
            this.Namn = namn;
            this.Kod = kod;

            this.Kontoer = kontoer;
        }

        public void LeggTilKonto(string kontoNavn)
        {
            this.Kontoer.Add(new Account(kontoNavn, 0m));
        }
    }
}

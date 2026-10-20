namespace Grupparbete1_bankomaten
{
    internal class Program
    {
        public static void Main()
        {
            List<User> users = new List<User>
            {
                new User("user1", 1234, new List<Account> { new Account("konto1", 100m) }),
                new User("user2", 1234, new List<Account> { new Account("konto1", 100m), new Account("konto2", 200m) }),
                new User("user3", 1234, new List<Account> { new Account("konto1", 100m), new Account("konto2", 200m), new Account("konto3", 300m) }),
                new User("user4", 1234, new List<Account> { new Account("konto1", 100m), new Account("konto2", 200m), new Account("konto3", 300m), new Account("konto4", 400m) }),
                new User("user5", 1234, new List<Account> { new Account("konto1", 100m), new Account("konto2", 200m), new Account("konto3", 300m), new Account("konto4", 400m), new Account("konto5", 500m) }),
            };
            Bank bank = new Bank(users);
            Printer.Run(users);
        }
    }
}
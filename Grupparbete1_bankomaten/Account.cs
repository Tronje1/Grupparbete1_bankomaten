namespace Grupparbete1_bankomaten
{
    public class Account
    {
        public string Name { get; }

        public decimal Balance { get; private set; }

        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public bool TryTransfer(Account to, decimal amount, out string error)
        {
            if (amount > Balance)
            {
                error = ErrorHandler.InsuficientFunds;
                return false;
            }

            Balance -= amount;
            to.Balance += amount;
            error = string.Empty;
            return true;
        }
    }
}
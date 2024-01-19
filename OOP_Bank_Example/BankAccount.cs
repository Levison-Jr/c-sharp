using System.Linq.Expressions;
using System.Text;

namespace OOP_Bank_Example
{
    public class BankAccount
    {
        public Guid Number { get; }
        public string Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in _allTransations)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance)
        {
            Number = Guid.NewGuid();
            Owner = name;

            MakeDeposit(initialBalance, DateTime.Now, "Depósito inicial.");
        }

        private List<Transaction> _allTransations = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor do depósito deve ser maior do que zero.");
            }

            Transaction deposit = new(amount, date, note);
            _allTransations.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor do saque deve ser maior do que zero.");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar este saque.");
            }

            Transaction withdrawal = new(-amount, date, note);
            _allTransations.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            StringBuilder history = new();

            decimal balance = 0;
            history.AppendLine("\nDATE\t\t\tAMOUNT\tBALANCE\tNOTE");

            foreach (Transaction transaction in _allTransations)
            {
                balance += transaction.Amount;
                history.AppendLine($"{transaction.Date}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
            }

            return history.ToString();
        }
    }
}

using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace OOP_Bank_Example
{
    public class BankAccount
    {
        public Guid Number { get; }
        private readonly string _owner;
        private readonly decimal _minimumBalance;

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var transaction in _allTransactions)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }

        public BankAccount(string name, decimal initialBalance, decimal minimumBalance = 0)
        {
            Number = Guid.NewGuid();
            _owner = name;
            _minimumBalance = minimumBalance;

            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Depósito inicial.");
        }

        private List<Transaction> _allTransactions = new List<Transaction>();

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor do depósito deve ser maior do que zero.");
            }

            Transaction deposit = new(amount, date, note);
            _allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor do saque deve ser maior do que zero.");
            }

            Transaction? overdraftTransaction = CheckWithDrawalLimit(Balance - amount < _minimumBalance);       
            Transaction withdrawal = new(-amount, date, note);
            _allTransactions.Add(withdrawal);

            if (overdraftTransaction != null)
                _allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithDrawalLimit(bool isOverDrawal)
        {
            if (isOverDrawal)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar este saque.");
            }
            else
            {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            StringBuilder history = new();

            decimal balance = 0;
            history.AppendLine($"\nCustomer: {_owner}\n\nDATE\t\t\tAMOUNT\tBALANCE\tNOTE");

            foreach (Transaction transaction in _allTransactions)
            {
                balance += transaction.Amount;
                history.AppendLine($"{transaction.Date}\t{transaction.Amount}\t{balance}\t{transaction.Notes}");
            }

            return history.ToString();
        }

        public virtual void EndMonthTask()
        {
            Console.WriteLine($"Rotina do Final do Mês de {(MonthsConvert)new DateTime().Month} foi concluída!");
        }
    }
}

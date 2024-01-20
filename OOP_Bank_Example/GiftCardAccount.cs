using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Bank_Example
{
    public class GiftCardAccount : BankAccount
    {
        private readonly decimal _monthlyDeposit;
        public GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit = 0) : base(name, initialBalance)
            => _monthlyDeposit = monthlyDeposit;

        public override void EndMonthTask()
        {
            if (_monthlyDeposit > 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, $"Recarga de final do mês [{(MonthsConvert)new DateTime().Month}]");
            }

            base.EndMonthTask();
        }
    }
}

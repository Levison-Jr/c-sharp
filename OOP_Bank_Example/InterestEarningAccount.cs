using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Bank_Example
{
    public class InterestEarningAccount : BankAccount
    {
        public InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
            
        }

        public override void EndMonthTask()
        {
            if (Balance > 500m)
            {
                decimal valorDeGanhoEmJuros = Balance * (2m / 100);
                MakeDeposit(valorDeGanhoEmJuros, DateTime.Now, $"Juros do mês [{(MonthsConvert)new DateTime().Month}]");
            }

            base.EndMonthTask();
        }
    }
}

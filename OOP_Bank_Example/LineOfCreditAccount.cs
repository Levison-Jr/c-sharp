namespace OOP_Bank_Example
{
    public class LineOfCreditAccount(string name, decimal initialBalance, decimal creditLimit) : BankAccount(name, initialBalance, -creditLimit)
    {
        public override void EndMonthTask()
        {
            if (Balance < 0)
            {
                decimal taxaDeJurosParaDebitar = -Balance * 0.07m;
                MakeWithdrawal(taxaDeJurosParaDebitar, DateTime.Now, $"Taxa de juros mês [{(MonthsConvert)new DateTime().Month}]");
            }

            base.EndMonthTask();
        }

        protected override Transaction? CheckWithDrawalLimit(bool isOverDrawal) =>
            isOverDrawal
            ? new Transaction(-20, DateTime.Now, "Taxa de ultrapassagem de limite de crédito.")
            : default;
    }
}

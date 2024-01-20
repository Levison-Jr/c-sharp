namespace OOP_Bank_Example
{
    public class LineOfCreditAccount(string name, decimal initialBalance) : BankAccount(name, initialBalance)
    {
        public override void EndMonthTask()
        {
            if (Balance < 0)
            {
                decimal taxaDeJurosParaDebitar = -Balance * 0.07m;
                MakeWithdrawal(-taxaDeJurosParaDebitar, DateTime.Now, $"Taxa de juros mês [{(MonthsConvert)new DateTime().Month}]");
            }

            base.EndMonthTask();
        }
    }
}

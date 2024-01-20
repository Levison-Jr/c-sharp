namespace OOP_Bank_Example
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                GiftCardAccount customer_1 = new("John Doe", 200, 35.5m);
                Console.WriteLine(customer_1.Balance);

                customer_1.MakeDeposit(200, DateTime.Now, "Reservas");
                Console.WriteLine(customer_1.Balance);

                customer_1.MakeWithdrawal(150m, DateTime.Now, "Contas");
                Console.WriteLine(customer_1.Balance);

                customer_1.EndMonthTask();

                Console.WriteLine(customer_1.GetAccountHistory());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Um erro foi detectado nas movimentações da conta!");
                Console.WriteLine(e.Message);
            }
        }
    }
}

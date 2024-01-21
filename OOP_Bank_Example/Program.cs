namespace OOP_Bank_Example
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                LineOfCreditAccount customer_1 = new("John Doe", 0, 200);

                customer_1.MakeWithdrawal(201, DateTime.Now, "Contas");
                customer_1.MakeDeposit(200, DateTime.Now, "Reservas");


                customer_1.EndMonthTask();

                Console.WriteLine(customer_1.GetAccountHistory());
            }
            catch (Exception e)
            {
                Console.WriteLine("Um erro foi detectado nas movimentações da conta!");
                Console.WriteLine(e.Message);
            }
        }
    }
}

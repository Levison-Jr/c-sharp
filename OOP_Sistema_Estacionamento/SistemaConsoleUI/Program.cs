using SistemaEstacionamentoLibrary;

namespace SistemaConsoleUI;

public class ConsoleUI
{
    public static void Main()
    {
        Veiculo v1 = new("Branco", "Ford", "QKZ-A238", 149.97m);
        Console.WriteLine(v1.Placa);
    }
}

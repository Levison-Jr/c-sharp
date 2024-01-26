namespace SistemaEstacionamentoLibrary
{
    public class Veiculo
    {
        private readonly Guid _id;
        public bool Alugado = false;

        public string? Cor { get; set; }
        public string? Modelo { get; set; }
        public string Placa { get; set; }
        public decimal CustoAluguelPorDia { get; set; }
        public DateTime InicioAluguel { get; set; }
        public DateTime FimAluguel { get; set; }

        public Veiculo(string? cor, string? modelo, string placa, decimal custoAluguelPorDia)
        {
            _id = new Guid();
            Cor = cor;
            Modelo = modelo;
            Placa = placa;
            CustoAluguelPorDia = custoAluguelPorDia;
        }
    }
}

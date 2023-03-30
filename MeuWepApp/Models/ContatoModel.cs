namespace MeuWepApp.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }

        public ContatoModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            Celular = string.Empty;
        }
    }
}

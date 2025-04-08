namespace MyApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } // Gerado automaticamente
        public string Nome { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; } // Armazena o hash da senha
        public string NiveisUsuario { get; set; } // Pode ser uma string ou enum
    }
}

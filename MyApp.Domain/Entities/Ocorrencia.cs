using System.Text.Json.Serialization;

namespace MyApp.Domain.Entities
{
    public class Ocorrencia
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public User? Usuario { get; set; }
    }
}

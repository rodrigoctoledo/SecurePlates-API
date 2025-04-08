using System;
using System.Text.Json.Serialization;

namespace MyApp.Domain.Entities
{
    public class Plate
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Local { get; set; }
        public DateTime Horario { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public User? Usuario { get; set; }
    }
}

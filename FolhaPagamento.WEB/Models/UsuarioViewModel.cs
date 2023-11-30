using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Models
{
    public class UsuarioViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("Nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        [JsonPropertyName("senha")]
        public string? Senha { get; set; }

        [JsonPropertyName("dataRegistro")]
        public DateTime? DataRegistro { get; set; }
    }
}
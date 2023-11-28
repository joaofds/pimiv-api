using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Models
{
    public class CargoViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("salario")]
        public float? Salario { get; set; }
    }
}
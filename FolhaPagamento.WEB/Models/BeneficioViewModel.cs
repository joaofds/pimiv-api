using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Models
{
    public class BeneficioViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("valorBeneficio")]
        public float? ValorBeneficio { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Models
{
    public class ColaboradorViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("cargoId")]
        public int? cargoId { get; set; }

        [JsonPropertyName("nome")]
        public string? nome { get; set; }

        [JsonPropertyName("cpf")]
        public string? cpf { get; set; }

        [JsonPropertyName("dataAdmissao")]
        public DateTime? dataAdmissao { get; set; }

        [JsonPropertyName("dataSaida")]
        public DateTime? dataSaida { get; set; }

        [JsonPropertyName("status")]
        public byte? Status { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Models
{
    public class ColaboradorViewModel
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("CargoId")]
        public int CargoId { get; set; }

        [JsonPropertyName("nome")]
        public string? nome { get; set; }

        [JsonPropertyName("cpf")]
        public string? cpf { get; set; }

        [JsonPropertyName("dataAdmissao")]
        public string? dataAdmissao { get; set; }

        [JsonPropertyName("dataSaida")]
        public string? dataSaida { get; set; }
    }
}
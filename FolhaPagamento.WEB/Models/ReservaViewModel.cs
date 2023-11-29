using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FolhaPagamento.WEB.Models
{
    public class ReservaViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("responsavel")]
        public string? Responsavel { get; set; }

        [JsonPropertyName("dataReserva")]
        public DateTime? DataReserva { get; set; }

        [JsonPropertyName("espaco")]
        public int Espaco { get; set; }

        [JsonPropertyName("qtdeHoras")]
        public int QtdeHoras { get; set; }

        [JsonPropertyName("valor")]
        public decimal? Valor { get; set; }

        [JsonPropertyName("confirmado")]
        public byte? Confirmado { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }
}
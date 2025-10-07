using System.ComponentModel.DataAnnotations;

namespace FiapFinBank.Api.Models
{
    public class Transacao
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Tipo { get; set; } = string.Empty;

        public decimal Valor { get; set; }
        public DateTime Data { get; set; }

        public int ContaBancariaId { get; set; }
        public ContaBancaria ContaBancaria { get; set; } = null!;
    }
}

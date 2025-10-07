using System.ComponentModel.DataAnnotations;

namespace FiapFinBank.Api.Models
{
    public class ContaBancaria
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string NumeroConta { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Agencia { get; set; } = string.Empty;

        [MaxLength(20)]
        public string TipoConta { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}

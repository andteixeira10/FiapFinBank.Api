namespace FiapFinBank.Api.Models
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public string NumeroConta { get; set; } = string.Empty;
        public string Agencia { get; set; } = string.Empty;
        public string TipoConta { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}

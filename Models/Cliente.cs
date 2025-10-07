namespace FiapFinBank.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<ContaBancaria> Contas { get; set; } = new List<ContaBancaria>();
    }
}

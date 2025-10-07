using System.ComponentModel.DataAnnotations;

namespace FiapFinBank.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string NomeCompleto { get; set; } = string.Empty;

        [MaxLength(11)]
        public string Cpf { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        public ICollection<ContaBancaria> Contas { get; set; } = new List<ContaBancaria>();
    }
}

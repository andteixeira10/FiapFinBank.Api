namespace FiapFinBank.Api.Dtos;

public class ClienteCreateDto
{
    public string NomeCompleto { get; set; } = null!;
    public string Cpf { get; set; } = null!;
    public string Email { get; set; } = null!;
}

using FiapFinBank.Api.Data;
using FiapFinBank.Api.Dtos;
using FiapFinBank.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiapFinBank.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ClientesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Clientes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
    {
        return await _context.Clientes
            .Include(c => c.Contas)
            .ThenInclude(cb => cb.Transacoes)
            .ToListAsync();
    }

    // GET: api/Clientes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Cliente>> GetCliente(int id)
    {
        var cliente = await _context.Clientes
            .Include(c => c.Contas)
            .ThenInclude(cb => cb.Transacoes)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cliente == null)
            return NotFound();

        return cliente;
    }

    // POST: api/Clientes
    [HttpPost]
    public async Task<ActionResult<Cliente>> PostCliente(ClienteCreateDto dto)
    {
        var cliente = new Cliente
        {
            NomeCompleto = dto.NomeCompleto,
            Cpf = dto.Cpf,
            Email = dto.Email
        };

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    // PUT: api/Clientes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCliente(int id, ClienteCreateDto dto)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return NotFound();

        cliente.NomeCompleto = dto.NomeCompleto;
        cliente.Cpf = dto.Cpf;
        cliente.Email = dto.Email;

        _context.Entry(cliente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Clientes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCliente(int id)
    {
        var cliente = await _context.Clientes.FindAsync(id);
        if (cliente == null)
            return NotFound();

        _context.Clientes.Remove(cliente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

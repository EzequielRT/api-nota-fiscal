using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Domain.Repositories;
using Magma3.NotaFiscal.Domain.ValueObjects;
using Magma3.NotaFiscal.Infra.Data.Context;

namespace Magma3.NotaFiscal.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly NotaFiscalDbContext _context;

        public ClienteRepository(NotaFiscalDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarClienteAsync(Cliente cliente, CancellationToken cancellationToken = default)
        {
            await _context.Clientes.AddAsync(cliente, cancellationToken);
        }

        public async Task AdicionarClienteCelularAsync(Celular celular, CancellationToken cancellationToken = default)
        {
            await _context.Celulares.AddAsync(celular, cancellationToken);
        }

        public async Task AdicionarClienteEnderecoAsync(Endereco endereco, CancellationToken cancellationToken = default)
        {
            await _context.Enderecos.AddAsync(endereco, cancellationToken);
        }
    }
}
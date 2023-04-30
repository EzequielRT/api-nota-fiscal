using Magma3.NotaFiscal.Domain.Entities;
using Magma3.NotaFiscal.Infra.Data.UoW;
using MediatR;

namespace Magma3.NotaFiscal.Application.Commands.RegistrarNotaFiscal
{
    public class RegistrarNotaFiscalCommandHandler : IRequestHandler<RegistrarNotaFiscalCommand, Guid>
    {
        private readonly IUnitOfWork _uow;

        public RegistrarNotaFiscalCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Guid> Handle(RegistrarNotaFiscalCommand request, CancellationToken cancellationToken)
        {
            await _uow.BeginTransactionAsync();

            var cliente = request.Cliente.ToEntity();
            await _uow.Clientes.AdicionarClienteAsync(cliente);
            await _uow.CompleteAsync();

            var endereco = request.Endereco.ToEntity(cliente.Id);
            await _uow.Clientes.AdicionarClienteEnderecoAsync(endereco);
            await _uow.CompleteAsync();

            var celular = request.Celular.ToEntity(cliente.Id);
            await _uow.Clientes.AdicionarClienteCelularAsync(celular);
            await _uow.CompleteAsync();

            var produto = request.Produto.ToEntity();
            await _uow.Produtos.AdicionarProdutoAsync(produto);
            await _uow.CompleteAsync();

            var notaFiscal = request.NotaFiscal.ToEntity(cliente.Id);
            await _uow.NotasFiscais.AdicionarNotaFiscalAsync(notaFiscal);
            await _uow.CompleteAsync();

            await _uow.NotasFiscais
                .AdicionarProdutoNaNotaFiscalAsync(
                    new NotaFiscalProduto(notaFiscal.Id, 
                    produto.Id, 
                    produto.ProdutoPreco, 
                    request.DataCompra
                 ));

            await _uow.CompleteAsync();

            await _uow.CommitAsync();

            return notaFiscal.UId;
        }
    }
}
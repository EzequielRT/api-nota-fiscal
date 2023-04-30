using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Application.DTOs
{
    public class NotaFiscalViewModel
    {
        public NotaFiscalViewModel(Guid notaUId, string numeroNota, Guid clienteUId, string nomeCliente, string chaveAcesso, DateTime dataEmissao, List<ProdutoViewModel> produtos)
        {
            NotaFiscalUId = notaUId;
            NumeroNota = numeroNota;
            ClienteUId = clienteUId;
            NomeCliente = nomeCliente;
            ChaveAcesso = chaveAcesso;
            DataEmissao = dataEmissao;
            Produtos = new List<ProdutoViewModel>(produtos);
        }

        public Guid NotaFiscalUId { get; set; }
        public string NumeroNota { get; set; }
        public Guid ClienteUId { get; set; }
        public string NomeCliente { get; set; }
        public string ChaveAcesso { get; set; }
        public DateTime DataEmissao { get; set; }
        public List<ProdutoViewModel> Produtos { get; set; }

        public static NotaFiscalViewModel FromEntity(Domain.Entities.NotaFiscal nf)
        {
            return new NotaFiscalViewModel(
                nf.UId,
                nf.NumeroNota,
                nf.Cliente.UId,
                nf.Cliente.NomeCliente,
                nf.ChaveAcesso,
                nf.DataEmissao,
                nf.Produtos.Select(x => new ProdutoViewModel(
                    x.ProdutoId,
                    x.Produto.Descricao,
                    x.ProdutoPreco,
                    x.DataCompra)).ToList());
        }
    }
}
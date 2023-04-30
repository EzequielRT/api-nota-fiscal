namespace Magma3.NotaFiscal.Application.DTOs
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel(int produtoId, string produtoDescricao, decimal produtoPreco, DateTime dataCompra)
        {
            ProdutoId = produtoId;
            ProdutoDescricao = produtoDescricao;
            ProdutoPreco = produtoPreco;
            DataCompra = dataCompra;
        }

        public int ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoPreco { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
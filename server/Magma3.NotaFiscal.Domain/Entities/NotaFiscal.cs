using Magma3.NotaFiscal.Domain.Entities.Base;

namespace Magma3.NotaFiscal.Domain.Entities
{
    public class NotaFiscal : BaseEntity
    {
        public NotaFiscal() { }

        public NotaFiscal(string numeroNota, int clienteId, string chaveAcesso, DateTime dataEmissao)
        {
            NumeroNota = numeroNota;
            ClienteId = clienteId;
            ChaveAcesso = chaveAcesso;
            DataEmissao = dataEmissao;

            Produtos = new List<NotaFiscalProduto>();
        }

        public string NumeroNota { get; set; }
        public string ChaveAcesso { get; set; }
        public DateTime DataEmissao { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual List<NotaFiscalProduto> Produtos { get; set; }
    }
}
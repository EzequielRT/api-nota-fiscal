using Magma3.NotaFiscal.Domain.Entities;

namespace Magma3.NotaFiscal.Domain.ValueObjects
{
    public class Celular
    {
        public Celular() { }

        public Celular(string numeroCelular, int clienteId)
        {
            CelularNumero = numeroCelular;
            ClienteId = clienteId;
        }

        public int Id { get; set; }
        public string CelularNumero { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Celular celular &&
                   CelularNumero == celular.CelularNumero;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CelularNumero);
        }
    }
}
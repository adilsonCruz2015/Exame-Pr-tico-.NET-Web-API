using Seguro.BackEnd.Dominio.Entidade;
using System;

namespace Seguro.BackEnd.Dominio.ObjetoDeValor
{
    public class Seguro
    {
        private const decimal MARGEM_SEGURANCA = 3;

        private const decimal LUCRO = 5;

        protected Seguro()
        {
            Id = Guid.NewGuid();
        }

        public Seguro(Veiculo veiculo, 
                      Segurado segurado)
            : this()
        {
            Veiculo = veiculo;
            Segurado = segurado;
        }

        public Seguro(Veiculo veiculo)
            :this(veiculo, null) {  }

        public Guid Id { get; private set; }

        public Veiculo Veiculo { get; private set; }

        public Segurado Segurado { get; private set; }

        public decimal TaxaDeRisco { get; private set; }

        public decimal PremioDeRisco { get; private set; }

        public decimal PremidoPuro { get; private set; }

        public decimal PremioComercial { get; private set; }

        public decimal CalcularSeguro()
        {
            TaxaDeRisco = (Veiculo.ValorVeiculo * 5) / (2 / Veiculo.ValorVeiculo) / 100;
            PremioDeRisco = TaxaDeRisco * Veiculo.ValorVeiculo;
            PremidoPuro = PremioDeRisco * (1 + (MARGEM_SEGURANCA / 100));
            PremioComercial = ((LUCRO / 100) * PremidoPuro) + PremidoPuro;

            return PremioComercial;
        }
    }
}

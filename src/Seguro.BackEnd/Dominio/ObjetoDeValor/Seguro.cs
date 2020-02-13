using Seguro.BackEnd.Dominio.Entidade;


namespace Seguro.BackEnd.Dominio.ObjetoDeValor
{
    public class Seguro
    {
        private const double MARGEM_SEGURANCA = 0.03;

        private const double LUCRO = 0.05;

        public Seguro(Veiculo veiculo, Segurado segurado)
        {
            Veiculo = veiculo;
            Segurado = segurado;
        }

        public Veiculo Veiculo { get; private set; }

        public Segurado Segurado { get; private set; }

        public double TaxaDeRisco { get; private set; }

        public double PremioDeRisco { get; private set; }

        public double PremidoPuro { get; private set; }

        public double PremioComercial { get; private set; }

        public double CalcularSeguro()
        {
            TaxaDeRisco = (Veiculo.ValorVeiculo * 5) / (2 / Veiculo.ValorVeiculo) / 100;
            PremioDeRisco = TaxaDeRisco * Veiculo.ValorVeiculo;
            PremidoPuro = PremioDeRisco * (1 + MARGEM_SEGURANCA);
            PremioComercial = (LUCRO * PremidoPuro) + PremidoPuro;

            return PremioComercial;
        }
    }
}

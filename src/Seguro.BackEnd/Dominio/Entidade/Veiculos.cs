using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.BackEnd.Dominio.Entidade
{
    public class Veiculos
    {
        public Veiculos(double valorVeiculo)
        {
            ValorVeiculo = valorVeiculo;
        }

        private const double MARGEM_SEGURANCA = 0.03;

        private const double LUCRO = 0.05;

        private double _valorVeiculo;
        public double ValorVeiculo
        {
            get { return _valorVeiculo; }
            set
            {
                if(value > 0)
                {
                    _valorVeiculo = value;

                    TaxaDeRisco = (_valorVeiculo * 5) / (2 / _valorVeiculo) /100;
                    PremioDeRisco = TaxaDeRisco * _valorVeiculo;
                    PremidoPuro = PremioDeRisco * (1 + MARGEM_SEGURANCA);
                    PremioComercial = (LUCRO * PremidoPuro) + PremidoPuro;

                }
            }
        }

        public double TaxaDeRisco { get; private set; }

        public double PremioDeRisco { get; private set; }

        public double PremidoPuro { get; private set; }

        public double PremioComercial { get; private set; }
    }
}

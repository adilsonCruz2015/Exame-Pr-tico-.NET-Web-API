using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguro.BackEnd.Dominio.Commando.SeguroCmd
{
    public class FiltrarCmd
    {
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public decimal ValorVeiculo { get; set; }
    }
}


using System;

namespace Seguro.BackEnd.Dominio.Entidade
{
    public class Veiculo
    {
        protected Veiculo()
        {
            Id = Guid.NewGuid();
        }

        public Veiculo(decimal valorVeiculo,
                       string marca,
                       string modelo
            ) : this()
        {
            ValorVeiculo = valorVeiculo;
            Marca = marca;
            Modelo = modelo;
        }        
        
        public Guid Id { get; private set; }

        public decimal ValorVeiculo { get; private set; }        

        public string Marca { get; private set; }

        public string Modelo { get; private set; }
    }
}

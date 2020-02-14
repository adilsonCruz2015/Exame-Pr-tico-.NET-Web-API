
using System;

namespace Seguro.BackEnd.Dominio.Entidade
{
    public class Segurado
    {
        protected Segurado()
        {
            Id = Guid.NewGuid();
        }

        public Segurado(string nome, 
                        string cpf, 
                        int idade)
            : this()
        {            
            Nome = nome;
            Cpf = cpf;
            Idade = idade;

        }

        public Guid Id { get; private set; }

        public string Nome { get; private set; }

        public string Cpf { get; private set; }

        public int Idade { get; private set; }        
    }
}

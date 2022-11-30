using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    public class Cliente
    {
        public Cliente(string cpf, string nome)
        {
            CPF = cpf;
            Nome = nome;
        }

        public string CPF { get; private set; }
        public string Nome { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente && CPF == cliente.CPF;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

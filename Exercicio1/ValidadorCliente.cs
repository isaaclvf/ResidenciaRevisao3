using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class ValidadorCliente
    {
        private List<ErroCliente> listaErros;

        public ValidadorCliente()
        {
            listaErros = new List<ErroCliente>();
        }

        public bool IsValido(Dictionary<string, string> cliente) 
        {
            int propValidas = 6;
            var erroObj = new ErroCliente(cliente);

            // Nome - Pelo menos 5 caracteres
            var nome = cliente["nome"];
            if (nome.Length < 5 || nome == null)
            {
                erroObj.AddErro("nome", "nome inválido");
                propValidas--;
            }

            // CPF - Algoritmo de validação
            var cpf = cliente["cpf"];

            if (cpf == null || !CpfValido(cpf)) 
            {
                erroObj.AddErro("cpf", "cpf inválido");
                propValidas--;
            }

            // Data de nascimento - Pelo menos 18 anos
            var dtNascimento = cliente["dt_nascimento"];
            var dtParsed = DateTime.Parse(dtNascimento);

            var idade = DateTime.Today - dtParsed;
            var maior = (idade.TotalDays / 365) > 18;


            if (dtNascimento == null || !maior)
            {
                erroObj.AddErro("dt_nascimento", "data de nascimento inválida");
                propValidas--;
            }

            // Renda mensal - >= 0
            var rendaMensal = cliente["renda_mensal"];

            if (Int32.TryParse(rendaMensal, out int renda))
            {
                if (renda < 0)
                {
                    erroObj.AddErro("renda_mensal", "renda mensal inválida");
                    propValidas--;
                }
            }
            else
            {
                erroObj.AddErro("renda_mensal", "renda mensal inválida");
                propValidas--;
            }

            // Estado civil - C, S, V ou D
            var estadoCivil = cliente["estado_civil"];
            var estadoChar = estadoCivil.ToLower()[0];

            if (estadoChar != 'c' || estadoChar != 's' || estadoChar != 'v' || estadoChar== 'd')
            {
                erroObj.AddErro("estado_civil", "estado civil inválida");
                propValidas--;
            }

            // Dependentes - 0 a 10
            var dependentes = cliente["dependentes"];

            if (Int32.TryParse(dependentes, out int d))
            {
                if (!(d >= 0 || d <= 10))
                {
                    erroObj.AddErro("dependentes", "dependentes inválido");
                    propValidas--;
                }
            }
            else
            {
                erroObj.AddErro("dependentes", "dependentes inválido");
                propValidas--;
            }

            if (propValidas != 6) listaErros.Add(erroObj);
            return (propValidas == 6);
        }

        private bool CpfValido(string cpf) 
        {
            // 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Todos iguais
            if (cpf.All(digito => digito == cpf[0]))
                return false;

            // Checar primeiro dígito verificador (j)
            int j = 0;
            int somaJ = 0;
            for (int i = 0; i < 9; i++)
                somaJ += (int)Char.GetNumericValue(cpf[i]) * (10 - i);

            if (!(somaJ % 11 == 0 || somaJ % 11 == 1))
                j = 11 - (somaJ % 11);

            if ((int)Char.GetNumericValue(cpf[9]) != j)
                return false;

            // Checar segundo dígito verificador (k)
            int k = 0;
            int somaK = 0;
            for (int i = 0; i < 9; i++)
                somaK += (int)Char.GetNumericValue(cpf[i]) * (11 - i);

            if (!(somaK % 11 == 0 || somaK % 11 == 1))
                k = 11 - (somaK % 11);

            if ((int)Char.GetNumericValue(cpf[10]) != k)
                return false;

            return true;
        }

        public List<ErroCliente>? GetErros()
        {
            return listaErros;
        }
    }
}

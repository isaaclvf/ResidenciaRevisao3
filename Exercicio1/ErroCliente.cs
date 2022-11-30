using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class ErroCliente
    {
        private readonly Dictionary<string, string> dados;
        private Dictionary<string, string> erros;

        public ErroCliente(Dictionary<string, string> dadosCliente) 
        {
            dados = dadosCliente;
            erros = new Dictionary<string, string>();
        }

        public void AddErro(string campoErro, string msgErro) 
        { 
            erros[campoErro] = msgErro;
        }

        public Dictionary<string, string> GetErro()
        {
            return erros;
        }

        public Dictionary<string, string> GetDados()
        {
            return dados;
        }
    }
}

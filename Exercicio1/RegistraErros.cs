using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class RegistraErros
    {
        static public void EscreveJson(List<ErroCliente> erros, string path)
        {
            var listaMensagensErro = new List<Dictionary<string, Dictionary<string, string>>>();

            foreach (var e in erros)
            {
                var mensagemErro = new Dictionary<string, Dictionary<string, string>>();
                mensagemErro["dados"] = e.GetDados();
                mensagemErro["erros"] = e.GetErro();

                listaMensagensErro.Add(mensagemErro);
            }

            var jsonDados = JsonSerializer.Serialize(listaMensagensErro);
            File.WriteAllText(path, jsonDados);
        }
    }
}

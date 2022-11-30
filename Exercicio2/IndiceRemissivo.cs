using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercicio2
{
    public class IndiceRemissivo
    {
        private Dictionary<string, List<int>> indice;
        public IndiceRemissivo(string pathTXT, string? pathIgnore = null) 
        {
            indice = new Dictionary<string, List<int>>();
            int numeroDaLinha = 1;

            foreach (string line in File.ReadLines(pathTXT))
            {
                var palavraRe = new Regex("([a-zA-Z]+)");

                // https://stackoverflow.com/questions/11416191/converting-a-matchcollection-to-string-array
                var palavras = palavraRe.Matches(line)
                    .Cast<Match>()
                    .Select(m => m.Value)
                    .ToArray();

                foreach (var palavra in palavras) { 
                    if (indice.ContainsKey(palavra))
                        indice[palavra].Add(numeroDaLinha);
                    else
                        indice.Add(palavra, new List<int>(numeroDaLinha));
                }

                numeroDaLinha++;
            }
        }

        public void Imprime()
        {
            var indiceOrdenado = indice.OrderBy(m => m.Key).ToList();
            foreach (var item in indiceOrdenado)
            {
                string palavra = item.Key.ToUpper();
                string contagemStr = "(" + item.Value.Count().ToString() + ")";

                List<int> linhas = item.Value; // TODO: Criar método para remover repetidos

                string linhasStr = String.Join(", ", linhas);

                Console.WriteLine(palavra + " " + contagemStr + " " + linhasStr);
            }
        }
    }
}

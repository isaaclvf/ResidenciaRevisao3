using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio4
{
    public static class Removido
    {
        public static List<T> RemoveRepetido<T>(this List<T> lista)
        {
            var novaLista = new List<T>();

            for (int i = 0; i < lista.Count; i++)
            {
                if (!(novaLista.Contains(lista[i])))
                {
                    novaLista.Add(lista[i]);
                }
            }

            return novaLista;
        }
    }
}

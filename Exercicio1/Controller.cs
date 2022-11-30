using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public class Controller
    {
        public static void Start(string path)
        {
            var leitor = new LeitorClienteJson(path);
            var validador = new ValidadorCliente();

            var clientes = leitor.GetClientes();

            if (clientes == null)
                throw new Exception("Erro ao ler clientes do arquivo JSON");

            foreach (var cliente in clientes)
            {
                if (validador.IsValido(cliente))
                {
                    // Criar instancia de Cliente e salvar numa lista, por exemplo
                }
            }

            var erros = validador.GetErros();
            if (erros != null)
                RegistraErros.EscreveJson(erros);
        }
    }
}

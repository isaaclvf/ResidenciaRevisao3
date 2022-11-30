using System.Text.Json;

namespace Exercicio1
{
    public class LeitorClienteJson
    {
        private readonly List<Dictionary<string, string>> clientes;
        
        public LeitorClienteJson(string path)
        {
            clientes = new List<Dictionary<string, string>>();

            string data = File.ReadAllText(path);

            using JsonDocument doc = JsonDocument.Parse(data);
            JsonElement root = doc.RootElement;

            var rootLength = root.GetArrayLength();
            for (int i = 0; i < rootLength; i++)
            {
                var clienteDict = JsonSerializer.Deserialize<Dictionary<string, string>>(root[i]);
                if (clienteDict != null)
                    clientes.Add(clienteDict);
            }
        }

        public List<Dictionary<string, string>> GetClientes()
        {
            return clientes;
        }
    }
}
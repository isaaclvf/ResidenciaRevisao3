using Exercicio4;

var listaInteiros = new List<int>() { 1, 2, 3, 3, 4 };
var novaListaInterios = listaInteiros.RemoveRepetido();

for (int i = 0; i < novaListaInterios.Count; i++)
    Console.WriteLine(novaListaInterios[i]);

var listaStrings = new List<string>() { "um", "dois", "tres", "tres", "quatro" };
var novaListaStrings = listaStrings.RemoveRepetido();

for (int i = 0; i < novaListaStrings.Count; i++)
    Console.WriteLine(novaListaStrings[i]);

var listaClientes = new List<Cliente>();
listaClientes.Add(new Cliente("000000000", "A"));
listaClientes.Add(new Cliente("111111111", "B"));
listaClientes.Add(new Cliente("222222222", "C"));
listaClientes.Add(new Cliente("222222222", "D"));
listaClientes.Add(new Cliente("333333333", "E"));

var novaListaClientes = listaClientes.RemoveRepetido();

for (int i = 0; i < novaListaClientes.Count; i++)
    Console.WriteLine(novaListaClientes[i].CPF + " - " + novaListaClientes[i].Nome);
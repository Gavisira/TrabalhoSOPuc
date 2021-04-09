using System;

namespace TrabalhoSO
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorPedidos gerenciador = new GerenciadorPedidos(@"C:\Users\gabri\source\repos\TrabalhoSO\TrabalhoSO\Empacotadeira.txt");
            Console.Read();
        }
    }
}

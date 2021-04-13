using System;

namespace TrabalhoSO
{
    /*Um pacote deve ter obrigatoriamente 20 produtos?​
    -Deixou mistério ("5000cm³"), então vamos ter que nos virar​

    Cada pacote é destinado exclusivamente pra 1 cliente ou pode ser colocado tudo de todos em um pacote?​
    -Cada pacote é exclusivo​
    
    Adicionar uma thread faz diferença pro processador (braço mecânico), ou seja, o braço aguenta trabalhar em 2 threads?​
    -Cada esteira é um conjunto "esteira-braço", então não faz diferença se ele aguenta ou não​
    */

    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorPedidos gerenciador = new GerenciadorPedidos(@"C:\Users\gabri\source\repos\TrabalhoSO\TrabalhoSO\Empacotadeira.txt");
            Console.Read();
        }
    }
}

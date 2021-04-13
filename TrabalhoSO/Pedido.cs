using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrabalhoSO
{
    public class Pedido
    {
        public string cliente;
        public int qtdProdutos;
        public int prazoPrioridade;
        public List<Pacote> pacotes = new List<Pacote>();

        public Pedido(string nome, int produtos, int prazo)
        {
            this.cliente = nome;
            this.qtdProdutos = produtos;
            this.prazoPrioridade = prazo;
        }


        public void Realizar()
        {
            Console.WriteLine("Total de produtos: " + qtdProdutos);
            int count = 0;
            Esteira esteira = new Esteira();
            while (esteira.realizado < qtdProdutos)
            {
                Thread.Sleep(1000);
                pacotes.Add(esteira.Empacotar(qtdProdutos));
                Console.WriteLine("Pacote " + count);
                count++;
            }
        }
    }
}

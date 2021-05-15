using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO
{
    public class Esteira
    {
        public int realizado=0;
        public int produtoPorPacote;
        public List<Produto> pacote;

        public Esteira ()
        {
            produtoPorPacote = 20;
            pacote = new List<Produto>(produtoPorPacote);
        }

        public Pacote Empacotar(int qtdProdutos){
            Pacote novo = new Pacote();
            GerenciadorPedidos.tempoExecucao += 0.5; // tempo de transição entre pacotes na esteira = 0.5s
            GerenciadorPedidos.VerificaTempo(); // verifica o tempo atual, para verificar se há pedidos a serem inseridos na lista naquele tempo de execução
            for(int i = 0;i<produtoPorPacote;i++){ // roda até que todos os produtos estejam empacotados
                if(realizado<qtdProdutos){
                    novo.produtos.Add(new Produto());
                    realizado++;
                }
            }
            for(int i = 0;i<10;i++){  // roda verificando se houve entrada de novos pedidos durante a exeucação do pedido atual
                GerenciadorPedidos.tempoExecucao += 0.5; // adiciona 0.5s, pra que sempre haja a verificação
                GerenciadorPedidos.VerificaTempo();
            }
            
            return novo;
        }
    }
}
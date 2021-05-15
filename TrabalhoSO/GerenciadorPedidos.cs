using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoSO
{
    class GerenciadorPedidos
    {
        public static double tempoExecucao = 0.0; //Contabiliza tempo de execução 
        public int qtdPedidos;
        public List<Pedido> pedidos;
        public List<Pedido> insercao; //Lista para definição de tempo de entrada

        public GerenciadorPedidos(string path)
        {

            CriarListaTempoExecucao(path);
            OrdenarTempoEntrada();
            VerificaTempo();
            OrdenaPorPrioridade();
            IniciarProcesso();
            Console.ReadLine();
        }


        private void IniciarProcesso()
        {
           while(pedidos.Count>0){
               pedidos(0).Realizar(); // realiza o empacotamento do pedido na primeira posição
               pedidos(0).Remove(); // retira o pedido realizado da lista de pedidos
               OrdenaPorPrioridade();
           }
        }

        private void OrdenarTempoEntrada()
        {
            insercao = insercao.OrderBy(x => x.tempoEntrada).ToList();
        }

        #region Criar Lista de prioridade de Pedidos
        public void OrdenaPorPrioridade()
        {
            pedidos = pedidos.OrderBy(x => x.prazoPrioridade).ThenBy(x => x.qtdProdutos).ToList();
        }

        public void VerificaTempo()
        {
            if (insercao.tempoEntrada == tempoExecucao)
            { // testa se está no momento do pedido entrar na lista
                foreach (Pedido pedido in insercao) // roda inserindo dentro da lista todos os pedidos que chegaram no tempo de execução atual
                {
                    if (pedido.tempoEntrada != tempoExecucao) // se o tempo  de entrada do pedido atual da lista for diferente do tempo de execução atual, para as inserções
                    { 
                        break;
                    }
                    pedidos.Add(pedido); // insere o pedido que estava na lista de inserção dentro da lista de pedidos a executar
                    insercao.Remove(pedido); // remove o pedido da lista de inserção
                }
                OrdenaPorPrioridade(); // ordena a lista de pedidos a cada vez que pelo menos 1 pedido entra
            }
        }


        private void CriarListaTempoExecucao(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {

                        String linha;


                        qtdPedidos = Int32.Parse(sr.ReadLine());
                        insercao = new List<Pedido>(qtdPedidos);

                        string[] splitter = new string[4];

                        while ((linha = sr.ReadLine()) != null)
                        {
                            splitter = linha.Split(";");
                            if (Int32.Parse(splitter[2]) == 0)
                            {
                                insercao.Add(new Pedido(splitter[0], Int32.Parse(splitter[1]), Int32.MaxValue, Double.Parse(splitter[3])));
                            }
                            else insercao.Add(new Pedido(splitter[0], Int32.Parse(splitter[1]), Int32.Parse(splitter[2]), Double.Parse(splitter[3])));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine(" O arquivo " + path + " não foi localizado");
            }
        }
        #endregion
    }
}

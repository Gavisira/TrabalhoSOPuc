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
        public int qtdPedidos;
        public List<Pedido> pedidos;

        public GerenciadorPedidos(string path)
        {
            CriarListaPedidos(path);
            OrdenaPorPrioridade(this.pedidos);
            IniciarProcesso();
            Console.ReadLine();
        }


        private void IniciarProcesso()
        {
            int numero = 1;
            foreach (Pedido pedido in pedidos)
            {
                Console.WriteLine("Pedido numero " + numero);
                Console.WriteLine("Prazo do pedido " + pedido.prazoPrioridade);
                pedido.Realizar();
                numero++;
            }
        }


        #region Criar Lista ordenada de Pedidos
        private void OrdenaPorPrioridade(List<Pedido> pedidos)
        {
            this.pedidos = pedidos.OrderBy(x => x.prazoPrioridade).ThenBy(x => x.qtdProdutos).ToList();
        }


        private void CriarListaPedidos(string path)
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {

                        String linha;


                        qtdPedidos = Int32.Parse(sr.ReadLine());
                        pedidos = new List<Pedido>(qtdPedidos);

                        string[] splitter = new string[3];

                        while ((linha = sr.ReadLine()) != null)
                        {
                            splitter = linha.Split(";");
                            if (Int32.Parse(splitter[2]) == 0)
                            {
                                pedidos.Add(new Pedido(splitter[0], Int32.Parse(splitter[1]), Int32.MaxValue));
                            }
                            else pedidos.Add(new Pedido(splitter[0], Int32.Parse(splitter[1]), Int32.Parse(splitter[2])));
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

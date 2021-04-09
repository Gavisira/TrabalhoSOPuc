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
        public int capacidade = 5000;
        public int produtoPorPacote;
        public List<Produto> pacote;

        public Esteira ()
        {
            produtoPorPacote = capacidade/new Produto().volume;
            pacote = new List<Produto>(produtoPorPacote);
        }

        public Pacote Empacotar(int qtdProdutos){
            Pacote novo = new Pacote();
            for(int i = 0;i<produtoPorPacote;i++){
                if(realizado<qtdProdutos){
                    novo.produtos.Add(new Produto());
                    realizado++;
                }
            
           
            }
            return novo;
        }

    }
}

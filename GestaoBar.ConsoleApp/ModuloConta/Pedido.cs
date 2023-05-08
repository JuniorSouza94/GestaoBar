using GestaoBar.ConsoleApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class Pedido
    {
        public static int contadorId;

        public int id;

        public Produto produto;

        public int quantidadeSolicitada;

        public Pedido(Produto produto, int quantidadeEscolhida)
        {
            contadorId++;
            id = contadorId;

            this.produto = produto;
            this.quantidadeSolicitada = quantidadeEscolhida;
        }

        public decimal CalcularTotalParcial()
        {
            return produto.preco * quantidadeSolicitada;
        }
    }
}

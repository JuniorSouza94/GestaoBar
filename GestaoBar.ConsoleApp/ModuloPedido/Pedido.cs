using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloPedido
{
    public class Pedido : EntidadeBase
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double TotalParcial { get; set; }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Pedido pedidoAtualizado = (Pedido)registroAtualizado;

            this.Produto = pedidoAtualizado.Produto;
            this.Quantidade = pedidoAtualizado.Quantidade;
            this.TotalParcial = pedidoAtualizado.TotalParcial;
        }       
    }
}

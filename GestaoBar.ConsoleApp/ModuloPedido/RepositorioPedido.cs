using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloPedido
{
    public class RepositorioPedido : RepositorioBase
    {
        public RepositorioPedido(ArrayList listaPedido)
        {
            this.listaRegistros = listaPedido;
        }

        public override Pedido SelecionarPorId(int id)
        {
            return (Pedido)base.SelecionarPorId(id);
        }
    }
}

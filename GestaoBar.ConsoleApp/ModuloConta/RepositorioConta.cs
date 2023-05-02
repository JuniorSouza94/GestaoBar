
using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase
    {
        public RepositorioConta(ArrayList listaConta)
        {
            this.listaRegistros = listaConta;
        }

        public override Conta SelecionarPorId(int id)
        {
            return (Conta)base.SelecionarPorId(id);
        }
        public double ObterValorParcial(int idMesa)
        {
            double valorParcial = 0;
            foreach (Conta conta in listaRegistros)
            {
                if (conta._Mesa.id == idMesa && conta.Aberta)
                {
                    foreach (Pedido pedido in conta._Pedido)
                    {
                        valorParcial += pedido.Produto.Preco * pedido.Quantidade;
                    }
                }
                else if (conta._Mesa.id == idMesa && !conta.Aberta)
                {
                    valorParcial = conta.ValorTotal;
                }
            }
            return valorParcial;
        }
        public double ObterFaturamentoDoDia()
        {
            double faturamento = 0;

            foreach (Conta conta in listaRegistros)
            {
                if (conta.Aberta)
                {
                    faturamento += conta.TotalPedido;
                }
            }

            return faturamento;
        }

    }
}

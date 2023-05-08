using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloGarcom;
using GestaoBar.ConsoleApp.ModuloMesa;
using GestaoBar.ConsoleApp.ModuloProduto;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase<Conta>
    {
        public Mesa mesa;
        public List<Pedido> pedidos;
        public Garcom garcom;
        public bool estaAberta;

        public DateTime data;

        public Conta(Mesa m, Garcom g, DateTime dataAbertura)
        {
            mesa = m;
            garcom = g;
            pedidos = new List<Pedido>();
            data = dataAbertura;

            Abrir();
        }

        public void RegistrarPedido(Produto produto, int quantidadeEscolhida)
        {
            Pedido novoPedido = new Pedido(produto, quantidadeEscolhida);

            pedidos.Add(novoPedido);
        }

        public decimal CalcularValorTotal()
        {
            return pedidos.Sum(p => p.CalcularTotalParcial());
        }

        public override void AtualizarInformacoes(Conta contaAtualizada)
        {
            garcom = contaAtualizada.garcom;
            mesa = contaAtualizada.mesa;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (garcom == null)
            {
                erros.Add("O campo \"Garçom\" é obrigatorio");
            }

            if (mesa == null)
            {
                erros.Add("O campo \"Mesa\" é obrigatorio");
            }

            return erros;
        }

        private void Abrir()
        {
            estaAberta = true;
            mesa.Ocupar();
        }

        public void Fechar()
        {
            estaAberta = false;
            mesa.Desocupar();
        }


    }
}

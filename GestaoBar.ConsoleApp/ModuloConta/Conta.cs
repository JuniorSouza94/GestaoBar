using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloGarcom;
using GestaoBar.ConsoleApp.ModuloMesa;
using GestaoBar.ConsoleApp.ModuloPedido;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {
        public Garcom _Garcom { get; set; }
        public List<Pedido> _Pedido { get; set; }
        public Mesa _Mesa { get; set; }
        public bool Fechada { get; set; } = false;
        public double TotalPedido { get; set; }
        public Conta()
        {

        }
        public Conta(Garcom garcom, Mesa mesa)
        {
            this._Garcom = garcom;
            this._Mesa = mesa;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Conta contaAtualizada = (Conta)registroAtualizado;

            _Garcom = contaAtualizada._Garcom;
            _Pedido = contaAtualizada._Pedido;
            _Mesa = contaAtualizada._Mesa;
            TotalPedido = contaAtualizada.TotalPedido;
        }
        public void AdicionarPedido(Pedido pedido)
        {
            _Pedido.Add(pedido);
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (Pedido pedido in _Pedido)
            {
                total += pedido.TotalParcial * pedido.Quantidade;
            }
            return total;
        }
        public void FecharConta()
        {
            Fechada = true;
        }
    }
}

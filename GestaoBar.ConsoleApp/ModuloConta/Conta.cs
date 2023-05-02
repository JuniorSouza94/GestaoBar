using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloGarcom;
using GestaoBar.ConsoleApp.ModuloMesa;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class Conta : EntidadeBase
    {

        public Garcom _Garcom { get; set; }
        public List<Pedido> _Pedido { get; set; }
        public Pedido pedido { get; set; }
        public Mesa _Mesa { get; set; }
        public double TotalPedido { get; set; }
        public bool Aberta { get; set; } = true;
        public double ValorTotal { get; private set; } = 0;
        public Conta(Garcom garcom, List<Pedido> pedido, Mesa mesa)
        {
            this._Garcom = garcom;
            this._Pedido = pedido;
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
        public void FecharConta()
        {
            Aberta = false;
            ValorTotal = _Pedido.Sum(p => p.Produto.Preco * p.Quantidade);
        }
        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (_Garcom == null)
                erros.Add("O campo \"garçom\" é obrigatório");
            if (pedido == null)
                erros.Add("O campo \"pedido\" é obrigatório");
            if (_Mesa == null)
                erros.Add("O campo \"mesa\" é obrigatório");

            return erros;
        }
    }
}

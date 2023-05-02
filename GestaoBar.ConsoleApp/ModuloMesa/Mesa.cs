using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloConta;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        //CRUD
        public Conta _Conta { get; set; }
        public Pedido _Pedido { get; set; }
        public bool Status { get; set; }
        public Mesa(Conta conta, Pedido pedido, bool status)
        {
            this._Conta = conta;
            this._Pedido = pedido;
            this.Status = status;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            _Conta = mesaAtualizada._Conta;
            _Pedido = mesaAtualizada._Pedido;
            Status = mesaAtualizada.Status;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (_Conta == null)
                erros.Add("O campo \"conta\" é obrigatório");
            if (_Pedido == null)
                erros.Add("O campo \"pedido\" é obrigatório");

            return erros;
        }
    }
}

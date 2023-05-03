using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {

        //CRUD        
        public Status Status { get; set; }
        public int Capacidade { get; set; }
        public Mesa(Status status, int capacidade)
        {
            this.Status = status;
            this.Capacidade = capacidade;
        }
        
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            Status = mesaAtualizada.Status;
            Capacidade = mesaAtualizada.Capacidade;
        }      
    }
}

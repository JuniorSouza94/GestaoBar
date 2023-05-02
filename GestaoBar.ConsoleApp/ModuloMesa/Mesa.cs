using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloConta;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloMesa
{
    public class Mesa : EntidadeBase
    {
        //CRUD        
        public bool Status { get; set; }
        public Mesa()
        {

        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Mesa mesaAtualizada = (Mesa)registroAtualizado;

            Status = mesaAtualizada.Status;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();
        
            return erros;
        }
    }
}

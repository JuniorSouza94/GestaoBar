using GestaoBar.ConsoleApp.Compartilhado;

namespace GestaoBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {        
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public Garcom(string nome, string cpf, string telefone)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.Telefone = telefone;
        }
        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Garcom garcomAtualizado = (Garcom)registroAtualizado;

            Nome = garcomAtualizado.Nome;
            Cpf = garcomAtualizado.Cpf;
            Telefone = garcomAtualizado.Telefone;
        }
    }
}

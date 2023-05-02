using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloGarcom
{
    public class Garcom : EntidadeBase
    {
        //CRUD
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

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome.Trim()))
                erros.Add("O campo \"nome\" é obrigatório");
            if (string.IsNullOrEmpty(Cpf.Trim()))
                erros.Add("O campo \"cpf\" é obrigatório");
            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O campo \"telefone\" é obrigatório");

            return erros;
        }
    }
}

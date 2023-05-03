using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloProduto
{
    public class Produto : EntidadeBase
    {
        //CRUD
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Produto(string nome, double preco)
        {
            this.Nome = nome;
            this.Preco = preco;
        }

        public override void AtualizarInformacoes(EntidadeBase registroAtualizado)
        {
            Produto produtoAtualizado = (Produto)registroAtualizado;

            Nome = produtoAtualizado.Nome;
            Preco = produtoAtualizado.Preco;
        }
    }
}

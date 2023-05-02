
using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloProduto
{
    public class TelaProduto : TelaBase
    {
        public TelaProduto(RepositorioProduto repositorioProduto)
        {
            this.repositorioBase = repositorioProduto;
            nomeEntidade = "Produto";
            sufixo = "s";
        }

        protected override void MostrarTabela(ArrayList produtos)
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20}", "Id", "Nome", "Preço");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Produto produto in produtos)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-20}", produto.id, produto.Nome, produto.Preco);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        }
        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine($"\n==============NOVO PRODUTO==============\n");

            Console.Write("Informe o Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o Preço: ");
            double preco = double.Parse(Console.ReadLine());

            Produto produto = new Produto(nome, preco);
            
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");

            return produto;
        }

    }
}

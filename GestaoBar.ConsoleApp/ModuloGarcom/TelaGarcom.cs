
using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloGarcom
{
    public class TelaGarcom : TelaBase<Garcom>
    {
        public TelaGarcom(RepositorioGarcom repositorioGarcom) : base(repositorioGarcom)
        {
            NomeEntidade = "Garçom";
        }

        public override void MostrarTabela(List<Garcom> garcons)
        {
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}", "Id", "Nome", "CPF", "Telefone");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Garcom garcom in garcons)
            {
                Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}", garcom.id, garcom.Nome, garcom.Cpf, garcom.Telefone);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        }

        public override Garcom ObterRegistro()
        {
            Console.WriteLine($"\n==============NOVO GARÇOM==============\n");

            Console.Write("Informe o Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Informe o CPF: ");
            string cpf = Console.ReadLine();

            Console.Write("Informe o Telefone: ");
            string telefone = Console.ReadLine();

            Garcom garcom = new Garcom(nome, cpf, telefone);

            return garcom;
        }
    }
}

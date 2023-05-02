
using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloConta;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase
    {
        private TelaConta telaConta;
        private TelaPedido telaPedido;
        public TelaMesa(RepositorioMesa repositorioMesa)
        {
            this.repositorioBase = repositorioMesa;
            nomeEntidade = "Mesa";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList mesas)
        {
            Console.WriteLine("{0,-10} | {1,-30}", "Id", "Status");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Mesa mesa in mesas)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", mesa.id, mesa.Status);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        }

        protected override Mesa ObterRegistro()
        {
            Console.WriteLine($"\n==============NOVA MESA==============\n");

            Console.Write("Digite [1] se a mesa está ocupada ou [2] se a mesa estiver livre: ");
            int verificar = int.Parse(Console.ReadLine());

            bool status = false;

            if(verificar == 1)
            {
                status = true;
            }
            else
                status = false;

            Mesa novaMesa = new Mesa();
            novaMesa.Status = status;
            
            return novaMesa;
        }
    }
}

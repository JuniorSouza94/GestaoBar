
using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloMesa
{
    public class TelaMesa : TelaBase<Mesa>
    {
        public TelaMesa(RepositorioMesa repositorioMesa) : base(repositorioMesa)
        {
            NomeEntidade = "Mesa";
            sufixo = "s";
        }
        public override void MostrarTabela(List<Mesa> mesas)
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20}", "Id", "Status", "Capacidade");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Mesa mesa in mesas)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-20}", mesa.id, mesa.Status, mesa.Capacidade);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        }

        public override Mesa ObterRegistro()
        {
            Console.WriteLine($"\n==============NOVA MESA==============\n");

            Console.Write("Digite [1] se a mesa está livre ou [2] se a mesa estiver ocupada: ");
            int verificar = int.Parse(Console.ReadLine());

            Console.Write("Informe a Capacidade: ");
            int capacidade = int.Parse(Console.ReadLine());

            Status status = new Status();
            status = (Status)verificar;

            Mesa novaMesa = new Mesa(status, capacidade);

            return novaMesa;
        }
    }
}

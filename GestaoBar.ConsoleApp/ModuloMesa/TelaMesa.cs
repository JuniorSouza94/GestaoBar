
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
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", "Id", "Conta", "Pedido", "Status");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Mesa mesa in mesas)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20}", mesa.id, mesa._Conta.id, mesa._Pedido.id, mesa.Status);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        }

        protected override Mesa ObterRegistro()
        {
            Console.WriteLine($"\n==============NOVA MESA==============\n");

            Conta conta = ObterConta();

            Pedido pedido = ObterPedido();

            Console.Write("Digite [1] se a mesa está ocupada ou [2] se a mesa estiver livre: ");
            int verificar = int.Parse(Console.ReadLine());

            bool status = false;

            if(verificar == 1)
            {
                status = true;
            }
            else
                status = false;

            Mesa novaMesa = new Mesa(conta, pedido, status);
            
            return novaMesa;
        }
        private Conta ObterConta()
        {
            telaConta.VisualizarRegistros(false);

            Conta conta = (Conta)telaConta.EncontrarRegistro("Informe o ID da Conta: ");

            Console.WriteLine();

            return conta;
        }
        private Pedido ObterPedido()
        {
            telaPedido.VisualizarRegistros(false);

            Pedido pedido = (Pedido)telaPedido.EncontrarRegistro("Informe o ID do Pedido: ");

            Console.WriteLine();

            return pedido;
        }
    }
}

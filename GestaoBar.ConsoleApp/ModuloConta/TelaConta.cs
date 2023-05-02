
using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloGarcom;
using GestaoBar.ConsoleApp.ModuloMesa;
using GestaoBar.ConsoleApp.ModuloPedido;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase
    {
        private TelaGarcom telaGarcom;
        private TelaPedido telaPedido;
        private TelaMesa telaMesa;

        public TelaConta(RepositorioConta repositorioConta)
        {
            this.repositorioBase = repositorioConta;
            nomeEntidade = "Conta";
            sufixo = "s";
        }
        protected override void MostrarTabela(ArrayList contas)
        {
            Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20} | {4,-20}", "Id", "Garçom", "Pedido", "Mesa", "Total da Conta");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Conta conta in contas)
            {
                Console.WriteLine("{0,-10} | {1,-30} | {2,-20} | {3,-20} | {4,-20}", 
                conta.id, conta._Garcom.id, conta.pedido.id, conta._Mesa.id);
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.WriteLine($"\n==============NOVA CONTA==============\n");

            Pedido pedido = ObterPedido();

            Garcom garcom = ObterGarcom();

            Mesa mesa = ObterMesa();

            Conta conta = new Conta(garcom, pedido, mesa);

            return conta;
        }
        private Pedido ObterPedido()
        {
            telaPedido.VisualizarRegistros(false);

            Pedido pedido = (Pedido)telaPedido.EncontrarRegistro("Informe o ID do Pedido: ");

            Console.WriteLine();

            return pedido;
        }
        private Garcom ObterGarcom()
        {
            telaGarcom.VisualizarRegistros(false);

            Garcom garcom = (Garcom)telaGarcom.EncontrarRegistro("Informe o ID do Garçom: ");

            Console.WriteLine();

            return garcom;
        }
        private Mesa ObterMesa()
        {
            telaMesa.VisualizarRegistros(false);

            Mesa mesa = (Mesa)telaMesa.EncontrarRegistro("Informe o ID da Mesa: ");

            Console.WriteLine();

            return mesa;
        }
    }
}

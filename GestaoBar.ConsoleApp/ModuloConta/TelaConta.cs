using GestaoBar.ConsoleApp.Compartilhado;
using GestaoBar.ConsoleApp.ModuloGarcom;
using GestaoBar.ConsoleApp.ModuloMesa;
using GestaoBar.ConsoleApp.ModuloPedido;
using GestaoBar.ConsoleApp.ModuloProduto;

namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class TelaConta : TelaBase<Conta>
    {
        private readonly RepositorioGarcom _repositorioGarcom;
        private readonly RepositorioMesa _repositorioMesa;
        private readonly RepositorioProduto _repositorioProduto;
        private readonly RepositorioConta _repositorioConta;
        public TelaConta(
        RepositorioConta repositorioConta,
        RepositorioGarcom repositorioGarcom,
        RepositorioMesa repositorioMesa,
        RepositorioProduto repositorioProduto
        ) : base(repositorioConta)
        {
            NomeEntidade = "Conta";
            sufixo = "s";
            _repositorioGarcom = repositorioGarcom;
            _repositorioMesa = repositorioMesa;
            _repositorioProduto = repositorioProduto;
        }
        public override string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {NomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Abrir Conta {NomeEntidade}");
            Console.WriteLine($"Digite 2 para Registrar Pedido {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Fechar Conta {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Visualizar Contas Abertas {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 5 para Visualizar Total Faturamento Dia {NomeEntidade}{sufixo}\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void AbrirConta(Garcom garcom, Mesa mesa)
        {
            var conta = new Conta(garcom, mesa);
            _repositorioConta.AdicionarConta(conta);
            Console.WriteLine("Conta aberta com sucesso!");
            Console.WriteLine();
        }
        public void RegistrarPedidos(Conta conta)
        {
            Console.WriteLine($"Registrando pedidos para mesa {conta._Mesa.id}...");
            while (true)
            {
                Console.WriteLine("Digite a descrição do pedido (ou 'fim' para encerrar os pedidos):");
                string descricao = Console.ReadLine();
                if (descricao == "fim") break;

                Console.WriteLine("Digite o valor unitário do pedido:");
                double valorUnitario = double.Parse(Console.ReadLine());

                Console.WriteLine("Digite a quantidade do pedido:");
                int quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe o ID do produto:");
                int idProduto = int.Parse(Console.ReadLine());

                Produto produto = _repositorioProduto.SelecionarPorId(idProduto);

                Pedido pedido = new Pedido
                {
                    Produto = produto,
                    TotalParcial = valorUnitario,
                    Quantidade = quantidade
                };

                conta.AdicionarPedido(pedido);
                Console.WriteLine("Pedido registrado com sucesso!");
                Console.WriteLine();
            }
        }
        public void FecharConta(Conta conta)
        {
            conta.FecharConta();
            Console.WriteLine($"Conta fechada para mesa {conta._Mesa.id}. Total a pagar: R${conta.TotalPedido}");
            Console.WriteLine();
        }
        public void VisualizarContasAbertas()
        {
            List<Conta> contasAbertas = _repositorioConta.ObterContasAbertas();
            Console.WriteLine($"Contas Abertas: {contasAbertas.Count}\n");
            foreach (Conta conta in contasAbertas)
            {
                Console.WriteLine($"Mesa {conta._Mesa.id} - Garçom: {conta._Garcom.Nome} - Valor total: R${conta.TotalPedido}");
            }
            Console.WriteLine();
        }
        public void VisualizarTotalFaturamentoDia()
        {
            double faturamento = _repositorioConta.CalcularTotalFaturadoDia();
            Console.WriteLine($"Faturamento do dia: R${faturamento}");
            Console.WriteLine();
        }
        public bool ExecutarOpcao(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Digite o ID do garçom:");
                    int idGarcom = int.Parse(Console.ReadLine());
                    Garcom garcom = _repositorioGarcom.SelecionarPorId(idGarcom);

                    Console.WriteLine("Digite o ID da mesa:");
                    int idMesa = int.Parse(Console.ReadLine());
                    Mesa mesa = _repositorioMesa.SelecionarPorId(idMesa);

                    AbrirConta(garcom, mesa);
                    Console.ReadLine();
                    return true;

                case "2":
                    Console.Clear();
                    Console.WriteLine("Digite o ID da conta:");
                    int idConta = int.Parse(Console.ReadLine());
                    Conta conta = _repositorioConta.SelecionarPorId(idConta);

                    RegistrarPedidos(conta);
                    Console.ReadLine();
                    return true;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Digite o ID da conta:");
                    int idContaFechar = int.Parse(Console.ReadLine());
                    Conta contaFechar = _repositorioConta.SelecionarPorId(idContaFechar);

                    FecharConta(contaFechar);
                    Console.ReadLine();
                    return true;

                case "4":
                    Console.Clear();
                    VisualizarContasAbertas();
                    Console.ReadLine();
                    return true;

                case "5":
                    Console.Clear();
                    VisualizarTotalFaturamentoDia();
                    Console.ReadLine();
                    return true;

                case "s":
                    return false;

                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    Console.ReadLine();
                    return true;
            }
        }

        public override Conta ObterRegistro()
        {
            throw new NotImplementedException();
        }
        public override void MostrarTabela(List<Conta> registros)
        {
            throw new NotImplementedException();
        }
    }
}
// "TelaConta.ExecutarOpcao(string)": não encontrado nenhum método adequado para subtituição
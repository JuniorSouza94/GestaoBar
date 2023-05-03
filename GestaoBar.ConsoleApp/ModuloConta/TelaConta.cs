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
        public TelaConta(RepositorioConta repositorioConta, RepositorioGarcom repositorioGarcom,
        RepositorioMesa repositorioMesa, RepositorioProduto repositorioProduto) : base(repositorioConta)
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
            Console.WriteLine($"Digite 9 para Visualizar Contas {NomeEntidade}");
            Console.WriteLine($"Digite 2 para Registrar Pedido {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Fechar Conta {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Visualizar Contas Abertas {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 5 para Visualizar Total Faturamento Dia {NomeEntidade}{sufixo}\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public override void MostrarTabela(List<Conta> contas)
        {
            Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}", "Id", "Garçom", "Mesa", "Pedido");
            Console.WriteLine("-------------------------------------------------------------------------");
            foreach (Conta conta in contas)
            {
                foreach (Pedido pedido in conta._Pedido)
                {
                    Console.WriteLine("{0,-10} | {1,-20} | {2,-20} | {3,-20}",
                    conta.id, conta._Garcom.Nome, conta._Mesa.id, pedido.id);
                }
            }
        }
        public override Conta ObterRegistro()
        {
            Console.WriteLine($"\n==============ABRIR CONTA==============\n");

            Conta conta = new Conta();

            conta._Garcom = ObterGarcom();

            conta._Mesa = ObterMesa();

            return conta;
        }
        public void RegistrarPedidos()
        {
            Console.WriteLine($"\n==============REGISTRAR PEDIDO==============\n");

            Conta conta = ObterConta();

            bool adicionandoPedidos = true;
            while (adicionandoPedidos)
            {
                var listaProduto = _repositorioProduto.SelecionarTodos();
                foreach (Produto produto in listaProduto)
                {
                    Console.WriteLine($"{produto.id} - {produto.Nome} - R${produto.Preco}");
                }

                Console.WriteLine("Digite o número do produto que deseja adicionar ou '0' para sair:");
                int idProduto = int.Parse(Console.ReadLine());
                if (idProduto == 0)
                {
                    adicionandoPedidos = false;
                    continue;
                }

                Produto produtoSelecionado = listaProduto.FirstOrDefault(p => p.id == idProduto);
                if (produtoSelecionado == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                    continue;
                }

                Console.WriteLine("Digite a quantidade:");
                int quantidade = int.Parse(Console.ReadLine());

                Pedido novoPedido = new Pedido(produtoSelecionado, quantidade);

                conta.AdicionarPedido(novoPedido);

                Console.WriteLine($"Pedido de {quantidade} {produtoSelecionado.Nome} adicionado à conta da mesa {conta._Mesa.id}!");
            }
            double totalConta = conta.CalcularTotal();
            Console.WriteLine($"Total da conta da mesa {conta._Mesa.id}: R${totalConta}\n");

            Console.WriteLine("Deseja fechar a conta? (S/N)");
            string resposta = Console.ReadLine().ToUpper();
            if (resposta == "S")
            {
                conta.FecharConta();
                _repositorioConta.Editar(conta.id, conta);
                Console.WriteLine("Conta fechada com sucesso!");
            }

        }
        public double FecharConta()
        {
            Conta conta = ObterConta();
            double totalConta = CalcularValorTotalConta(conta);
            Console.WriteLine($"Total da conta da mesa {conta._Mesa.id}: R${totalConta}\n");

            Console.WriteLine("Deseja fechar a conta? (S/N)");
            string resposta = Console.ReadLine().ToUpper();
            if (resposta == "S")
            {
                _repositorioConta.Excluir(conta.id);
                Console.WriteLine($"Conta da mesa {conta._Mesa.id} fechada com sucesso!");
                return totalConta;
            }
            else
            {
                Console.WriteLine($"Conta da mesa {conta._Mesa.id} não foi fechada.");
                return 0;
            }
        }
        public void VisualizarContasAbertas()
        {
            Console.WriteLine($"Contas abertas:");

            List<Conta> contas = _repositorioConta.SelecionarTodos().Where(c => !c.Fechada).ToList();

            if (contas.Count == 0)
            {
                Console.WriteLine($"Nenhuma conta aberta no momento.");
                return;
            }

            MostrarTabela(contas);
        }
        public void VisualizarTotalFaturamentoDia()
        {
            Console.WriteLine($"\n==============FATURAMENTO DO DIA==============\n");

            double totalFaturamento = 0;

            List<Conta> contas = _repositorioConta.SelecionarTodos();

            foreach (Conta conta in contas)
            {
                totalFaturamento += CalcularValorTotalConta(conta);
            }

            MostrarTotalFaturamento(totalFaturamento);
        }


        private Garcom ObterGarcom()
        {
            Console.Write("Digite o id do Garçom: ");
            int idGarcom = int.Parse(Console.ReadLine());

            Garcom garcom = _repositorioGarcom.SelecionarPorId(idGarcom);

            return garcom;
        }
        private Mesa ObterMesa()
        {
            Console.Write("Digite o id da Mesa: ");
            int idMesa = int.Parse(Console.ReadLine());

            Mesa mesa = _repositorioMesa.SelecionarPorId(idMesa);

            return mesa;
        }
        private Conta ObterConta()
        {
            Console.Write("Digite o id da Conta: ");
            int idConta = int.Parse(Console.ReadLine());

            Conta conta = _repositorioConta.SelecionarPorId(idConta);

            return conta;
        }
        private double CalcularValorTotalConta(Conta conta)
        {
            double totalConta = 0;
            foreach (Pedido pedido in conta._Pedido)
            {
                totalConta += pedido.Produto.Preco * pedido.Quantidade;
            }
            return totalConta;
        }
        private void MostrarTotalFaturamento(double totalFaturamento)
        {
            Console.WriteLine($"Total: R${totalFaturamento:0.00}\n");
        }
    }
}

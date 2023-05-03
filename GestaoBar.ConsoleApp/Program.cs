using GestaoBar.ConsoleApp.ModuloConta;
using GestaoBar.ConsoleApp.ModuloGarcom;
using GestaoBar.ConsoleApp.ModuloMesa;
using GestaoBar.ConsoleApp.ModuloProduto;
using System.Collections;

namespace GestaoBar.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>();
            RepositorioProduto repositorioProduto = new RepositorioProduto(produtos);
            TelaProduto telaProduto = new TelaProduto(repositorioProduto);

            List<Garcom> garcons = new List<Garcom>();
            RepositorioGarcom repositorioGarcom = new RepositorioGarcom(garcons);
            TelaGarcom telaGarcom = new TelaGarcom(repositorioGarcom);

            List<Mesa> mesas = new List<Mesa>();
            RepositorioMesa repositorioMesa = new RepositorioMesa(mesas);
            TelaMesa telaMesa = new TelaMesa(repositorioMesa);

            List<Conta> contas = new List<Conta>();
            RepositorioConta repositorioConta = new RepositorioConta(contas);
            TelaConta telaConta = new TelaConta(repositorioConta, repositorioGarcom,
            repositorioMesa, repositorioProduto);

            CadastrarRegistros(repositorioProduto, repositorioGarcom, repositorioMesa, repositorioConta);

            TelaPrincipal principal = new TelaPrincipal();

            while(true)
            {
                string opcao = principal.ApresentarMenu();
                
                if (opcao == "s")
                    break;
                if (opcao == "1")
                {
                    string subMenu = telaConta.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaConta.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaConta.RegistrarPedidos();
                    }
                    else if (subMenu == "3")
                    {
                        telaConta.FecharConta();
                    }
                    else if (subMenu == "4")
                    {
                        telaConta.VisualizarContasAbertas();
                    }
                    else if (subMenu == "5")
                    {
                        telaConta.VisualizarTotalFaturamentoDia();
                    }
                    else if (subMenu == "9")
                    {
                        telaConta.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                }
                if (opcao == "2")
                {
                    string subMenu = telaGarcom.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaGarcom.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaGarcom.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaGarcom.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaGarcom.ExcluirRegistro();
                    }
                }
                if (opcao == "3")
                {
                    string subMenu = telaMesa.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaMesa.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaMesa.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaMesa.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaMesa.ExcluirRegistro();
                    }
                }
                if (opcao == "4")
                {
                    string subMenu = telaProduto.ApresentarMenu();

                    if (subMenu == "1")
                    {
                        telaProduto.InserirNovoRegistro();
                    }
                    else if (subMenu == "2")
                    {
                        telaProduto.VisualizarRegistros(true);
                        Console.ReadLine();
                    }
                    else if (subMenu == "3")
                    {
                        telaProduto.EditarRegistro();
                    }
                    else if (subMenu == "4")
                    {
                        telaProduto.ExcluirRegistro();
                    }
                }
            }
        }
        private static void CadastrarRegistros(RepositorioProduto _repositorioProduto,
                                               RepositorioGarcom _repositorioGarcom,
                                               RepositorioMesa _repositorioMesa,
                                               RepositorioConta _repositorioConta)
        {
            Produto produto1 = new Produto("Refrigerante", 5.50);
            Produto produto2 = new Produto("Porção de Fritas", 25.50);

            _repositorioProduto.Inserir(produto1);
            _repositorioProduto.Inserir(produto2);

            Garcom garcom1 = new Garcom("Felipe", "5555555555", "499889984951");
            Garcom garcom2 = new Garcom("André", "12312312323", "981909819099");

            _repositorioGarcom.Inserir(garcom1);
            _repositorioGarcom.Inserir(garcom2);

            Status status1 = new Status();
            status1 = (Status)1;
            Mesa mesa1 = new Mesa(status1, 5);

            Status status2 = new Status();
            status2 = (Status)2;
            Mesa mesa2 = new Mesa(status2, 10);

            Status status3 = new Status();
            status3 = (Status)1;
            Mesa mesa3 = new Mesa(status3, 15);

            _repositorioMesa.Inserir(mesa1);
            _repositorioMesa.Inserir(mesa2);
            _repositorioMesa.Inserir(mesa3);

            Conta conta1 = new Conta(garcom1, mesa1);
            Conta conta2 = new Conta(garcom2, mesa2);
            Conta conta3 = new Conta(garcom1, mesa3);

            _repositorioConta.Inserir(conta1);
            _repositorioConta.Inserir(conta2);
            _repositorioConta.Inserir(conta3);
        }
    }
}

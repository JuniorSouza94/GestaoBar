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
            RepositorioConta _repositorioConta = new RepositorioConta(new ArrayList());
            RepositorioGarcom _repositorioGarcom = new RepositorioGarcom(new ArrayList());
            RepositorioProduto _repositorioProduto = new RepositorioProduto(new ArrayList());
            RepositorioMesa _repositorioMesa = new RepositorioMesa(new ArrayList());

            TelaConta _telaConta = new TelaConta(_repositorioConta);
            TelaGarcom _telaGarcom = new TelaGarcom(_repositorioGarcom);
            TelaProduto _telaProduto = new TelaProduto(_repositorioProduto);
            TelaMesa _telaMesa = new TelaMesa(_repositorioMesa);
        }
        /*
        private static void CadastrarRegistros(RepositorioConta repositorioConta,
                                               RepositorioGarcom repositorioGarcom,
                                               RepositorioProduto repositorioProduto,
                                               RepositorioMesa repositorioMesa)
        {
            Produto produto1 = new Produto("Cerveja", 5.50);
            Produto produto2 = new Produto("Porção de Fritas", 25);
            repositorioProduto.Inserir(produto1);
            repositorioProduto.Inserir(produto2);

            Garcom garcom1 = new Garcom("João", "05800351905", "55549816509");
            Garcom garcom2 = new Garcom("Pedro", "058065191905", "9196190980");
            repositorioGarcom.Inserir(garcom1);
            repositorioGarcom.Inserir(garcom2);

            bool aberta1 = false;
            bool aberta2 = true;
            Mesa mesa1 = new Mesa();
            mesa1.Status = aberta1;
            Mesa mesa2 = new Mesa();
            mesa2.Status = aberta2;

            repositorioMesa.Inserir(mesa1);
            repositorioMesa.Inserir(mesa2);

            Conta conta = new Conta(garcom1, 1, 1);



        }
        */
    }

}

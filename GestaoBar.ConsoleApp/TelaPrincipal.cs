using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoBar.ConsoleApp
{
    public class TelaPrincipal
    {
        public string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Gestão Financeiro Bar Da Galera 1.0\n");

            Console.WriteLine("Digite 1 para Gerenciar Conta");
            Console.WriteLine("Digite 2 para Gerenciar Garçom");
            Console.WriteLine("Digite 3 para Gerenciar Mesa");
            Console.WriteLine("Digite 4 para Gerenciar Produto");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
    }
}

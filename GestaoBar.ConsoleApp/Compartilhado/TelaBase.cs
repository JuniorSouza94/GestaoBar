using System.Collections;

namespace GestaoBar.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<Modelo> where Modelo : EntidadeBase
    {
        protected string NomeEntidade;
        public string sufixo;
        protected IRepositorio<Modelo> RepositorioBase;

        public TelaBase(RepositorioBase<Modelo> repositorio)
        {
            RepositorioBase = repositorio;
        }
        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {NomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {NomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Editar {NomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Excluir {NomeEntidade}{sufixo}\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }
        public void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo + "\n");

            Console.WriteLine(subtitulo + "\n");
        }

        public void MostrarMensagem(string mensagem, ConsoleColor cor)
        {
            Console.WriteLine();

            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        public void InserirNovoRegistro()
        {
            Modelo registro = ObterRegistro();

            RepositorioBase.Inserir(registro);

            MostrarMensagem($"Registro de {NomeEntidade} inserido com sucesso!", ConsoleColor.Green);
        }

        public void VisualizarRegistros(bool mostrarCabecalho)
        {
            List<Modelo> registros = RepositorioBase.SelecionarTodos().OfType<Modelo>().ToList();

            if (registros.Count == 0)
            {
                MostrarMensagem($"Nenhum {NomeEntidade.ToLower()} cadastrado", ConsoleColor.DarkYellow);
                return;
            }

            if (mostrarCabecalho)
            {
                MostrarCabecalho($"Listagem de {NomeEntidade}s", "");
            }

            MostrarTabela(registros);
        }

        public void EditarRegistro()
        {
            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write($"Digite o id do {NomeEntidade.ToLower()} a ser editado: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Modelo registroAtualizado = ObterRegistro();

            RepositorioBase.Editar(id, registroAtualizado);

            MostrarMensagem($"Registro de {NomeEntidade} editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirRegistro()
        {
            VisualizarRegistros(false);

            Console.WriteLine();

            Console.Write($"Digite o id do {NomeEntidade.ToLower()} a ser excluído: ");
            int id = Convert.ToInt32(Console.ReadLine());

            RepositorioBase.Excluir(id);

            MostrarMensagem($"Registro de {NomeEntidade} excluído com sucesso!", ConsoleColor.Green);
        }

        public abstract Modelo ObterRegistro();

        public abstract void MostrarTabela(List<Modelo> registros);
    }
}
namespace GestaoBar.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<TRepositorio, TEntidade> : ITelaCadastravel
        where TRepositorio : RepositorioBase<TEntidade>
        where TEntidade : EntidadeBase<TEntidade>
    {
        protected string nomeEntidade;
        public string sufixo;
        protected TRepositorio repositorioBase = null;

        public virtual string ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine($"Cadastro de {nomeEntidade}{sufixo} \n");

            Console.WriteLine($"Digite 1 para Inserir {nomeEntidade}");
            Console.WriteLine($"Digite 2 para Visualizar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 3 para Editar {nomeEntidade}{sufixo}");
            Console.WriteLine($"Digite 4 para Excluir {nomeEntidade}{sufixo}\n");

            Console.WriteLine("Digite s para Sair");

            string opcao = Console.ReadLine();

            return opcao;
        }

        public virtual void InserirNovoRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Inserindo um novo registro...");

            TEntidade registro = ObterRegistro();

            if (TemErrosDeValidacao(registro))
            {
                InserirNovoRegistro(); //chamada recursiva

                return;
            }

            repositorioBase.Inserir(registro);

            MostrarMensagemSucesso("Registro inserido com sucesso!");
        }

        public virtual void VisualizarRegistros(bool mostrarCabecalho)
        {
            if (mostrarCabecalho)
                MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Visualizando registros já cadastrados...");

            List<TEntidade> registros = repositorioBase.SelecionarTodos();

            if (registros.Count == 0)
            {
                MostrarMensagemAtencao("Nenhum registro cadastrado");
            }

            MostrarTabela(registros);
        }

        public virtual void EditarRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Editando um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            TEntidade registro = EncontrarRegistro("Digite o id do registro: ");

            TEntidade registroAtualizado = ObterRegistro();

            if (TemErrosDeValidacao(registroAtualizado))
            {
                EditarRegistro();

                return;
            }

            repositorioBase.Editar(registro, registroAtualizado);

            MostrarMensagemSucesso("Registro editado com sucesso!");
        }

        public virtual void ExcluirRegistro()
        {
            MostrarCabecalho($"Cadastro de {nomeEntidade}{sufixo}", "Excluindo um registro já cadastrado...");

            VisualizarRegistros(false);

            Console.WriteLine();

            TEntidade registro = EncontrarRegistro("Digite o id do registro: ");

            repositorioBase.Excluir(registro);

            MostrarMensagemSucesso("Registro excluído com sucesso!");
        }

        public virtual TEntidade EncontrarRegistro(string textoCampo)
        {
            bool idInvalido;
            TEntidade registroSelecionado = null;

            do
            {
                idInvalido = false;
                Console.Write("\n" + textoCampo);
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());

                    registroSelecionado = repositorioBase.SelecionarPorId(id);

                    if (registroSelecionado == null)
                        idInvalido = true;
                }
                catch (FormatException)
                {
                    idInvalido = true;
                }

                if (idInvalido)
                    MostrarMensagemErro("Id inválido, tente novamente");

            } while (idInvalido);

            return registroSelecionado;
        }

        #region metodos privados
        protected bool TemErrosDeValidacao(TEntidade registro)
        {
            bool temErros = false;

            ArrayList erros = registro.Validar();

            if (erros.Count > 0)
            {
                temErros = true;
                Console.ForegroundColor = ConsoleColor.Red;

                foreach (string erro in erros)
                {
                    Console.WriteLine(erro);
                }

                Console.ResetColor();

                Console.ReadLine();
            }

            return temErros;
        }

        protected abstract TEntidade ObterRegistro();

        protected abstract void MostrarTabela(List<TEntidade> registros);

        protected void MostrarCabecalho(string titulo, string subtitulo)
        {
            Console.Clear();

            Console.WriteLine(titulo + "\n");

            Console.WriteLine(subtitulo + "\n");
        }

        private void MostrarMensagem(string mensagem, TipoMensagem tipo)
        {
            Console.WriteLine();

            ConsoleColor cor;

            switch (tipo)
            {
                case TipoMensagem.Sucesso: cor = ConsoleColor.Green; break;
                case TipoMensagem.Erro: cor = ConsoleColor.Red; break;
                case TipoMensagem.Atencao: cor = ConsoleColor.DarkYellow; break;

                default:
                    cor = ConsoleColor.White;
                    break;
            }

            Console.ForegroundColor = cor;

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        protected void MostrarMensagemSucesso(string mensagem)
        {
            MostrarMensagem(mensagem, TipoMensagem.Sucesso);
        }

        protected void MostrarMensagemAtencao(string mensagem)
        {
            MostrarMensagem(mensagem, TipoMensagem.Atencao);
        }

        protected void MostrarMensagemErro(string mensagem)
        {
            MostrarMensagem(mensagem, TipoMensagem.Erro);
        }


        #endregion
    }

    public enum TipoMensagem
    {
        Sucesso, Erro, Atencao
    }
}

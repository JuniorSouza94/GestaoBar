namespace GestaoBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase<TipoDeRegistro> : IRepositorio<TipoDeRegistro> where TipoDeRegistro : EntidadeBase
    {
        protected List<TipoDeRegistro> _listaRegistros;
        protected int contadorRegistros = 0;

        public RepositorioBase(List<TipoDeRegistro> lista)
        {
            _listaRegistros = lista;
        }
        public virtual void Inserir(TipoDeRegistro registro)
        {
            contadorRegistros++;

            registro.id = contadorRegistros;

            _listaRegistros.Add(registro);
        }
        public virtual void Editar(int id, TipoDeRegistro registroAtualizado)
        {
            TipoDeRegistro registroSelecionado = SelecionarPorId(id);

            registroSelecionado.AtualizarInformacoes(registroAtualizado);
        }
        public virtual void Excluir(int id)
        {
            TipoDeRegistro registroSelecionado = SelecionarPorId(id);

            _listaRegistros.Remove(registroSelecionado);
        }
        public virtual TipoDeRegistro SelecionarPorId(int id)
        {
            TipoDeRegistro registroSelecionado = null;

            foreach (TipoDeRegistro registro in _listaRegistros)
            {
                if (registro.id == id)
                {
                    registroSelecionado = registro;
                    break;
                }
            }
            return registroSelecionado;
        }
        public List<TipoDeRegistro> SelecionarTodos()
        {
            return _listaRegistros;
        }
    }
}
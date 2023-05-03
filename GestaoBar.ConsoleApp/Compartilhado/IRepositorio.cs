namespace GestaoBar.ConsoleApp.Compartilhado
{
    public interface IRepositorio<TipoDeRegistro> where TipoDeRegistro : EntidadeBase
    {
        void Inserir(TipoDeRegistro registro);
        void Editar(int id, TipoDeRegistro registroAtualizado);
        void Excluir(int id);
        TipoDeRegistro SelecionarPorId(int id);
        List<TipoDeRegistro> SelecionarTodos();
    }
}

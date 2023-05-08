namespace GestaoBar.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<TEntidade>
    {
        public int id;

        public abstract void AtualizarInformacoes(TEntidade registroAtualizado);

        public abstract ArrayList Validar();
    }
}

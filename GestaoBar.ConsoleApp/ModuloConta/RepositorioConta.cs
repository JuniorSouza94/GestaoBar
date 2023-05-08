using GestaoBar.ConsoleApp.Compartilhado;


namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public RepositorioConta(List<Conta> listaContas)
        {
            _listaRegistros = listaContas;
        }

        public List<Conta> SelecionarContasEmAberto()
        {
            return _listaRegistros.FindAll(conta => conta.estaAberta);
        }

        public List<Conta> SelecionarContasFechadas(DateTime data)
        {
            return _listaRegistros.FindAll(c => c.estaAberta == false && c.data.Date == data.Date);
        }
    }
}

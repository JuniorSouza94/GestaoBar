using GestaoBar.ConsoleApp.Compartilhado;


namespace GestaoBar.ConsoleApp.ModuloConta
{
    public class RepositorioConta : RepositorioBase<Conta>
    {
        public RepositorioConta(List<Conta> lista) : base(lista)
        {
        }
        public void AdicionarConta(Conta conta)
        {
            _listaRegistros.Add(conta);
        }
        public void RemoverConta(Conta conta)
        {
            _listaRegistros.Remove(conta);
        }
        public List<Conta> ObterContasAbertas()
        {
            return _listaRegistros.Where(c => !c.Fechada).ToList();
        }
        public double CalcularTotalFaturadoDia()
        {
            double total = 0;
            foreach (Conta conta in _listaRegistros.Where(c => c.Fechada))
            {
                total += conta.CalcularTotal();
            }
            return total;
        }
    }
}

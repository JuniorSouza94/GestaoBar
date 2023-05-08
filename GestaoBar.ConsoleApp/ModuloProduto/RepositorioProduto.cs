
using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloProduto
{
    public class RepositorioProduto : RepositorioBase<Produto>
    {
        public RepositorioProduto(List<Produto> listaProduto)
        {
            this._listaRegistros = listaProduto;
        }
    }
}

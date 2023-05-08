
using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloMesa
{
    public class RepositorioMesa : RepositorioBase<Mesa>
    {
        public RepositorioMesa(List<Mesa> listaMesa)
        {
            this._listaRegistros = listaMesa;
        }
    }
}

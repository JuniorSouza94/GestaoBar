using GestaoBar.ConsoleApp.Compartilhado;
using System.Collections;

namespace GestaoBar.ConsoleApp.ModuloGarcom
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        public RepositorioGarcom(List<Garcom> lista) : base(lista)
        {
        }
    }
}

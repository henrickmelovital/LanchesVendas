using MVC_2022.Models;

namespace MVC_2022.Repositories.Interface
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }

        Lanche GetLancheById(int lancheid);
    }
}

using HeroesAPI.Models;

namespace HeroesAPI.Repositories
{
    public interface IHeroeRepository
    {
        Task<IEnumerable<Heroe>> GetAllAsync();
        Task<Heroe?> GetByIdAsync(int id);
        Task<int> AddAsync(Heroe heroe);
        Task<int> UpdateAsync(Heroe heroe);
        Task<int> DeleteAsync(int id);
    }
}
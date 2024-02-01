using API.Entities;

namespace API.Repositories
{
    public interface IGamesRepository
    {
        Task CreateAsync(Game game);
        Task DeleteAsync(int id);
        Task<Game?> GetAsync(int id);
        Task<List<Game>> GetAllAsync();
        Task UpdateAsync(Game updatedGame);
    }
}
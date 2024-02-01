using API.Entities;

namespace API.Repositories
{
    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new List<Game>()
        {
            new Game()
            {
                Id = 1,
                Name = "Halo",
                Genre = "FPS",
                Price = 59.99m,
                ReleaseDate = new DateTime(2001, 11, 15),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "Halo 2",
                Genre = "FPS",
                Price = 20.99m,
                ReleaseDate = new DateTime(2004, 11, 9),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "Halo 3",
                Genre = "FPS",
                Price = 35.99m,
                ReleaseDate = new DateTime(2007, 9, 25),
                ImageUri = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 4,
                Name = "Halo 3: ODST",
                Genre = "FPS",
                Price = 45.99m,
                ReleaseDate = new DateTime(2009, 9, 22),
                ImageUri = "https://placehold.co/100"
            }
        };

        public async Task<List<Game>> GetAllAsync()
        {
            return await Task.FromResult(games);
        }

        public async Task<Game?> GetAsync(int id)
        {
            return await Task.FromResult(games.Find(g => g.Id == id));
        }

        public async Task CreateAsync(Game game)
        {
            game.Id = games.Max(g => g.Id) + 1;
            games.Add(game);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Game updatedGame)
        {
            var index = games.FindIndex(g => g.Id == updatedGame.Id);

            games[index] = updatedGame;

            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            int index = games.FindIndex(g => g.Id == id);

            games.RemoveAt(index);

            await Task.CompletedTask;
        }
    }
}

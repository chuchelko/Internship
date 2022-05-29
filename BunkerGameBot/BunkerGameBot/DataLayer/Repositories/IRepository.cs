namespace BunkerGameBot.DataLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BunkerGameBot.DataLayer.Entities;

    internal interface IRepository
    {
        Task<bool> CheckOrCreateUserAsync(long userId, long chatId, string name);
        Task CreateGameAsync(long userId, string key, int maxUsersCount);
        Task AddUserInGameAsync(long userId, string key);
        Task DeleteUserFromGame(long userId);
        Task<string> GetGameInfo(long userId);
        Task<Characteristics> GetUserCharacteristicsAsync(long userId);

    }
}

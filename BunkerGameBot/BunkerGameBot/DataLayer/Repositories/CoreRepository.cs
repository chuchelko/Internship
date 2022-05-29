namespace BunkerGameBot.DataLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BunkerGameBot.DataLayer.DbContexts;
    using BunkerGameBot.DataLayer.Entities;
    using BunkerGameBot.DataLayer.Services;

    using Microsoft.EntityFrameworkCore;

    internal class CoreRepository : IRepository
    {
        CoreDbContext context;

        public CoreRepository(CoreDbContext _context)
        {
            context = _context;
        }

        /// <param name="userId">User's key</param>
        /// <param name="chatId">Chat's id</param>
        /// <param name="name"></param>
        /// <returns>True if user is created; false if user is already exists</returns>
        public async Task<bool> CheckOrCreateUserAsync(long userId, long chatId, string name)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                User newUser = new User() { UserId = userId, Name = name, ChatId = chatId };

                await context.Users.AddAsync(newUser);
                await context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task AddUserInGameAsync(long userId, string key) 
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
                throw new Exception("Вы не существуете :(");

            if (user.Game != null)
                throw new Exception("Вы уже в игре");

            Game game = await context.Games.FirstOrDefaultAsync(g => g.Key == key);

            if (game == null)
                throw new Exception("Игры не существует");

            if (game.Users?.Count == game.MaxUsersCount)
                throw new Exception("Максимальное число игроков в игре");

            game.Users.Add(user);
            user.Game = game;
            user.Characteristics = game.Characteristics[game.Users.Count - 1];
            game.Characteristics[game.Users.Count - 1].User = user;

            await context.SaveChangesAsync();
        }
        
        public async Task CreateGameAsync(long userId, string key, int maxUsersCount)
        {
            Game game = await context.Games.FirstOrDefaultAsync(g => g.Key == key);

            User user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user.Game != null)
                throw new Exception("Вы уже в игре");

            if (game != null)
                throw new Exception("Игра с таким ключом уже создана");

            Game newGame = new Game() { Key = key, MaxUsersCount = maxUsersCount };

            newGame.Theme = await Parser.GetRandomThemeAsync(newGame);

            newGame.Characteristics = Parser.GetRandomCharacteristics(maxUsersCount).ToList();

            await context.Games.AddAsync(newGame);
            await context.SaveChangesAsync();

            await AddUserInGameAsync(userId, key);

        }

        public async Task DeleteUserFromGame(long userId)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);

            if (user.Game == null || user == null)
                throw new Exception("Игрока или игры не существует");
            Game game = user.Game;

            user.Game = null;
            game.Users.Remove(user);

            if (game.Users.Count == 0)
            {
                context.Remove(game);
            }

            game.Characteristics[game.Users.Count].User = null;
            user.Characteristics = null;

            await context.SaveChangesAsync();
        }

        public async Task<string> GetGameInfo(long userId)
        {
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user.Game == null)
                throw new Exception("Вы не в игре :(");
            var theme = user.Game.Theme;
            var key = user.Game.Key;
            var maxUserCount = user.Game.MaxUsersCount;
            var users = user.Game.Users;

            StringBuilder usersStringBuilder =  new StringBuilder();
            foreach(var userInGame in users)
                usersStringBuilder.AppendLine((await GetUserCharacteristicsAsync(userInGame.UserId))?.ToString());

            StringBuilder roomsStringBuilder = new StringBuilder();
            foreach (var room in theme.Rooms)
                roomsStringBuilder.AppendLine(room.ToString());

            return $@"Ключ игры {key}, максимальное количество игроков {maxUserCount}

{theme.BunkerName}
{theme.ThemeNameAndDescription}
{theme.Location}
Вы будете закрыты в бункере на {theme.YearsToLive} лет

Комнаты:
{roomsStringBuilder}

Доступные ресурсы: {theme.Resources}

Игроки:
{usersStringBuilder}";
        }

        public async Task<Characteristics> GetUserCharacteristicsAsync(long userId)
        {
            return await context.Characteristics.FirstOrDefaultAsync(c => c.User.UserId == userId);
        }
    }
}

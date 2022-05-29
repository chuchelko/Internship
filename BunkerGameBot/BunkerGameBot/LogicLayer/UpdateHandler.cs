namespace BunkerGameBot.LogicLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using BunkerGameBot.DataLayer.Repositories;

    using Telegram.Bot;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;

    internal class UpdateHandler
    {
        private IRepository repository;

        public UpdateHandler(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task HandleAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            if (update.Message.Type != MessageType.Text)
            {
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, "Команда не распознана\nВведите /help, чтобы получить справку");
                return;
            }

            var message = update.Message;
            string messageTextLower = message.Text.ToLower();
            string messageText = message.Text;


            if (messageTextLower == "/start")
            {
                if(await repository.CheckOrCreateUserAsync(message.From.Id, message.Chat.Id, message.From.Username))
                {
                    await botClient.SendTextMessageAsync(message.Chat, $@"Добро пожаловать в игру! Ваше имя: {message.From.Username}
я не допилил кнопки, поэтому пока команды :(
Введите /help для получения справки по командам");
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Вы уже нажимали на старт :(");
                }

                return;
            }

            await repository.CheckOrCreateUserAsync(message.From.Id, message.Chat.Id, message.From.Username);

            if (messageTextLower == "/help")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, @"/create {максимальное количество игроков} {пароль без пробела} - создать игру
/connect {пароль} - подключиться к уже существующей игре
/exit - выйти из игры
/gameinfo - игра");
                return;
            }

            else if(messageTextLower.Split()[0] == "/connect")
            {
                if (messageText.Split().Length > 2)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Пароль не должен содержать пробел: /connect {пароль}");
                }

                try
                {
                    await repository.AddUserInGameAsync(message.From.Id, messageText.Split()[1]);
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Вы подключились к игре");
                    await botClient.SendTextMessageAsync(message.Chat.Id, await repository.GetGameInfo(message.From.Id));
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, ex.Message);
                }
            }

            else if (messageTextLower.Split()[0] == "/create")
            {
                if (messageText.Split().Length > 3)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "/create {максимальное количество игроков} {пароль без пробела}");
                }

                try
                {
                    await repository.CreateGameAsync(message.From.Id, messageText.Split()[2], int.Parse(messageText.Split()[1]));
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Вы создали игру");
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, ex.Message);
                }
            }

            else if(messageTextLower == "/exit")
            {
                try
                {
                    await repository.DeleteUserFromGame(message.From.Id);
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, ex.Message);
                }
            }

            else if(messageTextLower == "/gameinfo")
            {
                try
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, await repository.GetGameInfo(message.From.Id));
                }
                catch(Exception ex)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, ex.Message);
                }
            }
            
            else
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Введите /help для получения справки");

            }

        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exc, CancellationToken cancellationToken)
        {

        }

    }
}

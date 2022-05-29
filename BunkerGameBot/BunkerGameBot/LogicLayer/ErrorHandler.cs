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

    internal class ErrorHandler
    {
        private IRepository repository;

        public ErrorHandler(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task HandleAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
        }

    }
}

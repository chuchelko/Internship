namespace BunkerGameBot
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using BunkerGameBot.LogicLayer;

    using Castle.Windsor;

    using Telegram.Bot;
    using Telegram.Bot.Exceptions;
    using Telegram.Bot.Extensions.Polling;
    using Telegram.Bot.Types;
    using Telegram.Bot.Types.Enums;
    internal class Program
    {
        static void Main(string[] args)
        {
            using var container = new WindsorContainer();
            container.Install(new DICoreInstaller());

            UpdateHandler updateHandler = container.Resolve<UpdateHandler>();
            ErrorHandler errorHandler = container.Resolve<ErrorHandler>();

            var botClient = new TelegramBotClient(Constants.PublicTokenKey);

            ReceiverOptions options = new ReceiverOptions()
            {
                AllowedUpdates = Array.Empty<UpdateType>(),
            };

            CancellationTokenSource cts = new CancellationTokenSource();

            //botClient.SetWebhookAsync("");


            botClient.StartReceiving(
                updateHandler: updateHandler.HandleAsync,
                errorHandler: errorHandler.HandleAsync,
                receiverOptions: options,
                cancellationToken: cts.Token
                );

            while(true)
                if (Console.ReadLine() == "exit")
                    break;

        }

        
    }
}

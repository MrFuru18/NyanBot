using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NyanBot.Services;

namespace NyanBot
{
    public class NyanBot
    {
        private DiscordSocketClient _client;
        private CommandHandler _command;
        //private IServiceProvider _provider;

        public async Task MainAsync()
        {
            CreateModules();
            //var _provider = CreateServiceProvider();

            var token = JsonConvert.DeserializeObject<ConfigJson>(File.ReadAllText("config.json")).Token;
            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();
            await _command.InitializeAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private void CreateModules()
        {
            var config = new DiscordSocketConfig
            {
                //LogLevel = LogSeverity.Debug,
                AlwaysDownloadUsers = false,
                MessageCacheSize = 200,   
                GatewayIntents = GatewayIntents.All
            };

            _client = new DiscordSocketClient(config);
            _client.Log += Log;

            var prefix = JsonConvert.DeserializeObject<ConfigJson>(File.ReadAllText("config.json")).Prefix;

            _command = new CommandHandler(_client, prefix);
        }

        /*private IServiceProvider CreateServiceProvider()
        {
            var collection = new ServiceCollection();

            return collection.BuildServiceProvider();
        }*/

    }

}


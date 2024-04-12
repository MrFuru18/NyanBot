using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;

namespace NyanBot
{
    public class NyanBot
    {
        private static DiscordSocketClient _client;
        public async Task MainAsync()
        {
            var token = JsonConvert.DeserializeObject<ConfigJson>(File.ReadAllText("config.json")).Token;

            var config = new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Debug,
                AlwaysDownloadUsers = false,
                MessageCacheSize = 200
            };

            _client = new DiscordSocketClient();

            _client.Log += Log;


            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
            

            // Block this task until the program is closed.
            await Task.Delay(-1);
        
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }


}


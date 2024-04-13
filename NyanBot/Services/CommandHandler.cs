using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;

namespace NyanBot.Services
{
    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _service;
        private readonly String _prefix;

        public CommandHandler(DiscordSocketClient client, String prefix)
        {
            this._client = client;
            this._service = new CommandService();
            this._prefix = prefix;
        }

        public async Task InitializeAsync()
        {
            await _service.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), 
                                            services: null);

            _client.MessageReceived += HandleCommandAsync;
        }

        private async Task HandleCommandAsync(SocketMessage socketMessage)
        {
            // Don't process the command if it was a system message
            var message = socketMessage as SocketUserMessage;
            if (message == null) return;

            // Don't process the command if it was a bot message
            if(message.Author.IsBot) return;

            // Create a number to track where the prefix ends and the command begins
            var argPos = 0;
            if (!message.HasStringPrefix(_prefix, ref argPos)) return;

            // Create a WebSocket-based command context based on the message
            var context = new SocketCommandContext(_client, message);

            // Execute the command with the command context we just
            // created, along with the service provider for precondition checks.
            await _service.ExecuteAsync(
                context: context, 
                argPos: argPos,
                services: null);
        }
    }
}
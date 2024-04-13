using Discord.Commands;

namespace NyanBot.Modules
{
    public class General : ModuleBase<SocketCommandContext>
    {
        [Command("nyan")]
        [Summary("Nyans at you~.")]
        public async Task NyanAsync()
        {
            await ReplyAsync("Nyan!");
        }
    }
}
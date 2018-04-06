using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunter.Modules
{
    public class Ping : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        public async Task PingAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle("Pong!")
                .WithDescription("Why did you ping me >:(")
                .WithColor(Color.Red);

            await ReplyAsync("", false, builder.Build());

            Console.WriteLine($"{Context.User} Pinged me >:(");
        }
    }
}

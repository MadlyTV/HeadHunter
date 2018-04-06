using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunter.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help"), RequireUserPermission(Discord.GuildPermission.KickMembers)]
        public async Task HelpAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();

            //Not Implemented

            builder.AddField("Help", "Commands that might help you")
                .AddInlineField("!help", "Displays all the commands to use the bot")
                .AddInlineField("!ping", "Pings HeadHunterBot")
                .AddInlineField("!ban {username} {reason}", "Bans the user for reason")
                .AddInlineField("!request staff or managment or owner", "sends a distressbecon to any of the chosen")
                .AddInlineField("!embed or !embed avatar", "embeds a message(only the owner can use this one sorry :/)")
                .WithColor(Color.Red);

            await ReplyAsync("", false, builder.Build());

            Console.WriteLine($"{Context.User} Requested for help");
        }
    }
}

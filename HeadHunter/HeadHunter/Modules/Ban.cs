using Discord;
using Discord.Commands;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunter.Modules
{
    [Group("ban"), RequireUserPermission(Discord.GuildPermission.BanMembers)]
    public class Ban : ModuleBase<SocketCommandContext>
    {
        [Command]
        public async Task BanAsyncUser(SocketGuildUser user, [Remainder] string reason)
        {
            var allBans = await Context.Guild.GetBansAsync();
            bool isBanned = allBans.Select(b => b.User).Where(u => u.Username == user.Username).Any();

            if (!isBanned)
            {
                var targetHighets = (user as SocketGuildUser).Hierarchy;
                var senderHighets = (Context.User as SocketGuildUser).Hierarchy;

                if (targetHighets < senderHighets)
                {
                    var dmChannel = await user.GetOrCreateDMChannelAsync();
                    await dmChannel.SendMessageAsync($"You were banned from **{Context.Guild.Name}** for **{reason}**");

                    var guild = user.Guild;
                    var channel = guild.GetTextChannel(UssefullIDs.BotLogChat);

                    await channel.SendMessageAsync($"**{Context.User}** has banned **{user.Username}** for **{reason}**").ConfigureAwait(false);

                    await Context.Guild.AddBanAsync(user);
                   
                    Console.WriteLine($"{Context.User} has banned {user.Username} for {reason}");
                }
            }
        }
    }
}

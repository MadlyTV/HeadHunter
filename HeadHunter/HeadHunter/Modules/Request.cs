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
    [Group("Request")]
    public class Request : ModuleBase<SocketCommandContext>
    {
        [Command("staff")]
        public async Task RequestStaff()
        {
            var guild = Context.Guild;
            var channel = guild.GetTextChannel(UssefullIDs.StaffChat);
            await Context.Channel.SendMessageAsync($"**{Context.User}** Help is on it's way just stay still");
            await channel.SendMessageAsync($"**{Context.User}** Is in need of assistans at **{Context.Channel}** when someone has time help it");

            Console.WriteLine($"{Context.User} Is in need of assistans at {Context.Channel}");
        }

        [Command("managment"), RequireUserPermission(Discord.GuildPermission.KickMembers)]
        public async Task RequestManagment()
        {
            var guild = Context.Guild;
            var channel = guild.GetTextChannel(UssefullIDs.ManagerChat);
            await Context.Channel.SendMessageAsync($"**{Context.User}** Help is on it's way just stay still");
            await channel.SendMessageAsync($"**{Context.User}** Is in need of assistans at **{Context.Channel}** when someone has time help it");

            Console.WriteLine($"{Context.User} Is in need of assistans at {Context.Channel}");
        }

        [Command("owner")]
        [RequireUserPermission(Discord.GuildPermission.BanMembers)]
        public async Task RequestOwner()
        {
            var owner = Context.Guild.GetUser(UssefullIDs.OwnerID);
            var dmChannel = await owner.GetOrCreateDMChannelAsync();

            await Context.Channel.SendMessageAsync("A message has been sent to **MouthTapedGuy** stay put untill he arrives");
            await dmChannel.SendMessageAsync($"YO, **{Context.User}** needs your help bro, go to **{Context.Channel}** ASAP");

            Console.WriteLine($"{Context.User} is tring to get in contact with mouthtapedguy in {Context.Channel}");
        }
    }
}

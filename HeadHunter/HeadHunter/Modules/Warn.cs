using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunter.Modules
{
    [Group("warn")]
    public class Warn : ModuleBase<SocketCommandContext>
    {
        [Command, RequireUserPermission(Discord.GuildPermission.KickMembers)]
        public async Task WarnAsync(SocketGuildUser user)
        {
            var dmChannel = await user.GetOrCreateDMChannelAsync();
            var wanerdmchannel = await Context.User.GetOrCreateDMChannelAsync();

            await dmChannel.SendMessageAsync($"You have been warned by {Context.User}. If you get 3 warnings you might get banned");
            await wanerdmchannel.SendMessageAsync($"You have warned {user}. Remember if he gets 3 warning he might get banned");

            WebClient client = new WebClient();
            string downloadString = client.DownloadString("phpscriptshostplace get" + user.Id);

            downloadString = client.DownloadString("phpscriptshostplace set" + user.Id);

            EmbedBuilder builder = new EmbedBuilder();

            char[] chars = downloadString.ToCharArray();

            string discordstringstuff = "";

            bool id = false;
            bool number = false;

            string stringid = "";
            string stringnumber = "";

            int Id = 0;
            int Number = 0;

            for (int i = 0; i < downloadString.Length; i++)
            {

                if (chars[i] == '[')
                {
                    if (id == false)
                    {
                        i += 4;
                        id = true;
                        continue;
                    }
                    if (number == false)
                    {
                        i += 15;
                        id = false;
                        number = true;
                        continue;
                    }
                }

                if (chars[i] == '<')
                {
                    i += 3;
                    continue;
                }

                if (id)
                {
                    stringid += chars[i].ToString();
                }

                if (number)
                {
                    stringnumber += chars[i].ToString();
                }

                discordstringstuff = discordstringstuff + chars[i].ToString();
            }

            bool result = int.TryParse(stringid, out Id);

            result = int.TryParse(stringnumber, out Number);

            var role = (user as IGuildUser).Guild.Roles.FirstOrDefault(x => x.Name == "Kings");

            if (user.Roles.Contains(role)) return;

            if (Number >= 3)
            {
                var allBans = await Context.Guild.GetBansAsync();
                bool isBanned = allBans.Select(b => b.User).Where(u => u.Username == user.Username).Any();
                
                if (!isBanned)
                {
                    var targetHighets = (user as SocketGuildUser).Hierarchy;
                    var senderHighets = (Context.User as SocketGuildUser).Hierarchy;

                    if (targetHighets < senderHighets)
                    {
                        await dmChannel.SendMessageAsync($"You were banned from **{Context.Guild.Name}** for **Got to many warnings**");

                        var guild = user.Guild;
                        var channel = guild.GetTextChannel(UssefullIDs.BotLogChat);

                        await channel.SendMessageAsync($"**{Context.User}** has banned **{user}** for **Got to many warnings**");

                        await Context.Guild.AddBanAsync(user);

                        Console.WriteLine($"{Context.User} has banned {user} for Got to many warnings");
                    }
                }
            }
        }

        [Command("get"), RequireUserPermission(Discord.GuildPermission.KickMembers)]
        public async Task GetWarnsAsync(SocketGuildUser user)
        {
            WebClient client = new WebClient();
            string downloadString = client.DownloadString("phpscriptshostplace get"+user.Id);

            EmbedBuilder builder = new EmbedBuilder();

            char[] chars = downloadString.ToCharArray();

            string discordstringstuff = "";

            bool id = false;
            bool number = false;

            string stringid = "";
            string stringnumber = "";

            int Id = 0;
            int Number = 0;

            for (int i = 0; i < downloadString.Length; i++)
            {

                if (chars[i] == '[')
                {
                    if (id == false)
                    {
                        i += 4;
                        id = true;
                        continue;
                    }
                    if (number == false)
                    {
                        i += 15;
                        id = false;
                        number = true;
                        continue;
                    }
                }

                if (chars[i] == '<')
                {
                    i += 3;
                    continue;
                }

                if (id)
                {
                    stringid += chars[i].ToString();
                }

                if (number)
                {
                    stringnumber += chars[i].ToString();
                }

                discordstringstuff = discordstringstuff + chars[i].ToString();
            }

            bool result = int.TryParse(stringid, out Id);

            result = int.TryParse(stringnumber, out Number);

            builder.WithTitle($"Infomation about {user}")
                .AddField("ID", $"{Id}")
                .AddField("UserID",$"{user.Id}")
                .AddField("NumberOfWarns", $"{Number}")
                .WithColor(Color.Red);

            await Context.Channel.SendMessageAsync("",false,builder);
        }
    }
}

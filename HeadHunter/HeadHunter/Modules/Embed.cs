using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunter.Modules
{
    [Group("embed")]
    public class Embed : ModuleBase<SocketCommandContext>
    {
        [Command, RequireOwner]
        public async Task AsyncEmbed(string Title, [Remainder] string Description)
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle(Title)
                .WithDescription(Description)
                .WithColor(Color.Red)
                .WithAuthor(Context.User);

            await Context.Channel.SendMessageAsync("", false, builder.Build());

            Console.WriteLine($"{Context.User} just embeded something in {Context.Channel}");
        }

        [Command("avatar")]
        public async Task AsyncEmbedAvatar(string Title, [Remainder] string Description)
        {
            EmbedBuilder builder = new EmbedBuilder();

            builder.WithTitle(Title)
                .WithDescription(Description)
                .WithColor(Color.Red)
                .WithAuthor(Context.User)
                .WithImageUrl(Context.User.GetAvatarUrl());

            await Context.Channel.SendMessageAsync("", false, builder.Build());

            Console.WriteLine($"{Context.User} just embeded something in {Context.Channel}");
        }
    }
}

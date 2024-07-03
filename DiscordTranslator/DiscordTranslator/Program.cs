using Client.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
// See https://aka.ms/new-console-template for more information

namespace TranslatorBot {
    internal class Program {
        private static DiscordClient Client {get; set;}
        private static CommandsNextExtension Commands {get; set;}
        public static async Task Main(string[] args) {
            var jsonReader = new JsonReader();
            await jsonReader.ReadJson();

            var discordConfig = new DiscordConfiguration {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,

            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;
            await Client.ConnectAsync();
            await Task.Delay(-1);

        }

        private static Task Client_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args) {
                return Task.CompletedTask;
            }
    }
}


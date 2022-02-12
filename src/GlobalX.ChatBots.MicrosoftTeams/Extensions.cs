using GlobalX.ChatBots.Core.Messages;
using GlobalX.ChatBots.Core.People;
using GlobalX.ChatBots.Core.Rooms;
using GlobalX.ChatBots.MicrosoftTeams.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalX.ChatBots.MicrosoftTeams
{
    public static class Extensions
    {
        public static IServiceCollection ConfigureMicrosoftTeamsBot(this IServiceCollection services)
        {
            services.AddTransient<IMessageHandler, MicrosoftTeamsMessageHandler>();
            services.AddTransient<IPersonHandler, MicrosoftTeamsPersonHandler>();
            services.AddTransient<IRoomHandler, MicrosoftTeamsRoomHandler>();
            services.AddTransient<IMicrosoftTeamsMessageActivityParser, MicrosoftTeamsMessageActivityParser>();
            return services;
        }
    }
}

using GlobalX.ChatBots.Core.Messages;
using Microsoft.Bot.Schema;

namespace GlobalX.ChatBots.MicrosoftTeams.Services
{
    public interface IMicrosoftTeamsMessageActivityParser
    {
        Message ParseMessageActivity(IMessageActivity messageActivity);
    }
}

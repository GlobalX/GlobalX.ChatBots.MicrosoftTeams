using System.Threading.Tasks;
using GlobalX.ChatBots.Core.Messages;

namespace GlobalX.ChatBots.MicrosoftTeams.Services
{
    public class MicrosoftTeamsMessageHandler : IMessageHandler
    {
        public Task<Message> SendMessageAsync(Message message)
        {
            throw new System.NotImplementedException();
        }
    }
}

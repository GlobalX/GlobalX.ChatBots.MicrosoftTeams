using System.Threading.Tasks;
using GlobalX.ChatBots.Core.Rooms;

namespace GlobalX.ChatBots.MicrosoftTeams.Services
{
    public class MicrosoftTeamsRoomHandler : IRoomHandler
    {
        public Task<Room> GetRoomAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}

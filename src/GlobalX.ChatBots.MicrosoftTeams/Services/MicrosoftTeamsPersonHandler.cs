using System.Threading.Tasks;
using GlobalX.ChatBots.Core.People;

namespace GlobalX.ChatBots.MicrosoftTeams.Services
{
    public class MicrosoftTeamsPersonHandler : IPersonHandler
    {
        public Task<Person> GetPersonAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}

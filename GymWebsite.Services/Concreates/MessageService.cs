using GymWebsite.Services.Interfaces;

namespace GymWebsite.Services.Concreates
{
    public class MessageService : IMessageService
    {
        public string GetSiteName()
        {
            return "A simple gym website";
        }
    }
}
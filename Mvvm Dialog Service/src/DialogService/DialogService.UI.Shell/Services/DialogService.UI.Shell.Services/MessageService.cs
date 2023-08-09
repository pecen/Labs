using DialogService.UI.Shell.Services.Interfaces;

namespace DialogService.UI.Shell.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}

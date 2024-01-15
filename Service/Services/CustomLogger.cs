using AccomodationApi.Service.Interfaces;

namespace AccomodationApi.Service.Services
{
    public class CustomLogger : ICustomLogger
    {
        public List<string> messages { get; set; } = new List<string>();
        public void LogMessage(string message)
        {
            messages.Add(message);
        }
    }
}

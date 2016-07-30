using GymWebsite.Services.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GymWebsite.Services.Concreates
{
    public class MessageService : IMessageService
    {
        // برای دسترسی به فایل تنظیمات برنامه در یک اسمبلی دیگر
        private readonly IConfigurationRoot _configurationRoot;
        public MessageService(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string GetSiteName()
        {
            // var key1 = _configurationRoot["Key1"];

            return "A simple gym website";
        }
    }
}
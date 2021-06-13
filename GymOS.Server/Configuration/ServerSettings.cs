using GymOS.Services.EmailService.MailchimpService;
using System.Collections.Generic;

namespace GymOS.Server.Configuration
{
    public class ServerSettings
    {
        public MailchimpSettings EmailServiceSettings { get; set; }
        public DefaultUser DefaultUser { get; set; }
        public List<string> DefaultRoles { get; set; }
    }
}

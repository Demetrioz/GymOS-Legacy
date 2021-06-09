using GymOS.Services.EmailService.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GymOS.Services.EmailService.MailchimpService
{
    public class MailchimpService : IEmailService
    {
        private readonly HttpClient HttpClient;
        private MailchimpSettings Settings { get; set; }

        public MailchimpService(
            IHttpClientFactory factory,
            MailchimpSettings settings
        )
        {
            Settings = settings;

            HttpClient = factory.CreateClient();
            HttpClient.BaseAddress = new Uri(settings.BaseUrl);
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"apikey {settings.ApiKey}");
        }

        public async Task<bool> AddSubscriber(EmailSubscription subscriber)
        {
            object requestBody = new
            {
                email_address = subscriber.Email,
                status = "subscribed",
                timestamp_signup = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss"),
                merge_fields = new
                {
                    FNAME = subscriber.FirstName,
                    LNAME = subscriber.LastName
                }
            };

            StringContent requestString = new StringContent(
                JsonConvert.SerializeObject(requestBody),
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response = await HttpClient.PostAsync(
                $"lists/{Settings.ListId}/members",
                requestString
            );

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}

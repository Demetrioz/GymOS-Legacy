using GymOS.Services.EmailService.DTOs;
using System.Threading.Tasks;

namespace GymOS.Services.EmailService
{
    public interface IEmailService
    {
        Task<bool> AddSubscriber(EmailSubscription subscriber);
    }
}

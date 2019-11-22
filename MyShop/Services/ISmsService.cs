using System.Threading.Tasks;
using MyShop.Models;
using Twilio.Rest.Api.V2010.Account;

namespace MyShop.Services
{
    public interface ISmsService
    {
        Task<MessageResource> Send(SmsMessage smsMessage);
    }
}

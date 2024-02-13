using IGEG.ToolShop.Application.Contracts.Email.Models;


namespace IGEG.ToolShop.Application.Contracts.Email
{
    public interface IEmailService
    {
        Task SendMessage(EmailMessage message);
    }
}



namespace IGEG.ToolShop.Application.Contracts.Email.Models
{
    public class EmailMessage
    {
        public string From { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}

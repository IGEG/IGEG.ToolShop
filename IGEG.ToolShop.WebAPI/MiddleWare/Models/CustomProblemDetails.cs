using Microsoft.AspNetCore.Mvc;

namespace IGEG.ToolShop.WebAPI.MiddleWare.Models
{
    public class CustomProblemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}

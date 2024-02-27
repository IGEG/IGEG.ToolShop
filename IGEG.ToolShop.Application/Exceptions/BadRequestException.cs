using FluentValidation.Results;

namespace IGEG.ToolShop.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message){}

        public BadRequestException(string message, ValidationResult validResult) : this(message)
        {
            ValidationErrorsList = validResult.ToDictionary();
        }
        public IDictionary<string, string[]> ValidationErrorsList { get; set; }    
    }
}

using FluentValidation.Results;

namespace IGEG.ToolShop.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<string> ValidationErrorsList { get; set; }    
        public BadRequestException(string message) : base(message){}

        public BadRequestException(string message, ValidationResult validResult) : this(message)
        {
            ValidationErrorsList = new();

            foreach (var error in validResult.Errors)
                ValidationErrorsList.Add(error.ErrorMessage);
        }
    }
}

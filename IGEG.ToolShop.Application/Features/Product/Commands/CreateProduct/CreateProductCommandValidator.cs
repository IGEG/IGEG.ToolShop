using FluentValidation;

namespace IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct
{
    /// <summary>
    /// Validate Product
    /// </summary>
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public const string UrlRegex = "^[a-zA-Z0-9]*$";
        public CreateProductCommandValidator()
        {

            RuleFor(x => x.Name)
               .NotNull().WithMessage("{PropertyName} is should not be null")
               .NotEmpty().WithMessage("{PropertyName} is should not be empty")
               .MaximumLength(150).WithMessage("{PropertyName} cannot be more than 100 char long")
               .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");

            RuleFor(x => x.URL)
                .NotNull().WithMessage("{PropertyName} is should not be null")
                .NotEmpty().WithMessage("{PropertyName} is should not be empty")
                .Matches(UrlRegex).WithMessage("{PropertyName} must contain only English letters and numbers")
                .MaximumLength(150).WithMessage("{PropertyName} cannot be more than 100 char long")
                .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");
        }
    }
}

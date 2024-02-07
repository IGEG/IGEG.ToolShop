using FluentValidation;

namespace IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public const string UrlRegex = "^[a-zA-Z0-9]*$";
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("Необходимо указать имя категории")
                .NotEmpty().WithMessage("Необходимо указать URL категории")
                .MaximumLength(100).WithMessage("Название категории не может быть больше 100 символов")
                .MinimumLength(1).WithMessage("Название категории не может быть меньше 1 символа");

            RuleFor(x => x.Url)
                .NotNull().WithMessage("Необходимо указать URL категории")
                .NotEmpty().WithMessage("Необходимо указать URL категории")
                .Matches(UrlRegex).WithMessage("URL категории должно седержать только английский буквы и символы")
                .MaximumLength(100).WithMessage("Название категории не может быть больше 100 символов")
                .MinimumLength(1).WithMessage("Название категории не может быть меньше 1 символа");
        }
    }
}

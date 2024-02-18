using FluentValidation;
using IGEG.ToolShop.Application.Contracts.Percistance;

namespace IGEG.ToolShop.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public const string UrlRegex = "^[a-zA-Z0-9]*$";
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandValidator(ICategoryRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
              .NotNull().WithMessage("{PropertyName} is should not be null")
              .MustAsync(CategoryMustExist).WithMessage("Category is not exist"); ;

            RuleFor(x => x.Name)
               .NotNull().WithMessage("{PropertyName} is should not be null")
               .NotEmpty().WithMessage("{PropertyName} is should not be empty")
               .MaximumLength(150).WithMessage("{PropertyName} cannot be more than 100 char long")
               .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");

            RuleFor(x => x.Url)
                .NotNull().WithMessage("{PropertyName} is should not be null")
                .NotEmpty().WithMessage("{PropertyName} is should not be empty")
                .Matches(UrlRegex).WithMessage("{PropertyName} must contain only English letters and numbers")
                .MaximumLength(150).WithMessage("{PropertyName} cannot be more than 100 char long")
                .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");
        }

        private async Task<bool> CategoryMustExist(int Id, CancellationToken token)
        {
            var category = await _repository.GetByIdAsync(Id);
            return category != null;
        }
    }
}

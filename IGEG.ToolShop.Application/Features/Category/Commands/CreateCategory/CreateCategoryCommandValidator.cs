using FluentValidation;
using IGEG.ToolShop.Application.Contracts.Percistance;

namespace IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory
{
    /// <summary>
    /// Validate Category
    /// </summary>
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public const string UrlRegex = "^[a-zA-Z0-9]*$";
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandValidator(ICategoryRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is should not be null")
                .NotEmpty().WithMessage("{PropertyName} is should not be empty")
                .MaximumLength(100).WithMessage("{PropertyName} cannot be more than 100 char long")
                .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");

            RuleFor(x => x.Url)
                .NotNull().WithMessage("{PropertyName} is should not be null")
                .NotEmpty().WithMessage("{PropertyName} is should not be empty")
                .Matches(UrlRegex).WithMessage("{PropertyName} must contain only English letters and numbers")
                .MaximumLength(100).WithMessage("{PropertyName} cannot be more than 100 char long")
                .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("{PropertyName} is should not be null")
                .NotEmpty().WithMessage("{PropertyName} is should not be empty")
                .MaximumLength(10000).WithMessage("{PropertyName} cannot be more than 10000 char long")
                .MinimumLength(1).WithMessage("{PropertyName} cannot be less than 1 char");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("{PropertyName} is should not be null")
                .NotEmpty().WithMessage("{PropertyName} is should not be empty")
                .MaximumLength(10000).WithMessage("{PropertyName} cannot be more than 10000 char long");

            RuleFor(x => x)
                .MustAsync(CheckCategoryNameIsUnique)
                .WithMessage("Category name is already exist");
        }

        private async Task<bool> CheckCategoryNameIsUnique(CreateCategoryCommand command, CancellationToken token) =>
            await _repository.CheckCategoryUnique(command.Name!);

    }
}

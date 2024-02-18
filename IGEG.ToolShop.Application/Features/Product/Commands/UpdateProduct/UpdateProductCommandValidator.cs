using FluentValidation;
using IGEG.ToolShop.Application.Contracts.Percistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGEG.ToolShop.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public const string UrlRegex = "^[a-zA-Z0-9]*$";
        private readonly IProductRepository _repository;

        public UpdateProductCommandValidator(IProductRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Id)
              .NotNull().WithMessage("{PropertyName} is should not be null")
              .MustAsync(ProductMustExist).WithMessage("Product is not exist"); ;

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

        private async Task<bool> ProductMustExist(int Id, CancellationToken token)
        {
            var product = await _repository.GetByIdAsync(Id);
            return product != null;
        }
    }
}

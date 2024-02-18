using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IAppLogger<CreateCategoryCommandHandler> _logger;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository, IAppLogger<CreateCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The command {0}  is called for the {1} - {2} ",
                nameof(CreateCategoryCommand), nameof(Category), nameof(request.Name));

            var validator = new CreateCategoryCommandValidator(_repository);
            var validResult = await validator.ValidateAsync(request);

            if (!validResult.IsValid)
            {
                _logger.LogWarn("Vlidation error occurred in class {0} when request for {1} - {2}.",
                    nameof(CreateCategoryCommand), nameof(Category), nameof(request.Name));

                throw new BadRequestException($"Invalid {nameof(CreateCategoryCommand)}", validResult);
            }

            var category = _mapper.Map<Domain.Models.Category>(request);

            await _repository.CreateAsync(category);

            _logger.LogInfo("The {0} - {1} has been successfully created.",
                nameof(Category), nameof(request.Name));

            return category.Id;
        }
    }
}

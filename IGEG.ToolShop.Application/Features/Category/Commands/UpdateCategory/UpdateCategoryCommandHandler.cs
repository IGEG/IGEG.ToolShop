using AutoMapper;
using FluentValidation;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.UpdateCategory
{
    public record UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;
        private readonly IAppLogger<UpdateCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository, IAppLogger<UpdateCategoryCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The command {0}  is called for the {1} - {2} with id = {3} ",
              nameof(UpdateCategoryCommand), nameof(Category), request?.Name ?? "no name", request?.Id ?? 0);

            var validator = new UpdateCategoryCommandValidator(_repository);
            var validResult = await validator.ValidateAsync(request);

            if (!validResult.IsValid)
            {
                _logger.LogWarn("Vlidation error occurred in class {0} when request for {1} - {2}.",
                    nameof(UpdateCategoryCommand), nameof(Category), nameof(request.Name));

                throw new BadRequestException($"Invalid {nameof(UpdateCategoryCommand)}", validResult);
            }

            var category = _mapper.Map<Domain.Models.Category>(request);

            await _repository.UpdateAsync(category);

            return Unit.Value;
        }
    }
}

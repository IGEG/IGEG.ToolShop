using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;
        private readonly IAppLogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(ICategoryRepository repository, IAppLogger<DeleteCategoryCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The command {0}  is called for the {1} with id = {2} ",
                nameof(DeleteCategoryCommand), nameof(Category), nameof(request.Id));

            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null)
            {
                _logger.LogWarn("{0} error occurred. {1} with id = {2} not exist.",
                    nameof(DeleteCategoryCommand), nameof(Category), nameof(request.Id));

                throw new NotFoundException(nameof(Category), request.Id);
            }

            await _repository.DeleteAsync(category);

            _logger.LogInfo("The {0} whit id = {1} has been successfully deleted.",
                nameof(Category), nameof(request.Id));

            return Unit.Value;
        }
    }
}

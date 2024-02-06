using IGEG.ToolShop.Application.Contracts.Percistance;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _repository;

        public DeleteCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(category);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.UpdateCategory
{
    public record UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request.CategoryDto);

            await _repository.UpdateAsync(category);

            return Unit.Value;
        }
    }
}

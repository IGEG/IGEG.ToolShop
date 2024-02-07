using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Domain.Entities.Category>(request.i);
            await _repository.CreateAsync(category);
            return category.Id;
        }
    }
}

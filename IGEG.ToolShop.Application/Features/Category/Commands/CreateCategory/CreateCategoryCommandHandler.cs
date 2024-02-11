using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
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
            var validator = new CreateCategoryCommandValidator(_repository);
            var validResult = await validator.ValidateAsync(request);

            if (!validResult.IsValid)
                throw new BadRequestException($"Invalid {nameof(CreateCategoryCommand)}", validResult);

            var category = _mapper.Map<Domain.Models.Category>(request);

            await _repository.CreateAsync(category);
            return category.Id;
        }
    }
}

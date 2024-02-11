using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator();
            var validResult = await validator.ValidateAsync(request);

            if (!validResult.IsValid)
                throw new BadRequestException($"Invalid {nameof(CreateProductCommand)}", validResult);

            var product = _mapper.Map<Domain.Models.Product>(request);

            await _repository.CreateAsync(product);

            return product.Id;
        }
    }
}

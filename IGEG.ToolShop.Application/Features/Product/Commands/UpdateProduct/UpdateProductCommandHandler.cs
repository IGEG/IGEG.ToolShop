using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Models.Product>(request.ProductDto);

            await _repository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}

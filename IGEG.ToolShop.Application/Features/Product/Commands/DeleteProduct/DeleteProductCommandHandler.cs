using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repository;

        public DeleteProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            await _repository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}

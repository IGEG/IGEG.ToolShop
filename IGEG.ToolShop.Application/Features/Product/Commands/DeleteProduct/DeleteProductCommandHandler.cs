using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _repository;
        private readonly IAppLogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IProductRepository repository, IAppLogger<DeleteProductCommandHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The command {0}  is called for the {1} with id = {2} ",
              nameof(DeleteProductCommand), nameof(Product), nameof(request.Id));

            var product = await _repository.GetByIdAsync(request.Id);

            if (product == null)
            {
                _logger.LogWarn("{0} error occurred. {1} with id = {2} not exist.",
                    nameof(CreateProductCommand), nameof(Product), nameof(request.Id));

                throw new NotFoundException(nameof(Product), request.Id);
            }

            await _repository.DeleteAsync(product);

            return Unit.Value;
        }
    }
}

using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IAppLogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository repository, IAppLogger<UpdateProductCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The command {0}  is called for the {1} - {2} with id = {3} ",
                nameof(UpdateProductCommand), nameof(Product), request?.Name ?? "no name", request?.Id ?? 0);

            var validator = new UpdateProductCommandValidator(_repository);
            var validResult = await validator.ValidateAsync(request);

            if (!validResult.IsValid)
            {
                _logger.LogWarn("Vlidation error occurred in class {0} when request for {1} - {2}.",
                    nameof(UpdateProductCommand), nameof(Product), nameof(request.Name));

                throw new BadRequestException($"Invalid {nameof(CreateProductCommand)}", validResult);
            }

            var product = _mapper.Map<Domain.Models.Product>(request);

            await _repository.UpdateAsync(product);

            _logger.LogInfo("The {0} - {1} has been successfully updated.",
                nameof(Product), nameof(request.Name));

            return Unit.Value;
        }
    }
}

using AutoMapper;
using IGEG.ToolShop.Application.Contracts.Percistance;
using IGEG.ToolShop.Application.Exceptions;
using IGEG.ToolShop.Application.Logging;
using MediatR;

namespace IGEG.ToolShop.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;
        private readonly IAppLogger<CreateProductCommandHandler> _logger;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository repository, IAppLogger<CreateProductCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInfo("The command {0}  is called for the {1} - {2} ",
                nameof(CreateProductCommand), nameof(Product), nameof(request.Name));

            var validator = new CreateProductCommandValidator();
            var validResult = await validator.ValidateAsync(request);

            if (!validResult.IsValid)
            {
                _logger.LogWarn("Vlidation error occurred in class {0} when request for {1} - {2}.",
                    nameof(CreateProductCommand), nameof(Product), nameof(request.Name));

                throw new BadRequestException($"Invalid {nameof(CreateProductCommand)}", validResult);
            }

            var product = _mapper.Map<Domain.Models.Product>(request);

            await _repository.CreateAsync(product);

            _logger.LogInfo("The {0} - {1} has been successfully created.",
                 nameof(Product), nameof(request.Name));

            return product.Id;
        }
    }
}


using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Order.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;

        public AddOrderCommandHandler(IProductWriteRepository productWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var product = new Product
            {
               
                Name = request.Name,
                Description = request.Desc,
                Price = request.Price,
                Stock = request.Stock
            };
            await productWriteRepository.AddAsync(product);
            await productWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}


using EShop.Application.Repositories.OrderRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.AddOrder
{

    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommandRequest, AddOrderCommandResponse>
    {
        private readonly IOrderWriteRepository orderWriteRepository;

        public AddOrderCommandHandler(IOrderWriteRepository orderWriteRepository)
        {
            this.orderWriteRepository = orderWriteRepository;
        }

        public async Task<AddOrderCommandResponse> Handle(AddOrderCommandRequest request, CancellationToken cancellationToken)
        {

            var order = new Order
            {
              
                Description=request.Description,
                Address=request.Address,
            };

            await orderWriteRepository.AddAsync(order);
            await orderWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}

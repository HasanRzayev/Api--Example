using EShop.Application.Features.Commands.Orders.UpdateCatagory;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Products.UpdateProduct
{

    public class UpdateOrderCommanHandler : IRequestHandler<UpdateOrderCommandRequest, UpdateOrderCommandResponse>
    {
        private readonly IOrderWriteRepository orderWriteRepository;

        public UpdateOrderCommanHandler(IOrderWriteRepository orderWriteRepository)
        {
               
            this.orderWriteRepository = orderWriteRepository;
        }

        
        public async Task<UpdateOrderCommandResponse> Handle(UpdateOrderCommandRequest command, CancellationToken cancellationToken)
        {
            await orderWriteRepository.RemoveAsync(command.Id.ToString());
            var order = new Order
            {
                Description = command.Description,
                product_id = command.product_id,
                Address = command.Address,
            };
            await orderWriteRepository.AddAsync(order);

            await orderWriteRepository.SaveChangesAsync();
            return new();
        }

       
    }
}

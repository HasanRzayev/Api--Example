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

namespace EShop.Application.Features.Commands.Customers.UpdateCustomer
{

    public class UpdateCustomerCommanHandler : IRequestHandler<UpdateCustomerCommandRequest, UpdateCustomerCommandResponse>
    {
        private readonly IOrderWriteRepository customerWriteRepository;

        public UpdateCustomerCommanHandler(IOrderWriteRepository customerWriteRepository)
        {
               
            this.customerWriteRepository = customerWriteRepository;
        }

        
        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommandRequest command, CancellationToken cancellationToken)
        {
            await customerWriteRepository.RemoveAsync(command.Id.ToString());
            var order = new Order
            {
                //Id = command.Id,
                //Description = command.Description,
                //product_id = command.product_id,
                //Address = command.Address,
            };
            await customerWriteRepository.AddAsync(order);

            await customerWriteRepository.SaveChangesAsync();
            return new();
        }

       
    }
}

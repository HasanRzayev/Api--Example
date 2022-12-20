using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.DeleteCustomer
{

    public class DeleteOrderCommanHandler : IRequestHandler<DeleteCustomerCommandRequest, DeleteCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository customerWriteRepository;

        public DeleteOrderCommanHandler(ICustomerWriteRepository customerWriteRepository)
        {
            this.customerWriteRepository = customerWriteRepository;
        }

        
        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommandRequest command, CancellationToken cancellationToken)
        {

            await customerWriteRepository.RemoveAsync(command.Id.ToString());
            //var product = await productWriteRepository.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            //if (product == null) return default;
            //_context.Products.Remove(product);
            await customerWriteRepository.SaveChangesAsync();
            return new();
        }

       
    }
}

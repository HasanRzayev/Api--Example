
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Customers.AddCustomer
{

    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandRequest, AddCustomerCommandResponse>
    {
        private readonly ICustomerWriteRepository customerWriteRepository;

        public AddCustomerCommandHandler(ICustomerWriteRepository customerWriteRepository)
        {
            this.customerWriteRepository = customerWriteRepository;
        }

        public async Task<AddCustomerCommandResponse> Handle(AddCustomerCommandRequest request, CancellationToken cancellationToken)
        {

            var customer = new EShop.Domain.Entities.Customer
            {
              Name = request.Name,
            };

            await customerWriteRepository.AddAsync(customer);
            await customerWriteRepository.SaveChangesAsync();
            return new();
        }
    }
}

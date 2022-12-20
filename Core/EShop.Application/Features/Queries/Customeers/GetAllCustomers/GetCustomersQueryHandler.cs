using EShop.Application.RequestParams;
using EShop.Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Application.Repositories.CustomerRepository;

namespace EShop.Application.Features.Queries.Customers.GetAllCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
    {
        private readonly ICustomerReadRepository CustomerReadRepository;

        public GetCustomersQueryHandler(ICustomerReadRepository repository)
        {
            CustomerReadRepository = repository;
        }

        public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = CustomerReadRepository.GetAll(tracking: false).Count();

            var Orders = CustomerReadRepository.GetAll(tracking: false).OrderBy(Order => Order.CreatedTime).Skip(request.Size * request.Page).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Name
            });

            return new()
            {
                Orders = Orders,
                TotalCount = totalCount
            };
        }
    }
}

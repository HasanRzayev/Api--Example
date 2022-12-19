using EShop.Application.RequestParams;
using EShop.Application.Repositories.OrderRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Orders.GetAllOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQueryRequest, GetOrdersQueryResponse>
    {
        private readonly IOrderReadRepository OrderReadRepository;

        public GetOrdersQueryHandler(IOrderReadRepository repository)
        {
            OrderReadRepository = repository;
        }

        public async Task<GetOrdersQueryResponse> Handle(GetOrdersQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = OrderReadRepository.GetAll(tracking: false).Count();

            var Orders = OrderReadRepository.GetAll(tracking: false).OrderBy(Order => Order.CreatedTime).Skip(request.Size * request.Page).Take(request.Size).Select(p => new
            {
                p.Id,
                p.Address,
                p.Description
            });

            return new()
            {
                Orders = Orders,
                TotalCount = totalCount
            };
        }
    }
}

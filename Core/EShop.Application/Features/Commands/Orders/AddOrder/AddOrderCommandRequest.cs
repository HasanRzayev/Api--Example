using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Orders.AddOrder
{
    public class AddOrderCommandRequest : IRequest<AddOrderCommandResponse>
    {
        public Guid product_id   { get; set; }
        public Guid customer_id   { get; set; }

        public string Description   { get; set; }
        public string Address      { get; set; }
    }
}

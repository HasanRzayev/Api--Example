using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Queries.Customer.GetAllCustomers
{
    public class GetCustomersQueryResponse
    {
        public int TotalCount { get; set; }
        public object Orders { get; set; }
    }
}

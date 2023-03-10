using EShop.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public Product product { get; set; }
        public Guid product_id { get; set; }
        public Guid customer_id { get; set; }
        public Customer Customer { get; set; }
    }
}

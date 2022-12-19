using EShop.Application.Repositories.ProductRepository;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Features.Commands.Products.DeleteOrder
{

    public class DeleteOrderCommanHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;

        public DeleteOrderCommanHandler(IProductWriteRepository productWriteRepository)
        {
            this.productWriteRepository = productWriteRepository;
        }

        
        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest command, CancellationToken cancellationToken)
        {

            await productWriteRepository.RemoveAsync(command.Id.ToString());
            //var product = await productWriteRepository.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            //if (product == null) return default;
            //_context.Products.Remove(product);
            await productWriteRepository.SaveChangesAsync();
            return new();
        }

       
    }
}

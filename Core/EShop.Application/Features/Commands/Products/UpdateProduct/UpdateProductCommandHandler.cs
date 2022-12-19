﻿using EShop.Application.Repositories.ProductRepository;
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

    public class UpdateProductCommanHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductWriteRepository productWriteRepository;

        public UpdateProductCommanHandler(IProductWriteRepository productWriteRepository)
        {
               
            this.productWriteRepository = productWriteRepository;
        }

        
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest command, CancellationToken cancellationToken)
        {
            await productWriteRepository.RemoveAsync(command.Id.ToString());
            var product = new Product
            {
                Id = command.Id,
                Name = command.Name,
                Description = command.Desc,
                Price = command.Price,
                Stock = command.Stock
            };
            await productWriteRepository.AddAsync(product);

            await productWriteRepository.SaveChangesAsync();
            return new();
        }

       
    }
}

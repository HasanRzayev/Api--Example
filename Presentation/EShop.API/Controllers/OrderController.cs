using EShop.Application.Features.Commands.Orders.AddOrder;
using EShop.Application.Features.Commands.Orders.DeleteOrder;
using EShop.Application.Features.Commands.Orders.UpdateCatagory;

using EShop.Application.Features.Queries.Orders.GetAllOrders;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.Repositories.OrderRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderReadRepository orderReadRepository;
        private readonly IOrderWriteRepository orderWriteRepository;
        private readonly IMediator mediator;

        public OrderController(IOrderReadRepository OrderReadRepository, IOrderWriteRepository OrderWriteRepository, IMediator mediator)
        {
            this.orderReadRepository = OrderReadRepository;
            this.orderWriteRepository = OrderWriteRepository;
            this.mediator = mediator;
        }




        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetOrdersQueryRequest request)
        {
            //baseurl/api/Orders/getall
            try
            {
                var response = await mediator.Send(request);
                return Ok(response);

            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddOrderCommandRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await mediator.Send(request);


                    return StatusCode((int)HttpStatusCode.Created);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteOrderCommandRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await mediator.Send(request);
                    return Ok(response);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await mediator.Send(request);


                    return StatusCode((int)HttpStatusCode.Created);
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }
        //[HttpGet]
        //public async Task Get()
        //{
        //    await OrderWriteRepository.AddRangeAsync(new()
        //    {
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Order", Stock  = 1, Description = "Babat", Price = 5.6m},
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Order1", Stock  = 2, Description = "Babat1", Price = 51.6m},
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Order2", Stock  = 3, Description = "Babat2", Price = 54.6m},
        //    });
        //    await OrderWriteRepository.SaveChangesAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var Order = await OrderReadRepository.Get(id, tracking: false);
        //    Order.Description = "chox chox babat Order";
        //    await OrderWriteRepository.SaveChangesAsync();
        //    return Ok(Order);
        //}
    }
}

using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Features.Commands.Customers.DeleteCustomer;
using EShop.Application.Features.Commands.Customers.UpdateCustomer;
using EShop.Application.Features.Queries.Customers.GetAllCustomers;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerReadRepository orderReadRepository;
        private readonly ICustomerWriteRepository orderWriteRepository;
        private readonly IMediator mediator;

        public CustomerController(ICustomerReadRepository CustomerReadRepository, ICustomerWriteRepository CustomerWriteRepository, IMediator mediator)
        {
            this.orderReadRepository = CustomerReadRepository;
            this.orderWriteRepository = CustomerWriteRepository;
            this.mediator = mediator;
        }




        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetCustomersQueryRequest request)
        {
            //baseurl/api/Customers/getall
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
        public async Task<IActionResult> Add([FromBody] AddCustomerCommandRequest request)
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
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommandRequest request)
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
        public async Task<IActionResult> Update([FromBody] UpdateCustomerCommandRequest request)
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
        //    await CustomerWriteRepository.AddRangeAsync(new()
        //    {
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Customer", Stock  = 1, Description = "Babat", Price = 5.6m},
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Customer1", Stock  = 2, Description = "Babat1", Price = 51.6m},
        //        new(){Id = Guid.NewGuid(), CreatedTime = DateTime.UtcNow, UpdatedTime= DateTime.UtcNow, Name = "Customer2", Stock  = 3, Description = "Babat2", Price = 54.6m},
        //    });
        //    await CustomerWriteRepository.SaveChangesAsync();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var Customer = await CustomerReadRepository.Get(id, tracking: false);
        //    Customer.Description = "chox chox babat Customer";
        //    await CustomerWriteRepository.SaveChangesAsync();
        //    return Ok(Customer);
        //}
    }
}

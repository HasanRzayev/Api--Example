using EShop.API.Helper.Generation;
using EShop.Domain.ViewModels;
using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Features.Commands.Customers.DeleteCustomer;
using EShop.Application.Features.Commands.Customers.UpdateCustomer;
using EShop.Application.Features.Queries.Customer.GetAllCustomers;
using EShop.Application.Repositories.CustomerRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using EShop.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
 

        private readonly IConfiguration _config;

        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] UserViewModel dto)
        {
            var user = UserRepository.GetUser(dto);
            if (user != null)
            {
                var token = TokenService.GenerateToken(user, _config);
                return Ok(token);
            }
            return NotFound("notfound");
        }

        [HttpGet("some")]
        public IActionResult SomeMethod()
        {
            var user = GetUser();
            return Ok($"Salam {user?.UserName}");
        }

        private User GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    UserName = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                    Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }
    }
}

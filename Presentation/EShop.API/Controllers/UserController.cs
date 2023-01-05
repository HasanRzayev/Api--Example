
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
using EShop.Application.Repositories;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet.Actions;
using PhotoHome.Helpers;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public static Cloudinary cloudinary;

        public const string CLOUD_NAME = "dhtcecrpa";
        public const string API_KEY = "621668164995499";
        public const string API_SECRET = "iLcKxUn6rR_cq9qWiTOV8e9H2VY";
        private readonly IJWTManagerRepository _jWTManager;

       
        private readonly IConfiguration _config;

        public UserController(IConfiguration config, IJWTManagerRepository jWTManager)
        {
            _config = config;
            this._jWTManager = jWTManager;
        }
        public void uploadImage(string imagePath)
        {

            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(imagePath)
                };

                var uploadResult = cloudinary.Upload(uploadParams);

           


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //[HttpPost, ActionName("AddImage")]
        public async Task<IActionResult> AddImage(IFormFile image)
        {

            var path = await UploadFileHelper.UploadFile(image);


            Account account = new(CLOUD_NAME, API_KEY, API_SECRET);

            cloudinary = new Cloudinary(account);


            string imagePath = path;

            uploadImage(imagePath);




            return RedirectToAction("Create");

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(Users usersdata)
        {
            var token = _jWTManager.Authenticate(usersdata);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}

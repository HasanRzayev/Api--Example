
using EShop.Application.Repositories;
using EShop.Domain.Entities;
using EShop.Domain.Entities.Common;
using EShop.Domain.ViewModels;
using EShop.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Persistence.Repositories
{
    public static class UserRepository
    {
        public static List<Users> users = new()
        {
            
        };

        public static void AddUser(Users user) { users.Add(user); }

        public static Users GetUser(UserViewModel user) { return users.FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower() && x.Password == user.Password); }
    }
}

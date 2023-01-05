using EShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.Repositories
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(Users users);
    }

}

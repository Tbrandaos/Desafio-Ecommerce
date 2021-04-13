using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Respository
{
    public interface ITokenRepository
    {
        String GenerateToken(User user);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Queries.Request
{
    public class ObterUserRequest
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}

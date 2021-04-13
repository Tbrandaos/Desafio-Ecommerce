using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class Response<T>
    {
        public Response(T Response) 
        {
            Data = Response;
        }

        public T Data { get; set; }
    }
}

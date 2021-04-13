using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public class PageResponse<T>
    {

        public PageResponse() { }
        public PageResponse(IEnumerable<T> data) 
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}

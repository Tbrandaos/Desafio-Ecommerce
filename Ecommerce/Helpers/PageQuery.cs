using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Helpers
{
    public class PageQuery
    {
        public PageQuery()
        {
            PageNumber = 1;
            PageSize = 20;
        }

        public PageQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = (pageSize > 20) ? 20 : pageSize; 
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

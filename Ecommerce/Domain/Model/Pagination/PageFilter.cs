using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Model.Pagination
{
    public class PageFilter 
    {
        public int Pagenumber { get; set; }
        public int PageSize { get; set; }
    }
}

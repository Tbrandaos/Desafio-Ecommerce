using AutoMapper;
using Ecommerce.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Model.Pagination
{
    public class MapPagination : Profile
    {
        public MapPagination()
        {
            CreateMap<PageQuery, PageFilter>();
        }
    }
}

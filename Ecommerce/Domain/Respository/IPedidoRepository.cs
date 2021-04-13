using Ecommerce.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Ecommerce.Domain.Model.Pagination;

namespace Ecommerce.Domain.Respository
{ 
    public interface IPedidoRepository
    {
        Task<IEnumerable<ObterPedidoResponse>> ListarPedidos(PageFilter filtroPaginacao = null);
    }
    
}

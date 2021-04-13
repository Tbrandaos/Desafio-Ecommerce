using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Respository;
using Ecommerce.Infra.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Ecommerce.Domain.Model;
using Ecommerce.Helpers;
using Ecommerce.Domain.Model.Pagination;

namespace Ecommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ILogger<PedidoController> _logger;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedidoRepository, 
            ILogger<PedidoController> logger,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("GetPedidos")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetPedidos([FromQuery]PageQuery pageable)
        {
            try
            {
                var filtroPaginacao = _mapper.Map<PageFilter>(pageable);

                var pedidos = await _pedidoRepository.ListarPedidos(filtroPaginacao);
                
                if (filtroPaginacao == null || filtroPaginacao.PageSize < 1 || filtroPaginacao.Pagenumber < 1)
                {
                    return Ok(new PageResponse<ObterPedidoResponse>(pedidos));
                }
                
                var paginationResponse = new PageResponse<ObterPedidoResponse>
                {
                    Data = pedidos,
                    PageNumber = filtroPaginacao.Pagenumber >= 1 ? filtroPaginacao.Pagenumber : (int?)null,
                    PageSize = filtroPaginacao.PageSize >= 1 ? filtroPaginacao.PageSize : (int?)null
                };

                return Ok(paginationResponse);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }    
        }
    }
}

using Ecommerce.Domain.Model;
using Ecommerce.Domain.Model.Pagination;
using Ecommerce.Domain.Queries;
using Ecommerce.Domain.Respository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ecommerce.Infra.Services
{
    public class PedidoService : IPedidoRepository
    {
        private readonly DataContext _context;
        public PedidoService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ObterPedidoResponse>> ListarPedidos(PageFilter filtroPaginacao = null)
        {
            
            var pedidos = await _context.Pedido.Select(pedido => new ObterPedidoResponse()
            {
                Id = pedido.Id,
                NumeroIdentificacao = pedido.NumeroIdentificacao,
                Endereco = pedido.Endereco,
                DataEntrega = pedido.DataEntrega,
                DataCriacao = pedido.DataCriacao,
                EquipeId = pedido.Equipe.Id
            })
                .OrderBy(o => o.DataCriacao)
                .ToListAsync();

            if (pedidos != null && pedidos.Any())
            {
                foreach (var pedido in pedidos)
                {
                    var equipe = await (from e in _context.Equipe
                                        where e.Id == pedido.EquipeId
                                        select new ObterEquipeResponse()
                                        {
                                            Id = e.Id,
                                            Nome = e.Nome,
                                            Descricao = e.Descricao,
                                            Placa = e.Placa
                                        }).FirstOrDefaultAsync();
                    List<ObterProdutoResponse> produtos = await (from p in _context.Produto
                                                                 where p.Pedido.Id == pedido.Id
                                                                 select new ObterProdutoResponse()
                                                                 {
                                                                     Id = p.Id,
                                                                     Nome = p.Nome,
                                                                     Descricao = p.Descricao,
                                                                     Valor = p.Valor
                                                                 }).ToListAsync();
                    pedido.Equipe = equipe;
                    pedido.Produtos = produtos;
                }
            }
            else
            {
                throw new Exception("Não existem pedidos");
            }

            if(filtroPaginacao == null || filtroPaginacao.PageSize < 1 || filtroPaginacao.Pagenumber < 1)
            {
                return pedidos;
            }

            var skip = (filtroPaginacao.Pagenumber - 1) * filtroPaginacao.PageSize;

            return pedidos
                .Skip(skip)
                .Take(filtroPaginacao.PageSize)
                .ToList();
        }
    }
}

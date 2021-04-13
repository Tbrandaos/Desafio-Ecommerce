using Ecommerce.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Queries
{
    public class ObterPedidoResponse
    {
        public int Id { get; set; }
        public int EquipeId { get; set; }
        public long NumeroIdentificacao { get; set; }
        public String Endereco { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataCriacao { get; set; }
        public ObterEquipeResponse Equipe { get; set; }
        public List<ObterProdutoResponse> Produtos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Tables
{
    public class Pedido
    {
        public int Id { get; set; }
        public long NumeroIdentificacao { get; set; }
        public String Endereco { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataCriacao { get; set; }
        public Equipe Equipe { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}

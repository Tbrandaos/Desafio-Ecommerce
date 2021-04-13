using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Model
{
    public class Pedido
    {
        public Pedido() { }

        public Pedido(int id, long numeroIdentficacao, string endereco, DateTime dataEntrega, DateTime dataCriacao)
        {
            Id = id;
            NumeroIdentificacao = numeroIdentficacao;
            Endereco = endereco;
            DataEntrega = dataEntrega;
            DataCriacao = dataCriacao;
        }

        public Pedido(long numeroIdentficacao, string endereco, DateTime dataEntrega, DateTime dataCriacao)
            : this(default, numeroIdentficacao, endereco, dataEntrega, dataCriacao)
        {
        }

        public int Id { get; set; }
        public long NumeroIdentificacao { get; set; }
        public String Endereco { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataCriacao { get; set; }

    }
}

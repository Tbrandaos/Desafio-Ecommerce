using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Tables
{
    public class Produto
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public float Valor { get; set; }
        public Pedido Pedido { get; set; }
    }
}

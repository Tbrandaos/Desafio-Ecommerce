using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Tables
{
    public class Equipe
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String Placa { get; set; }
        public List<Pedido> Pedidos { get; set; }
    }
}

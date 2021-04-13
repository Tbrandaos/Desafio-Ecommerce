using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Model
{
    public class Equipe
    {
        public Equipe() { }

        public Equipe(int id, String nome, String descricao, String placa)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Placa = placa;
        }

        public Equipe(String nome, String descricao, String placa)
            : this(default, nome, descricao, placa) { }

        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public String Placa { get; set; }
    }
}

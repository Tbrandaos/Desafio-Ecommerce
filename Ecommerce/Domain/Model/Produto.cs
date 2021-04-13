using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Model
{
    public class Produto
    {
        public Produto() { }

        public Produto(int id, String nome, String descricao, float valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }

        public Produto(String nome, String descricao, float valor)
            : this(default, nome, descricao, valor) { }

        public int Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public float Valor { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemPedidoCliente.Entidades
{
    class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Produto()
        {

        }
        public Produto(string nome, double preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}

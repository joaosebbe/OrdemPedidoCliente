using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdemPedidoCliente.Entidades
{
    class PedidoItem
    {
        public int Quantidade { get; set; }
        public double Preco { get; set; }

        public PedidoItem()
        {

        }
        public PedidoItem(int quantidade, double preco)
        {
            Quantidade = quantidade;
            Preco = preco;
        }

        public double SubTotal()
        {
            return Preco * Quantidade;
        }
    }
}

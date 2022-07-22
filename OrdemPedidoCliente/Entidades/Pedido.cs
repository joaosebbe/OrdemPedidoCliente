using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdemPedidoCliente.Entidades.Enums;

namespace OrdemPedidoCliente.Entidades
{
    class Pedido
    {
        public DateTime Momento { get; set; }
        public PedidoStatus Status { get; set; }
        public Cliente Cliente { get; set; }
        public List<PedidoItem> PedidoItem { get; set; } = new List<PedidoItem>();

        public Pedido()
        {

        }

        public Pedido(DateTime momento, PedidoStatus status, Cliente cliente)
        {
            Momento = momento;
            Status = status;
            Cliente = cliente;
        }
        public void AddItem(PedidoItem pedido)
        {
            PedidoItem.Add(pedido);
        }
        public void RemoveItem(PedidoItem pedido)
        {
            PedidoItem.Remove(pedido);
        }
        public double Total()
        {
            double sum = 0;
            foreach(PedidoItem pedidoItems in PedidoItem)
            {
                sum += pedidoItems.SubTotal();
            }
            return sum;
        }
    }
}

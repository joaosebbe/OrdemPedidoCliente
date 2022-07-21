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

    }
}

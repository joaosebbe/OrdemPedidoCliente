using OrdemPedidoCliente.Entidades;
using OrdemPedidoCliente.Entidades.Enums;
using System;

namespace OrdemPedidoCliente {
    internal class Program {
        static void Main(string[] args) {

            Cliente cliente = new();

            Console.WriteLine("Entre com os dados do cliente:");
            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Email: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Data nascimento: ");
            cliente.DataAniversario = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine();

            Pedido pedido = new();

            Console.WriteLine("Entre com os dados do pedido:");
            Console.Write("Status(Pagamento_Pendente, Processando, Enviado, Entregue): ");
            PedidoStatus status = Enum.Parse<PedidoStatus>(Console.ReadLine());
            Console.Write("Quantos itens tem esse pedido?");
            int itens = int.Parse(Console.ReadLine());

            pedido.Momento = DateTime.Now;
            pedido.Status = status;
            pedido.Cliente = cliente;

            Console.WriteLine();

            for (int i = 0; i < itens; i++)
            {
                Console.WriteLine($"Entre com os dados do #{i+1} item:");
                Console.Write("Nome do produto: ");
                string nomeProduto = Console.ReadLine();
                Console.Write("Preço do produto: ");
                double preco = double.Parse(Console.ReadLine());
                Console.Write("Quantidade: ");
                int quantidade = int.Parse(Console.ReadLine());

                Produto prod = new Produto(nomeProduto, preco);
                PedidoItem pedidoItem = new PedidoItem(quantidade, preco, prod);

                pedido.AddItem(pedidoItem);
            }

            Console.WriteLine("Itens do Pedido:");
        }
    }
}

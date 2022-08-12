using OrdemPedidoCliente.Entidades;
using OrdemPedidoCliente.Entidades.Enums;
using System;
using System.Collections.Generic;

namespace OrdemPedidoCliente {
    internal class Program {
        static void Main(string[] args) {
            #region Entrando com os dados do cliente
            Cliente cliente = new();
            
            Console.WriteLine("Entre com os dados do cliente:");
            Console.Write("Nome: ");
            cliente.Nome = Console.ReadLine();
            Console.Write("Email: ");
            cliente.Email = Console.ReadLine();
            Console.Write("Data nascimento: ");
            cliente.DataAniversario = DateTime.Parse(Console.ReadLine());
            
            Console.WriteLine();
            #endregion

            #region Entrando com o status e quantidade de pedido a ser inserido
            Pedido pedido = new();

            Console.WriteLine("Entre com os dados do pedido:");
            Console.Write("Status(Pagamento_Pendente, Processando, Enviado, Entregue): ");
            PedidoStatus status = Enum.Parse<PedidoStatus>(Console.ReadLine());
            Console.Write("Quantos itens tem esse pedido?");
            int itens = int.Parse(Console.ReadLine());

            pedido.Momento = DateTime.Now;
            pedido.Status = status;
            pedido.Cliente = cliente;
            #endregion

            #region Entrando com o nome, preço e quantidade de cada item do pedido e adicionando na lista

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
            #endregion

            #region Exibindo o sumário com informações do pedido e cliente
            Console.WriteLine();

            Console.WriteLine("SUMÁRIO DO PEDIDO:");
            Console.WriteLine("Momento do pedido: " + pedido.Momento);
            Console.WriteLine("Status do pedido: " + pedido.Status);
            Console.WriteLine("Cliente: " + pedido.Cliente.Nome + " (" + string.Format("{0:dd/MM/yyyy}", pedido.Cliente.DataAniversario) + ")" + " - " + pedido.Cliente.Email);

            #endregion

            #region Exibindo os itens com o nome, preço, quantidade, subtotal.E por fim, o total do pedido
            Console.WriteLine();

            Console.WriteLine("Itens do Pedido:");

            foreach(PedidoItem item in pedido.PedidoItem)
            {
                Console.WriteLine(item.Produto.Nome + ", $" + item.Preco + ", Quantidade: " + item.Quantidade + ", Subtotal: $" + item.SubTotal()); ;
            }
            Console.WriteLine();

            Console.WriteLine("Preço Total: $" + pedido.Total());
            #endregion
        }
    }
}

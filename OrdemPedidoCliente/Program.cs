using OrdemPedidoCliente.Entidades;
using OrdemPedidoCliente.Entidades.Enums;
using System;
using System.Collections.Generic;

namespace OrdemPedidoCliente {
    internal class Program {
        static void Main(string[] args) {
            #region Entrando com os dados do cliente
            
            Console.WriteLine("Entre com os dados do cliente:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Data nascimento: ");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            Cliente cliente = new Cliente(nome, email, dataNascimento);

            Console.WriteLine();

            #endregion

            #region Entrando com o status e quantidade de itens a ser inseridos

            Console.WriteLine("Entre com os dados do pedido:");
            Console.Write("Status(Pagamento_Pendente, Processando, Enviado, Entregue): ");
            PedidoStatus status = Enum.Parse<PedidoStatus>(Console.ReadLine());

            Pedido pedido = new Pedido(DateTime.Now, status, cliente);

            Console.Write("Quantos itens tem esse pedido?");
            int itens = int.Parse(Console.ReadLine());

            Console.WriteLine();

            #endregion

            #region Entrando com o nome, preço e quantidade de cada item do pedido e adicionando na lista

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

            Console.WriteLine();

            #endregion

            #region Exibindo o sumário com informações do pedido e cliente; Exibindo os itens com o nome, preço, quantidade, subtotal.E por fim, o total do pedido

            Console.WriteLine("SUMÁRIO DO PEDIDO:");
            Console.WriteLine(pedido);

            Console.WriteLine();

            Console.WriteLine("Itens do Pedido:");

            foreach(PedidoItem item in pedido.PedidoItem)
            {
                Console.WriteLine(item.Produto.Nome + ", $" + item.Preco + " , Quantidade: " + item.Quantidade + ", Subtotal: $" + item.SubTotal().ToString("F2")); ;
            }
            Console.WriteLine();

            Console.WriteLine("Preço Total: $" + pedido.Total().ToString("F2"));
            
            Console.WriteLine();

            #endregion
        }
    }
}

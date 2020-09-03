using LivrosECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using LivrosECommerce.Repositories;
using System.Collections.Generic;
using LivrosECommerce.Models.ViewModels;

namespace LivrosECommerce.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository pedidoRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
                IPedidoRepository pedidoRepository,
                    IItemPedidoRepository itemPedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
            this.produtoRepository = produtoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                pedidoRepository.AddItem(codigo);
            }

            List<ItemPedido> itens = pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        public IActionResult Cadastro()
        {
            var pedido = pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
        }

        [HttpPost]
        public IActionResult Resumo(Cadastro cadastro)
        {
            return View(pedidoRepository.GetPedido());
        }

        [HttpPost]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return pedidoRepository.UpdateQuantidade(itemPedido);
        }
    }
}

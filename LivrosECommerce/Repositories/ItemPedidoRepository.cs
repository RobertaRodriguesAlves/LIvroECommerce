﻿using System.Linq;
using LivrosECommerce.Models;

namespace LivrosECommerce.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
        void RemoveItemPedido(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext context) : base(context) {}

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return dbSet
                .Where(ip => ip.Id == itemPedidoId)
                    .SingleOrDefault();
        }

        public void RemoveItemPedido(int itemPedidoId)
        {
            dbSet.Remove(GetItemPedido(itemPedidoId));
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace LivrosECommerce.Models
{
    [DataContract]
    public class ItemPedido : BaseModel
    {
        public ItemPedido() { }

        [Required, DataMember]
        public Pedido Pedido { get; private set; }
        [Required, DataMember]
        public Produto Produto { get; private set; }
        [Required, DataMember]
        public int Quantidade { get; private set; }
        [Required, DataMember]
        public decimal PrecoUnitario { get; private set; }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }

        [DataMember]
        public decimal Subtotal
        {
            get
            {
                return Quantidade * PrecoUnitario;
            }
        }
    }
}

using LivrosECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace LivrosECommerce
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(prod => prod.Id);

            modelBuilder.Entity<Pedido>().HasKey(ped => ped.Id);
            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Itens).WithOne(itped => itped.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(pedcad => pedcad.Cadastro).WithOne(pedcad => pedcad.Pedido).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(itped => itped.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(itped => itped.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(itprod => itprod.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(cadped => cadped.Pedido);
        }
    }
}

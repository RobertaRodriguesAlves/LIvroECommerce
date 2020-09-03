using System.Linq;
using LivrosECommerce.Models;
using System.Collections.Generic;

namespace LivrosECommerce.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext context) : base(context) {}

        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();
        }

        public void SaveProdutos(List<Livro> livros)
        {
            foreach (var livro in livros)
            {
                //adiciona um novo produto no DB se ele ainda não existir
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())
                {
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                }
            }

            //Grava no DB
            context.SaveChanges();
        }
    }

    public class Livro
    {
        public string Codigo { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }
    }
}

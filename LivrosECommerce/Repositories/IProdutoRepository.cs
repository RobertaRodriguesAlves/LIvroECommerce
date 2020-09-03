using LivrosECommerce.Models;
using System.Collections.Generic;

namespace LivrosECommerce.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}
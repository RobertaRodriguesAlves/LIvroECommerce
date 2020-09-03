using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using LivrosECommerce.Repositories;

namespace LivrosECommerce
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext context, 
            IProdutoRepository produtoRepository)
        {
            this.context = context;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            //Gera um DB caso não exista
            context.Database.EnsureCreated();

            List<Livro> livros = GetLivros();

            produtoRepository.SaveProdutos(livros);
        }
        

        private static List<Livro> GetLivros()
        {
            //Acessa arquivo json
            var json = File.ReadAllText("livros.json");
            //converte arquivon json em objeto
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
    
}

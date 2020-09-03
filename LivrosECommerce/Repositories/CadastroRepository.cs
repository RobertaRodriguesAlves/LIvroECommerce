using LivrosECommerce.Models;

namespace LivrosECommerce.Repositories
{
    public interface ICadastroRepository {}

    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context) {}
    }
}

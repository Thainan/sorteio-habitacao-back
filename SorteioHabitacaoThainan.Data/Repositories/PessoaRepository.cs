using SorteioHabitacaoThainan.Data.Context;
using SorteioHabitacaoThainan.Data.Repositories.Interfaces;
using SorteioHabitacaoThainan.Dominio;

namespace SorteioHabitacaoThainan.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(AppDbContext appContext) : base(appContext)
        {

        }
    }
}

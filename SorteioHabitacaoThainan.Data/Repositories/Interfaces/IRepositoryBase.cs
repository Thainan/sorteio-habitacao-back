using SorteioHabitacaoThainan.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SorteioHabitacaoThainan.Data.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Obter(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task DeletarAsync(TEntity entity);
        Task Atualizar(TEntity entity);
    }
}

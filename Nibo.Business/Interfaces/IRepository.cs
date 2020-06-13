using Nibo.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nibo.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<List<TEntity>> ObterTodos();
        Task<TEntity> ObterPorId(Guid id);
    }
    
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transfer.Core.Entity;

namespace Transfer.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<TContext,TEntity>:IQueryableRepository<TEntity> where TEntity:class,IEntity,new() where TContext : DbContext,new()
    {
        private DbContext? _context;
        private DbSet<TEntity>? _entities;
        public EfQueryableRepository()
        {
            _context = new TContext();
        }
        public IQueryable<TEntity> Table => this.Entities;

        protected virtual DbSet<TEntity> Entities
        {
            get { return _entities ?? (_entities = _context.Set<TEntity>()); }
        }
    }
}

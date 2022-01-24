using BLL.Data;
using BLL.Interfaces;
using DAL.Data;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _context;
        private DbSet<T> _entities;
        public Repository(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context.CreateDbContext();
            _entities = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;

            _entities.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            entity.UpdatedAt = DateTime.UtcNow;

            _entities.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _entities.FindAsync(id);

            if (entity == null)
            {
                throw new Exception("Entity not found");
            }

            _entities.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _entities.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken, ExpressionStarter<T>? predicate = null)
        {
            if (predicate == null)
            {
                predicate = PredicateBuilder.New<T>(true);
            }

            return await _entities.Where(predicate).ToListAsync(cancellationToken);
        }
    }
}

using BLL.Data;
using BLL.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private ApplicationDbContext _context;
        private DbSet<Answer> _entities;
        public AnswerRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
            _context = context.CreateDbContext();
            _entities = _context.Set<Answer>();
        }

        public async Task<IReadOnlyDictionary<Guid, List<Answer>>> GetByTickedIdAsync(IReadOnlyList<Guid> ids)
        {
            return await _entities
                .Where(answer => ids.Contains(answer.TicketId))
                .OrderBy(ord => ord.CreatedAt)
                .GroupBy(g => g.TicketId)
                .Select(_ => new
                {
                    key = _.Key,
                    value = _.ToList()
                })
                .ToDictionaryAsync(_ => _.key, _ => _.value); 
        }
    }
}

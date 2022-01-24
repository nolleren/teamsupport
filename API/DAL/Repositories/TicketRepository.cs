using BLL.Data;
using BLL.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
    }
}

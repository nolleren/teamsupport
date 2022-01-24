using BLL.Data;
using BLL.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
		public UserRepository(IDbContextFactory<ApplicationDbContext> context) : base(context)
        {
        }
	}
}

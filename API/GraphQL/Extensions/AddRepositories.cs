using BLL.Interfaces;
using BLL.Settings;
using DAL.Repositories;

namespace GraphQL.Extensions
{
    public static class AddRepositories
    {
		public static void AddRepositoriesExtension(this IServiceCollection services, IConfiguration config)
		{
			// Map repositories
			services.Configure<TokenSettings>(config.GetSection(nameof(TokenSettings)));
			services.AddSingleton<IUserRepository, UserRepository>();
			services.AddSingleton<ITicketRepository, TicketRepository>();
			services.AddSingleton<IAnswerRepository, AnswerRepository>();
		}
	}
}

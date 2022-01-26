using GraphQL.Data.Answers;
using GraphQL.Data.Tickets;
using GraphQL.Data.Users;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Extensions
{
	public static class AddQueries
	{
		public static IRequestExecutorBuilder AddQueriesExtension(this IRequestExecutorBuilder builder)
		{
			return builder
				.AddQueryType()
				.AddTypeExtension<UserQueries>()
				.AddTypeExtension<TicketQueries>()
				.AddTypeExtension<AnswerQueries>();
		}
	}
}

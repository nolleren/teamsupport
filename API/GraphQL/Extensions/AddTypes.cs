using GraphQL.Data.Answers;
using GraphQL.Data.Tickets;
using GraphQL.Data.Users;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Extensions
{
	public static class AddTypes
	{
		public static IRequestExecutorBuilder AddTypesExtension(this IRequestExecutorBuilder builder)
		{
			return builder
				.AddType<UserType>()
				.AddType<TicketType>()
				.AddType<AnswerType>();
		}
	}
}

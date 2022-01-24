using GraphQL.API.Answers;
using GraphQL.API.Tickets;
using GraphQL.API.Users;
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

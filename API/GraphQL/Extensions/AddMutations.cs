using GraphQL.API.Answers;
using GraphQL.API.Tickets;
using GraphQL.API.Users;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Extensions
{
    public static class AddMutations
    {
        public static IRequestExecutorBuilder AddMutationsExtension(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddMutationType()
                .AddTypeExtension<UserMutations>()
                .AddTypeExtension<TicketMutations>()
                .AddTypeExtension<AnswerMutations>();



        }
    }
}

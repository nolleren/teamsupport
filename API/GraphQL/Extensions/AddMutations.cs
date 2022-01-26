using GraphQL.Data.Answers;
using GraphQL.Data.Tickets;
using GraphQL.Data.Users;
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

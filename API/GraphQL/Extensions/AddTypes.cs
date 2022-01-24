using GraphQL.API.Answers;
using GraphQL.API.Tickets;
using GraphQL.API.Users;
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

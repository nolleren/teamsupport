using GraphQL.API.Subscriptions;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Extensions
{
    public static class AddSubscriptions
    {
        public static IRequestExecutorBuilder AddSubscriptionsExtension(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddSubscriptionType()
                .AddTypeExtension<AnswerSubscription>();
        }
    }
}

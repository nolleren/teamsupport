using BLL.DataLoader;
using HotChocolate.Execution.Configuration;

namespace GraphQL.Extensions
{
    public static class AddDataLoaders
    {
        public static IRequestExecutorBuilder AddDataLoadersExtension(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddDataLoader<UserByIdDataLoader>()
                .AddDataLoader<AnswerBatchDataLoader>();
        }
    }
}

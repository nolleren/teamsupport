using BLL.Data;
using GraphQL.Data.DataLoader;

namespace GraphQL.Data.Resolvers
{
    public class UserResolver
    {
        public async Task<User?> GetUserAsync(
                [Parent] Answer answer,
                UserByIdDataLoader userById,
                CancellationToken cancellationToken)
        {
            return await userById.LoadAsync(answer.UserId, cancellationToken);
        }
    }
}

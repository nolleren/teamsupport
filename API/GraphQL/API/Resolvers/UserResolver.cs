using BLL.Data;
using BLL.DataLoader;

namespace GraphQL.API.Resolvers
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

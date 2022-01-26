using BLL.Data;
using BLL.Interfaces;
using GraphQL.Data.Subscriptions;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Subscriptions;

namespace GraphQL.Data.Users
{
    [ExtendObjectType(OperationTypeNames.Query)]
    [Authorize]
    public class UserQueries
    {
        public async Task<List<User>> GetUsers([Service] IUserRepository userRepository, CancellationToken cancellationToken)
        => await userRepository.GetAllAsync(cancellationToken);

        public async Task<User?> GetUserById(Guid id, [Service] IUserRepository userRepository, CancellationToken cancellationToken)
        => await userRepository.GetByIdAsync(id, cancellationToken);

        public async Task<User?> GetCurrentuser([GlobalState("currentUser")] User user, [Service] ITopicEventSender eventSender)
        {
            await eventSender.SendAsync(
                nameof(AnswerSubscription.AnswerAdded),
                new Answer
                {
                    Id = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Text = "This is a subscription",
                    UserId = user.Id,
                    TicketId = Guid.NewGuid(),
                });

            return user;
        }
    }
}

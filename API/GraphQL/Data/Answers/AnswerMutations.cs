using GraphQL.Data.Common;
using BLL.Data;
using BLL.Interfaces;
using HotChocolate.Subscriptions;
using GraphQL.Data.Subscriptions;
using Microsoft.AspNetCore.Authorization;

namespace GraphQL.Data.Answers
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AnswerMutations
    {
        [Authorize]
        public async Task<AnswerPayload> AddAnswerAsync(
            AnswerInput input,
            [Service] IAnswerRepository repository,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Text))
            {
                return new AnswerPayload(
                    new UserError("The text cannot be empty.", "TEXT_EMPTY"));
            }

            var answer = new Answer
            {
                Id = Guid.NewGuid(),
                TicketId = input.TickedId,
                UserId = input.UserId,
                Text = input.Text,
            };

            var createdAnswer = await repository.CreateAsync(answer, cancellationToken);

            await eventSender.SendAsync(
                nameof(AnswerSubscription.AnswerAdded),
                createdAnswer);

            return new AnswerPayload(createdAnswer);
        }

        [Authorize]
        public async Task<AnswerPayload> UpdateAnswerAsync(
            Guid id,
            AnswerInput input,
            [Service] IAnswerRepository repository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Text))
            {
                return new AnswerPayload(
                    new UserError("The text cannot be empty.", "TEXT_EMPTY"));
            }

            var answer = new Answer
            {
                Id = id,
                TicketId = input.TickedId,
                UserId = input.UserId,
                Text = input.Text,
            };

            var updatedAnswer = await repository.UpdateAsync(answer, cancellationToken);

            return new AnswerPayload(updatedAnswer);
        }

        [Authorize]
        public async Task<AnswerPayload> DeleteAnswerAsync(
            Guid id,
            [Service] IAnswerRepository repository,
            CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(id, cancellationToken);

            return new AnswerPayload();
        }
    }
}

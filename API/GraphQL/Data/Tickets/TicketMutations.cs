using GraphQL.Data.Common;
using BLL.Data;
using BLL.Interfaces;
using GraphQL.Data.Answers;
using HotChocolate.Subscriptions;
using GraphQL.Data.Subscriptions;
using Microsoft.AspNetCore.Authorization;

namespace GraphQL.Data.Tickets
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class TicketMutations
    {
        [Authorize]
        public async Task<TicketPayload> AddTicketAsync(
            TicketInput input,
            [Service] ITicketRepository repository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Question))
            {
                return new TicketPayload(
                    new UserError("The question cannot be empty.", "QUESTION_EMPTY"));
            }

            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                CustomerId = input.CustomerId,
                Question = input.Question,
                AssignedTo = input.AssignedTo,
            };

            var createdTicket = await repository.CreateAsync(ticket, cancellationToken);

            return new TicketPayload(createdTicket);
        }

        [Authorize]
        public async Task<TicketPayload> UpdateTicketAsync(
            TicketInput input,
            AnswerInput answerInput,
            [Service] ITicketRepository ticketRepository,
            [Service] IAnswerRepository answerRepository,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Question))
            {
                return new TicketPayload(
                    new UserError("The question cannot be empty.", "QUESTION_EMPTY"));
            }

            var answer = new Answer
            {
                Id = Guid.NewGuid(),
                TicketId = answerInput.TickedId,
                UserId = answerInput.UserId,
                Text = answerInput.Text,
            };

            var createdAnswer = await answerRepository.CreateAsync(answer, cancellationToken);

            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                CustomerId = input.CustomerId,
                Question = input.Question,
                AssignedTo= input.AssignedTo,
            };

            var updatedTicket = await ticketRepository.UpdateAsync(ticket, cancellationToken);

            await eventSender.SendAsync(
                nameof(TicketSubscription.TicketUpdated),
                new TicketPayload(updatedTicket, createdAnswer));

            return new TicketPayload(updatedTicket, createdAnswer);
        }

        [Authorize]
        public async Task<TicketPayload> CloseTicketAsync(
            Guid id,
            [Service] ITicketRepository repository,
            CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(id, cancellationToken);

            if (entity == null)
            {
                return new TicketPayload(
                    new UserError("Ticket not found.", "TICKET_NOT_FOUND")
                );
            }

            var ticket = new Ticket
            {
                Id = id,
                CustomerId = entity.CustomerId,
                Question = entity.Question,
                AssignedTo = null,
                CaseClosed = true
            };

            var updatedTicket = await repository.UpdateAsync(ticket, cancellationToken);

            return new TicketPayload(updatedTicket);
        }

        [Authorize]
        public async Task<TicketPayload> DeleteTicketAsync(
            Guid id,
            [Service] ITicketRepository repository,
            CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(id, cancellationToken);

            return new TicketPayload();
        }
    }
}

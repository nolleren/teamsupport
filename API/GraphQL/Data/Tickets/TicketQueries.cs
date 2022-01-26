using BLL.Data;
using BLL.Interfaces;
using HotChocolate.AspNetCore.Authorization;

namespace GraphQL.Data.Tickets
{
    [ExtendObjectType(OperationTypeNames.Query)]
    [Authorize]
    public class TicketQueries
    {
        public async Task<List<Ticket>> GetTickets([Service] ITicketRepository ticketRepository, CancellationToken cancellationToken)
        => await ticketRepository.GetAllAsync(cancellationToken);

        public async Task<Ticket?> GetTicketById(Guid id, [Service] ITicketRepository ticketRepository, CancellationToken cancellationToken)
        => await ticketRepository.GetByIdAsync(id, cancellationToken);
    }
}

namespace GraphQL.API.Tickets
{
    public record TicketInput(
        Guid CustomerId,
        string Question,
        Guid? AssignedTo
    );
}

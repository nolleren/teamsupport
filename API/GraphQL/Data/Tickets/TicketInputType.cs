namespace GraphQL.Data.Tickets
{
    public record TicketInput(
        Guid CustomerId,
        string Question,
        Guid? AssignedTo
    );
}

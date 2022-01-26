using GraphQL.Data.Tickets;

namespace GraphQL.Data.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class TicketSubscription
    {
        [Subscribe]
        public TicketPayload TicketUpdated([EventMessage] TicketPayload payload) => payload;
    }
}

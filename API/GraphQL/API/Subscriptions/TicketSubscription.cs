using GraphQL.API.Tickets;

namespace GraphQL.API.Subscriptions
{
    [ExtendObjectType(OperationTypeNames.Subscription)]
    public class TicketSubscription
    {
        [Subscribe]
        public TicketPayload TicketUpdated([EventMessage] TicketPayload payload) => payload;
    }
}

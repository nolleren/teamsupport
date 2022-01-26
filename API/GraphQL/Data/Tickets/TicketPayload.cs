using GraphQL.Data.Common;
using BLL.Data;

namespace GraphQL.Data.Tickets
{
    public class TicketPayload
    {
        public TicketPayload(UserError error)
        {
            Errors = new[] { error };
        }

        public TicketPayload(Ticket ticket)
        {
            Ticket = ticket;
        }

        public TicketPayload(Ticket ticket, Answer answer)
        {
            Ticket = ticket;
            Answer = answer;
        }

        public TicketPayload()
        {
        }

        protected TicketPayload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public IReadOnlyList<UserError>? Errors { get; }
        public Ticket? Ticket { get; set; }
        public Answer? Answer { get; set; }
    }
}

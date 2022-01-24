using BLL.DataLoader;
using BLL.Data;
using HotChocolate;
using HotChocolate.Types;
using GraphQL.API.Resolvers;

namespace GraphQL.API.Tickets
{
    public class TicketType : ObjectType<Ticket>
    {
        protected override void Configure(IObjectTypeDescriptor<Ticket> descriptor)
        {
            descriptor
                .Field(t => t.Id)
                .Description("Id for Answer")
                .ID(nameof(Ticket));

            descriptor
                .Field(t => t.CustomerId)
                .ResolveWith<UserResolver>(t => t.GetUserAsync(default!, default!, default))
                .Name("User");

            descriptor
                .Field(t => t.Id)
                .ResolveWith<AnswerResolver>(t => t.GetAnswersAsync(default!, default!))
                .Name("Answers");
        }
    }
}

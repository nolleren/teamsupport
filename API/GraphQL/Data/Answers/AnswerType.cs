using BLL.Data;
using GraphQL.Data.Resolvers;

namespace GraphQL.Data.Answers
{
    public class AnswerType : ObjectType<Answer>
    {
        protected override void Configure(IObjectTypeDescriptor<Answer> descriptor)
        {
            descriptor
                .Field(t => t.Id)
                .Description("Id for Answer")
                .ID(nameof(Answer));

            descriptor
                .Field(t => t.UserId)
                .ResolveWith<UserResolver>(t => t.GetUserAsync(default!, default!, default))
                .Name("User");
        }
    }
}

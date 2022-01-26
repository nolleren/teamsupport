using BLL.Data;
using HotChocolate.Types;

namespace GraphQL.API.Users
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor
                .Field(t => t.Id)
                .Description("Id for User")
                .ID(nameof(User));

            descriptor
                .Field(t => t.UserType)
                .Description("Type can be either Customer or Staff");

            descriptor.Ignore(t => t.Password);
        }
    }
}

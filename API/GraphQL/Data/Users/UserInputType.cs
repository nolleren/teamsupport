using BLL.Data;

namespace GraphQL.Data.Users
{
    public record UserInput(
        string Username,
        string Email,
        string Pasword,
        UserEnumType UserType
    );
}

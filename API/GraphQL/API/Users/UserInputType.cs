using BLL.Data;

namespace GraphQL.API.Users
{
    public record UserInput(
        string Username,
        string Email,
        string Pasword,
        UserEnumType UserType
    );
}

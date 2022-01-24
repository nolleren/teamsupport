using GraphQL.Common;
using BLL.Data;

namespace GraphQL.API.Users
{
    public class UserPayload
    {
        public UserPayload(UserError error)
        {
            Errors = new[] { error };
        }

        public UserPayload(User entity)
        {
            User = entity;
        }

        public UserPayload()
        {
        }
        public UserPayload(string token)
        {
            Token = token;
        }


        protected UserPayload(IReadOnlyList<UserError>? errors = null)
        {
            Errors = errors;
        }

        public User? User { get; }
        public string? Token { get; set; }
        public IReadOnlyList<UserError>? Errors { get; }
    }
}

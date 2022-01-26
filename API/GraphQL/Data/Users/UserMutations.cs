using GraphQL.Data.Common;
using BLL.Data;
using BLL.Interfaces;
using LinqKit;
using BLL.Helpers;
using BLL.Settings;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace GraphQL.Data.Users
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    [Authorize]
    public class UserMutations
    {
        [AllowAnonymous]
        public async Task<UserPayload> LoginUserAsync(
            string email,
            string password,
            [Service] IUserRepository repository,
            [Service] IOptions<TokenSettings> tokenSettings,
            CancellationToken cancellationToken)
        {
            var userPassword = PasswordHelper.PasswordHash(password, email);
            var predicate = PredicateBuilder.New<User>(true);
            predicate.And(x => x.Email == email && x.Password == userPassword);
            var users = await repository.GetAllAsync(cancellationToken, predicate);
            var user = users.FirstOrDefault();

            if (user is null)
            {
                return new UserPayload( 
                    new UserError("Email or password is not correct", "USER_EMPTY"));
            }

            var token = TokenHelpers.GetJWTAuthKey(user, tokenSettings);

            return new UserPayload(token);
        }

        public async Task<UserPayload> AddUserAsync(
            UserInput input,
            [Service] IUserRepository repository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Username))
            {
                return new UserPayload(
                    new UserError("The username cannot be empty.", "USERNAME_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.Email))
            {
                return new UserPayload(
                    new UserError("The email cannot be empty.", "EMAIL_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.Pasword))
            {
                return new UserPayload(
                    new UserError("The password cannot be empty.", "PASWORD_EMPTY"));
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = input.Username,
                Email = input.Email,
                Password = PasswordHelper.PasswordHash(input.Pasword, input.Email),
                UserType = input.UserType
            };

            var createdUser = await repository.CreateAsync(user, cancellationToken);

            return new UserPayload(createdUser);
        }

        public async Task<UserPayload> UpdateUserAsync(
            Guid id,
            UserInput input,
            [Service] IUserRepository repository,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(input.Username))
            {
                return new UserPayload(
                    new UserError("The username cannot be empty.", "USERNAME_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.Email))
            {
                return new UserPayload(
                    new UserError("The email cannot be empty.", "EMAIL_EMPTY"));
            }

            if (string.IsNullOrEmpty(input.Pasword))
            {
                return new UserPayload(
                    new UserError("The password cannot be empty.", "PASWORD_EMPTY"));
            }

            var user = new User
            {
                Id = id,
                Username = input.Username,
                Email = input.Email,
                Password = input.Pasword,
                UserType = input.UserType
            };

            var createdUser = await repository.UpdateAsync(user, cancellationToken);

            return new UserPayload(createdUser);
        }

        public async Task<UserPayload> DeleteUserAsync(
            Guid id,
            [Service] IUserRepository repository,
            CancellationToken cancellationToken)
        {
            await repository.DeleteAsync(id, cancellationToken);

            return new UserPayload();
        }
    }
}

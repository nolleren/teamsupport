using BLL.Data;
using BLL.Interfaces;
using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using System.Security.Claims;

namespace GraphQL.Extensions
{
    public class HttpRequestInterceptor : DefaultHttpRequestInterceptor
    {
        private readonly IUserRepository _repository;

        public HttpRequestInterceptor([Service] IUserRepository repository)
        {
            _repository = repository;
        }
        public override ValueTask OnCreateAsync(HttpContext context,
            IRequestExecutor requestExecutor, IQueryRequestBuilder requestBuilder,
            CancellationToken cancellationToken)
        {
            if (context.User is not null)
            {
                string? id = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (id is not null)
                {
                    var user = _repository.GetByIdAsync(new Guid(id), cancellationToken);

                    requestBuilder.SetProperty("currentUser", user.Result);
                }
            }

            return base.OnCreateAsync(context, requestExecutor, requestBuilder,
                cancellationToken);
        }
    }
}

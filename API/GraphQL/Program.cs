using BLL.Settings;
using DAL.Data;
using GraphQL.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json")
							.Build();

builder.Services
	.AddCors(o =>
				o.AddDefaultPolicy(b =>
				b.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowAnyOrigin())
			);

// Add services to the container.
builder.Services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlite("Data Source=support.db"));

builder.Services.AddRepositoriesExtension(configuration);
var tokenSettings = configuration.GetSection(nameof(TokenSettings)).Get<TokenSettings>();
builder.Services.AddJwtTokenExtension(tokenSettings);
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

// GraphQL Logic
builder.Services
	.AddGraphQLServer()
	// .AddAuthorization()
	.AddHttpRequestInterceptor<HttpRequestInterceptor>()
	.AddQueriesExtension()
	.AddMutationsExtension()
	.AddTypesExtension()
	.AddDataLoadersExtension()
	.AddSubscriptionsExtension()
	.AddInMemorySubscriptions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseWebSockets();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
	endpoints.MapGraphQL();
});

app.Run();


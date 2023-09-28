using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AppDbContext>(options =>
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
options.UseSqlServer(
                    builder.Configuration.GetConnectionString("AppDatabase")));

builder.Services
            .AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddSubscriptionType<Subscription>()
            .AddType<PlatformType>()
            .AddType<CommandType>()
            .AddFiltering()
            .AddSorting()
            .AddInMemorySubscriptions();
                    
//.AddProjections() ///get data commmand if query, same include in EF 

var app = builder.Build();

app.UseWebSockets();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new GraphQLVoyagerOptions()
{
    GraphQLEndPoint = "/graphql",
    Path = "/graphql-voyager"
});
app.Run();
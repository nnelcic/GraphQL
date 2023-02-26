namespace GraphQLProject.Schema;
using GraphQL.Types;
using GraphQLProject.Mutation;
using GraphQLProject.Query;

public class RootSchema : Schema
{
    public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetRequiredService<RootQuery>();
        Mutation = serviceProvider.GetRequiredService<RootMutation>();
    }
}

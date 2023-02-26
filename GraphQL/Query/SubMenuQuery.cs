using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Type;

namespace GraphQLProject.Query;

public class SubMenuQuery : ObjectGraphType
{
    public SubMenuQuery(ISubMenu subMenuService)
    {
        Field<ListGraphType<SubMenuType>>("submenus", 
            resolve: context => { return subMenuService.GetSubMenus(); });

        Field<ListGraphType<SubMenuType>>("submenuById",
            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            resolve: context => subMenuService.GetSubMenu(context.GetArgument<int>("id")));
    }
}

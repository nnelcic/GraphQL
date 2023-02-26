using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType(ISubMenu subMenuService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.ImageUrl);
            Field<ListGraphType<SubMenuType>>("submenus",
                resolve: context => { return subMenuService.GetSubMenu(context.Source.Id); });
        }
    }
}

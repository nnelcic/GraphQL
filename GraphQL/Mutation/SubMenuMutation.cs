﻿using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;

namespace GraphQLProject.Mutation;

public class SubMenuMutation : ObjectGraphType
{
    public SubMenuMutation(ISubMenu subMenuService)
    {
        Field<SubMenuType>("createSubMenu", arguments: new QueryArguments(new QueryArgument<SubMenuInputType> { Name = "subMenu" }),
            resolve: context => subMenuService.AddSubMenu(context.GetArgument<SubMenu>("subMenu")));
    }
}
﻿using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class MenuService : IMenu
{
    private readonly GraphQLDbContext _dbContext;

    public MenuService(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Menu AddMenu(Menu menu)
    {
        _dbContext.Menus.Add(menu);
        _dbContext.SaveChanges();
        return menu;
    }

    public List<Menu> GetMenus()
    {
        return _dbContext.Menus.ToList();
    }
}

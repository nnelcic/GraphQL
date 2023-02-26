using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class SubMenuService : ISubMenu
{
    private readonly GraphQLDbContext _dbContext;

    public SubMenuService(GraphQLDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public SubMenu AddSubMenu(SubMenu subMenu)
    {
        _dbContext.SubMenus.Add(subMenu);
        _dbContext.SaveChanges();
        return subMenu;
    }

    public List<SubMenu> GetSubMenu(int menuId)
    {
        return _dbContext.SubMenus.Where(x => x.Id == menuId).ToList();
    }

    public List<SubMenu> GetSubMenus()
    {
        return _dbContext.SubMenus.ToList();
    }
}

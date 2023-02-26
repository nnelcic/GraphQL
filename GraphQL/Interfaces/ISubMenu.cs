using GraphQLProject.Models;

namespace GraphQLProject.Interfaces;

public interface ISubMenu
{
    List<SubMenu> GetSubMenus();    
    List<SubMenu> GetSubMenu(int menuId);    
    SubMenu AddSubMenu(SubMenu subMenu);    
}

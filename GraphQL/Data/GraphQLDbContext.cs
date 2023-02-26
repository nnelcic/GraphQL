using GraphQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLProject.Data;

public class GraphQLDbContext : DbContext
{
    public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options) :base(options)
    { }

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Menu> Menus { get; set; } 
    public DbSet<SubMenu> SubMenus { get; set; }
}

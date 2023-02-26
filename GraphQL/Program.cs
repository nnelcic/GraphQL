using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Mutation;
using GraphQLProject.Query;
using GraphQLProject.Schema;
using GraphQLProject.Services;
using GraphQLProject.Type;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMenu, MenuService>();
builder.Services.AddScoped<ISubMenu, SubMenuService>();
builder.Services.AddScoped<IReservation, ReservationService>();
builder.Services.AddScoped<MenuType>();
builder.Services.AddScoped<SubMenuType>();
builder.Services.AddScoped<ReservationType>();
builder.Services.AddScoped<MenuQuery>();
builder.Services.AddScoped<SubMenuQuery>();
builder.Services.AddScoped<ReservationQuery>();
builder.Services.AddScoped<RootQuery>();
builder.Services.AddScoped<MenuMutation>();
builder.Services.AddScoped<SubMenuMutation>();
builder.Services.AddScoped<ReservationMutation>();
builder.Services.AddScoped<RootMutation>();
builder.Services.AddScoped<MenuInputType>();
builder.Services.AddScoped<SubMenuInputType>();
builder.Services.AddScoped<ReservationInputType>();
builder.Services.AddScoped<ISchema, RootSchema>();
builder.Services.AddDbContext<GraphQLDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("CoffeeShopDb"));
});

builder.Services.AddGraphQL(options =>
{
    options.EnableMetrics = false;
}).AddSystemTextJson();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GraphQLDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

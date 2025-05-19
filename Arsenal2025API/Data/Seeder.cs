using Microsoft.EntityFrameworkCore;

namespace Arsenal2025API.Data;

public static class Seeder
{
    public static void Initialize(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();

        if (!context.Players.Any())
        {
            context.AddRange(SeedData.PlayerList());
        }
    }
}
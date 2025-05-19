using Arsenal2025API.Helpers;
using Arsenal2025API.Models;
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
            context.SaveChanges();
        }
        
        if (!context.Coaches.Any())
        {
            context.AddRange(SeedData.CoachList());
            context.SaveChanges();
        }

        if (!context.Users.Any())
        {
            List<User> users =  
            [
             new User
            {
                Id = AuthHelpers.SupervisorId,
                Username = "admin",
                Email = "admin@kampaladevops.com",
                PasswordHash = AuthHelpers.HashPassword("Admin@123"),
                IsActive = true,
                CreatedAt = DateTime.UtcNow.AddYears(-3),
                UpdatedAt = DateTime.UtcNow.AddYears(-1)
            },
             new User
            {
                Id = AuthHelpers.FanId,
                Username = "number1",
                Email = "number1@kampaladevops.com",
                PasswordHash = AuthHelpers.HashPassword("number1234"),
                IsActive = true,
                CreatedAt = DateTime.UtcNow.AddYears(-2),
                UpdatedAt = DateTime.UtcNow.AddYears(-1)
            },
            ];

            context.AddRange();
            context.SaveChanges();
        }
    }
}
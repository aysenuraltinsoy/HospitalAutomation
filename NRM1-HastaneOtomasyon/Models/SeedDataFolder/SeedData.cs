using Hastane.DataAccess.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Hastane.Entities.Concrete;
using Hastane.Core.Enums;

namespace NRM1_HastaneOtomasyon.Models.SeedDataFolder
{
    public static class SeedData
    {

        //program.cs deki app ile aynı şey
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<HastaneDbContext>();
            dbContext.Database.Migrate();
            if (dbContext.Admins.Count()==0)
            {
                dbContext.Admins.Add(new Admin()
                {
                    Id = Guid.NewGuid(),
                    Name = "Şahin",
                    Surname = "Uzun",
                    EmailAddress = "sahinuzun@gmail.com",
                    Status = Status.Active,
                    Password = "1234",
                    CreatedTime = DateTime.Now,

                });
            }
            dbContext.SaveChanges();
        }
    }
}

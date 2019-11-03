using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ZipCoCodeChallenge.Models
{
    public static class PrepPopulateDb
    {
        public static void PrePopulate(IApplicationBuilder app)
        {
            using (var service = app.ApplicationServices.CreateScope())
            {
                SeedData(service.ServiceProvider.GetService<ZipPayContext>());
            }
        }

        private static void SeedData(ZipPayContext context)
        {
           // context.Database.Migrate();
        }
    }
}

using DataAccessLayer.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccessLayer
{
    public static class ServiceRegistration
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            //collection.AddMediatR(typeof(ServiceRegistration));

            services.AddDbContext<FAYonetimiDBContext>(options => options.UseSqlServer("Server=DESKTOP-K2S3CST;Database=FaturaYonetimi;integrated security=true;"));
            //services.AddDbContext<FAYonetimiDBContext>(options => options.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=FaturaYonetimi;Pooling=true;"));
        }
    }
}

﻿using BusinessLayer.Repositories.Contact;
using BusinessLayer.Repositories.FA;
using BusinessLayer.Repositories.Housing;
using BusinessLayer.Repositories.User;
using BusinessLayer.Repositories.Vehicle;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repositories.Contact;
using DataAccessLayer.Repositories.FA;
using DataAccessLayer.Repositories.Housing;
using DataAccessLayer.Repositories.User;
using DataAccessLayer.Repositories.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ServiceRegistration));

            //Configuration.ConfigurationString
            services.AddDbContext<FAYonetimiDBContext>(options => options.UseSqlServer(Configuration.ConfigurationString));
            //services.AddDbContext<FAYonetimiDBContext>(options => options.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=FaturaYonetimi;Pooling=true;"));

            services.AddScoped<IContactReadRepository, ContactReadRepository>();
            services.AddScoped<IContactWriteRepository, ContactWriteRepository>();

            services.AddScoped<IFAReadRepository, FAReadRepository>();
            services.AddScoped<IFAWriteRepository, FAWriteRepository>();

            services.AddScoped<IHousingReadRepository, HousingReadRepository>();
            services.AddScoped<IHousingWriteRepository, HousingWriteRepository>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IVehicleReadRepository, VehicleReadRepository>();
            services.AddScoped<IVehicleWriteRepository, VehicleWriteRepository>();
        }
    }
}

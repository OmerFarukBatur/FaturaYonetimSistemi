using EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contexts
{
    public class FAYonetimiDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=FaturaYonetimi;Pooling=true;");
        }

        public FAYonetimiDBContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FA> FAs { get; set; }
        public DbSet<Housing> Housings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


    }
}

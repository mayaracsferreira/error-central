using ErrorCentral.AppDomain.Models;
using ErrorCentral.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Infrastructure.Context
{
    public class EventContext : DbContext
    {
        private DbContextOptions<EventContext> options;

        public EventContext() { }

        public EventContext(DbContextOptions<EventContext> options)
        {
            this.options = options;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Configurações do banco de dados
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=error;Integrated Security=True");
               // var builder = new ConfigurationBuilder()
               //.AddJsonFile("appsettings.json");

                //var config = builder.Build();
                
                //optionsBuilder.UseSqlServer(config["ConnectionStrings:DefaultConnection"]);
                //optionsBuilder.UseSqlServer(DbConfiguration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}

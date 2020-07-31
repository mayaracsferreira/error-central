using ErrorCentral.AppDomain.Models;
using ErrorCentral.Infra.Data.Seed;
using Microsoft.EntityFrameworkCore;
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
                optionsBuilder.UseSqlServer("Data Source=tcp:errorcentralproject.database.windows.net,1433;Initial Catalog=ErrorCentral;Persist Security Info=False;User ID=admerrorcentral;Password=Squad1errorcentral;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}

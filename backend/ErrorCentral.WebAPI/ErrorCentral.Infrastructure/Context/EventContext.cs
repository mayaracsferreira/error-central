using ErrorCentral.AppDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Infrastructure.Context
{
    public class EventContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EventLog> EventLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //Essa parte, por favor, evitem rodar kkk
                // A não ser que troque para o data Source do banco de vocês
                //PRESTE ATENÇÃO, SUSCETIVEL A ACONTECER MERDA
                //vou colocar o meu, desculpa se eu esquecer e subir com ele 
                optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=error;Integrated Security=True");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

        }
    }
}

using ErrorCentral.Infrastructure.Context;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCentral.Test
{
    public abstract class TestWithSqLite : IDisposable
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected EventContext DbContext;

        protected TestWithSqLite()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<EventContext>().UseSqlite(_connection).Options;
            DbContext = new EventContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public void Clear()
        {
            DbContext.Users.RemoveRange(DbContext.Users);
            DbContext.SaveChanges();
        }
    }
}



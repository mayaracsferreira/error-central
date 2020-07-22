using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using ErrorCentral.AppDomain.Extensions;
using ErrorCentral.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCentral.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EventContext context;
        public UserRepository(EventContext context)
        {
            this.context = context;
        }

        public List<User> Get()
        {
            return context.Users.ToList();
        }
        public User GetByEmail(string email)
        {
            return context.Users.Where(x => x.Email == email).FirstOrDefault();
        }
        public User Save(User user)
        {
            // Encrypts user password
            user.Password = Md5Hash.Generate(user.Password);
            var state = user.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(user).State = state;
            context.Add(user);
            context.SaveChanges();
            return user;
        }
        public User Update(User user)
        {
            var _user = context.Users.Where(x => x.Email == user.Email).FirstOrDefault();

            if (_user != null)
            {
                // When user forgets the password, he can change it by sending the email
                _user.Password = user.Password;

                context.Entry(_user).State = EntityState.Modified;
                context.SaveChanges();
            }

            return user;
        }
    }
}

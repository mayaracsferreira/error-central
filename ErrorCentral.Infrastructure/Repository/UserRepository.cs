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
using ErrorCentral.Infra.Data.Exceptions;

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
            List<User> users = context.Users.ToList();
            if (users == null)
            {
                throw new UserNotFoundException("Ainda não há usuários cadastrados");
            }
            return users;
        }
        public User GetByEmail(string email)
        {
            User user = context.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null)
            {
                throw new UserNotFoundException("Não foi possível encontrar usuário com o e-mail informado");
            }
            return user;
        }

        public bool Save(User user)
        {
            User u = context.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            if (u != null)
            {
                throw new EmailAlreadyExistsException("Email já está em uso");
            }
            // Encrypts user password
            user.Password = Md5Hash.Generate(user.Password);
            var state = user.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(user).State = state;
            context.Add(user);
            context.SaveChanges();
            return true;
        }

        public User Update(LoginUser user)
        {
            var _user = context.Users.Where(x => x.Email == user.LoginOrEmail).FirstOrDefault();

            if (_user != null)
            {
                // When user forgets the password, he can change it by sending the email
                user.Password = Md5Hash.Generate(user.Password);
                _user.Password = user.Password;

                context.Entry(_user).State = EntityState.Modified;
                context.SaveChanges();
            }
            // Usuário não encontrado
            else
            {
                throw new UserNotFoundException("Usuário não encontrado");
            }

            return _user;
        }
    }
}

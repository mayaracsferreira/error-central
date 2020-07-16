using ErrorCentral.AppDomain.Interfaces;
using ErrorCentral.AppDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorCentral.AppDomain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> Get()
        {
            try
            {
                return _userRepository.Get().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public User GetByEmail(string email)
        {
            try
            {
                return _userRepository.GetByEmail(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public User Save(User user)
        {
            try
            {
                return _userRepository.Save(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public User Update(User user)
        {
            try
            {
                return _userRepository.Update(user);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

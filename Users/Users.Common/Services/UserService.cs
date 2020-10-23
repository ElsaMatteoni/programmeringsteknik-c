using System;
using System.Collections.Generic;
using System.Text;
using Users.Common.Models;

namespace Users.Common.Services
{
    public class UserService : IUserService
    {
        public List<User> UsersStored{ get; set; } = new List<User>();
        
        public IUser Get(string email)
        {
            foreach (var user in UsersStored)
            {
                if (user.Email == email)
                    return user;
            }
            return null;
        }

        public IUser Get(Guid userId)
        {
            foreach (var user in UsersStored)
            {
                if (user.Id == userId)
                    return user;
            }
            return null;
        }

        public IServiceResponse Login(string email, string password)
        {
            foreach (var user in UsersStored)
            {
                if (user.Email == email && user.Password == password)
                {
                    return new ServiceResponse()
                    {
                        Success = true
                    };
                }
            }
            return new ServiceResponse()
            {
                Success = false
            };
        }

        public IServiceResponse Register(IUser user)
        {
            UsersStored.Add(user as User);
            return new ServiceResponse()
            {
                Success = true
            };
        }

        public IServiceResponse SetPassword(Guid userId, string password)
        {

            foreach (var user in UsersStored)
                if (user.Id == userId)
                {
                    user.Password = password;
                    return new ServiceResponse()
                    {
                        Success = true
                    };
                }
            return new ServiceResponse()
            {
                Success = false
            };
        }
    }
}

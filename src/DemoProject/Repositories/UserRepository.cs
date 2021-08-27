using DemoProject.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DemoProject.Repositories
{
    public interface IUserRepository
    {
        UserEntity GetUserById(string id);
    }

    public class UserRepository : IUserRepository
    {
        private List<UserEntity> _users;

        public UserRepository()
        {
            _users = new List<UserEntity>
            {
                new UserEntity
                {
                    Id = "001",
                    FirstName = "Peppa",
                    LastName = "Pig",
                    Email = "peppa.pig@users.com"
                },
                new UserEntity
                {
                    Id = "002",
                    FirstName = "Danny",
                    LastName = "Dog",
                    Email = "Danny.Dog@users.com"
                },
                new UserEntity
                {
                    Id = "003",
                    FirstName = "Sally",
                    LastName = "Sheep",
                    Email = "sally.sheep@users.com"
                }
            };
        }

        public UserEntity GetUserById(string id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}

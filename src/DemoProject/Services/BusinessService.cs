using DemoProject.Exceptions;
using DemoProject.Models;
using DemoProject.Repositories;

namespace DemoProject.Services
{
    public interface IBusinessService
    {
        UserModel GetUserById(string id);
    }

    public class BusinessService : IBusinessService
    {
        private IUserRepository _userRepository;

        public BusinessService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserById(string id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                throw new NotFoundException("User not found");

            return new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}

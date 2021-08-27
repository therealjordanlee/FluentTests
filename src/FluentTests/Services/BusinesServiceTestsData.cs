using DemoProject.Entities;
using DemoProject.Repositories;
using DemoProject.Services;
using Moq;
using System;

namespace FluentTests.Services
{
    public class BusinesServiceTestsData
    {
        public Mock<IUserRepository> MockUserRepository { get; }

        public BusinesServiceTestsData()
        {
            MockUserRepository = new Mock<IUserRepository>();
        }

        public BusinesServiceTestsData SetupMockUserRepositoryGetUserByIdReturns(UserEntity userEntity)
        {
            MockUserRepository.Setup(x => x.GetUserById(It.IsAny<string>()))
                .Returns(userEntity);

            return this;
        }

        public BusinesServiceTestsData SetupMockUserRepositoryGetUserByIdThrows(Exception exception)
        {
            MockUserRepository.Setup(x => x.GetUserById(It.IsAny<string>()))
                .Throws(exception);
            return this;
        }

        public BusinessService Build()
        {
            return new BusinessService(MockUserRepository.Object);
        }
    }
}

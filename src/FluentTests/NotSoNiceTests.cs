using DemoProject.Entities;
using DemoProject.Exceptions;
using DemoProject.Models;
using DemoProject.Repositories;
using DemoProject.Services;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace FluentTests
{
    public class NotSoNiceTests
    {
        private Mock<IUserRepository> MockUserRepository;
        private IBusinessService sut;

        public NotSoNiceTests()
        {
            MockUserRepository = new Mock<IUserRepository>();
            sut = new BusinessService(MockUserRepository.Object);
        }

        [Fact]
        public void When_User_Is_Found_In_Repository_Expect_UserModel_Returned()
        {
            // arrange
            var userEntity = new UserEntity
            {
                Id = "1",
                FirstName = "First",
                LastName = "Last",
                Email = "email"
            };
            MockUserRepository.Setup(x => x.GetUserById(It.IsAny<string>()))
               .Returns(userEntity);

            var expected = new UserModel
            {
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Email = userEntity.Email
            };

            // act
            var result = sut.GetUserById(default);

            // assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void When_User_Not_Found_Expect_NotFoundException_Is_Thrown()
        {
            // arrange
            MockUserRepository.Setup(x => x.GetUserById(It.IsAny<string>()))
                .Returns((UserEntity)null);

            // act
            Action act = () => sut.GetUserById(default);

            // assert
            act.Should().ThrowExactly<NotFoundException>()
                .WithMessage("User not found");
        }
    }
}

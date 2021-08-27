using DemoProject.Entities;
using DemoProject.Exceptions;
using DemoProject.Models;
using FluentAssertions;
using FluentTests.Helpers;
using System;
using Xunit;

namespace FluentTests.Services
{
    public class BusinessServiceTests : BusinesServiceTestsData
    {
        [Fact]
        public void When_User_Not_Found_In_Repository_Expect_NotFoundException_Is_Thrown()
        {
            // arrange
            var sut = SetupMockUserRepositoryGetUserByIdReturns(null).Build();

            // act
            Action act = () => sut.GetUserById(default);

            // assert
            act.Should().ThrowExactly<NotFoundException>()
                .WithMessage("User not found");
        }

        [Fact]
        public void When_User_Is_Found_In_Repository_Expect_UserModel_Returned()
        {
            var userEntity = new DataBuilder<UserEntity>()
                .Set(x => x.Email = "test@test.local")
                .Build();

            var expected = new DataBuilder<UserModel>()
                .Set(x => {
                    x.FirstName = userEntity.FirstName;
                    x.LastName = userEntity.LastName;
                    x.Email = userEntity.Email;
                })
                .Build();

            var sut = SetupMockUserRepositoryGetUserByIdReturns(userEntity)
                      .Build();

            // act, assert
            var result = sut.GetUserById(default);
            result.Should().BeEquivalentTo(expected);
        }
    }
}

using CSG.Kaveri.UserLoginAPI.Controllers;
using CSG.Kaveri.UserLoginAPI.DAL;
using CSG.Kaveri.UserLoginAPI.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CSG.Kaveri.UserLoginAPITest
{
    public class UserLoginControllerTest
    {

       

        public UserLoginControllerTest()
        {
        }
        //...

        [Fact]
        public void GetUserLogin_Success()
        {
            //Arrange
            var userLoginRequest = new UserLoginRequest()
            {
                loginname = "rohan",
                password = "rohan@123"
            };

            var mock = new Mock<IGetDataReadersAsync>();
            mock.Setup(repo => repo.GetUserLoginDataAsync<UserLoginResponse, dynamic>(userLoginRequest)).Returns(new UserLoginResponse() { loginname = userLoginRequest.loginname });
            var controller = new UserLoginController(mock.Object);

            // Act
            var result = controller.GetUserLoginData(userLoginRequest);

            // Assert
            Assert.Equal(1000, result.responseCode);
        }
    }
}

using ArquiteturaHexagonal.Controllers;
using Domain.Ports;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Users.Api.Tests.Fakers;

namespace Users.Api.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly UsersController _usersController;
        private readonly IUserService _userService;

        public UsersControllerTests()
        {
            _userService = Substitute.For<IUserService>();
            _usersController = new UsersController(_userService);
        }

        [Fact]
        public async Task GetAllUsersTheyExist_GetAllUsers_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 200;

            var user = new UserFaker().Generate();
            _userService.GetAllUsersAsync().Returns([user]);

            // Action
            var result = await _usersController.GetAllUsers();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(statusCodeExpected, okResult?.StatusCode);
        }

        [Fact]
        public async Task GetAllUsersTheyNotExistent_GetAllUsers_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 404;

            _userService.GetAllUsersAsync().ReturnsNull();

            // Action
            var result = await _usersController.GetAllUsers();
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(statusCodeExpected, notFoundResult?.StatusCode);
        }

        [Fact]
        public async Task GetUserExistent_GetUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 200;

            var user = new UserFaker().Generate();
            _userService.GetUserAsync(Arg.Is(user.Id)).Returns(user);

            // Action
            var result = await _usersController.GetUser(user.Id);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(statusCodeExpected, okResult?.StatusCode);
        }

        [Fact]
        public async Task GetUserNotExistent_GetUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 404;

            var guidUserNotExistent = Guid.NewGuid();
            _userService.GetUserAsync(Arg.Is(guidUserNotExistent)).ReturnsNull();

            // Action
            var result = await _usersController.GetUser(guidUserNotExistent);
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(statusCodeExpected, notFoundResult?.StatusCode);
        }

        [Fact]
        public async Task AddUserValid_RegisterUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 200;

            var user = new UserFaker().Generate();
            _userService.AddNewUserAsync(Arg.Is(user)).Returns(user);

            // Action
            var result = await _usersController.RegisterUser(user);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(statusCodeExpected, okResult?.StatusCode);
        }

        [Fact]
        public async Task UpdateUserExistent_UpdateUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 200;

            var user = new UserFaker().Generate();
            _userService.UpdateUserAsync(Arg.Is(user)).Returns(user);

            // Action
            var result = await _usersController.UpdateUser(user.Id, user);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(statusCodeExpected, okResult?.StatusCode);
        }

        [Fact]
        public async Task UpdateUserWithIdNotCorrespondent_UpdateUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 400;
            var user = new UserFaker().Generate();
            var guidUserNotExistent = Guid.NewGuid();

            // Action
            var result = await _usersController.UpdateUser(guidUserNotExistent, user);
            var badRequestResult = result as BadRequestResult;

            // Assert
            Assert.NotNull(badRequestResult);
            Assert.Equal(statusCodeExpected, badRequestResult?.StatusCode);
        }

        [Fact]
        public async Task DeleteUserExistent_DeleteUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 200;

            var user = new UserFaker().Generate();
            _userService.DeleteUserAsync(Arg.Is(user.Id)).Returns(user);

            // Action
            var result = await _usersController.DeleteUser(user.Id);
            var okResult = result as OkObjectResult;

            // Assert
            Assert.NotNull(okResult);
            Assert.Equal(statusCodeExpected, okResult?.StatusCode);
        }

        [Fact]
        public async Task DeleteUserInexistent_DeleteUser_ReturnsStatusCodeOk()
        {
            // Arrange
            var statusCodeExpected = 404;

            var guidUserNotExistent = Guid.NewGuid();
            _userService.DeleteUserAsync(Arg.Is(guidUserNotExistent)).ReturnsNull();

            // Action
            var result = await _usersController.DeleteUser(guidUserNotExistent);
            var notFoundResult = result as NotFoundResult;

            // Assert
            Assert.NotNull(notFoundResult);
            Assert.Equal(statusCodeExpected, notFoundResult?.StatusCode);
        }
    }
}
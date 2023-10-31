using FilRougeApi.Repositories;
using FilRougeCore.Models;
using FilRougeApi.Builders;
using Moq;

namespace TestAPIRest
{
    [TestClass]
    public class AuthenticationTest
    {
        private IRepository<User> _repository;
        private UserBuilder userBuilder;

        //[TestInitialize]
        //public void SetUp()
        //{
        //    _repository = Mock.Of<IRepository<User>>();
        //    _authenticationService = new ApiRest.Services.AuthenticationService(_repository);
        //    userBuilder = new UserBuilder();
        //}

        //[TestMethod]
        //public void TestRegisterShouldReturnUserIdWithCorrectInformations()
        //{
        //    Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User,bool>>())).Returns(()=>null);
        //    Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User, bool>>())).Returns(() => null);
        //    int? userId = _authenticationService.Register("username", "password", "username@email.fr");
        //    Assert.IsNotNull(userId);
        //}

        //[TestMethod]
        //public void TestRegisterShouldRaiseExceptionWhenEmailsExists()
        //{
        //    Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User, bool>>())).Returns(userBuilder.Email("username@email.fr").Build());
        //    Assert.ThrowsException<FormatException>(() => _authenticationService.Register("username", "password", "username@email.fr"));  
        //}

        //[TestMethod]
        //public void TestRegisterShouldRaiseExceptionWhenUsernameExists()
        //{
        //    Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User, bool>>())).Returns(new UserBuilder().Username("username").Build());
        //    Assert.ThrowsException<FormatException>(() => _authenticationService.Register("username", "password", "username@email.fr"));
        //}

        //[TestMethod]
        //public void TestLoginShouldRaiseFormatExceptionWithWrongUsername()
        //{
        //    Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User, bool>>())).Returns(()=>null);
        //    Assert.ThrowsException<NotFoundException>(() => _authenticationService.Login("username", "password"));
        //}

        //[TestMethod]
        //public void TestLoginShouldReturnTokenWithCorrectInformationUsername()
        //{
        //    Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User, bool>>())).Returns(userBuilder.Username("username").Password("password").Build());
        //    string token = _authenticationService.Login("username", "password");
        //    Assert.IsNotNull(token);
        //}

    }
}
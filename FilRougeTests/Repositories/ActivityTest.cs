using FilRougeApi.Builders;
using FilRougeApi.Repositories;
using FilRougeCore.Models;
using Moq;
using System.Diagnostics;

namespace FilRougeTests
{
    [TestClass]
    public class ActivityTest
    {
        private IRepository<FilRougeCore.Models.Activity>? _repository;
        private ActivityBuilder? activityBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _repository = Mock.Of<IRepository<FilRougeCore.Models.Activity>>();
            activityBuilder = new ActivityBuilder();
        }

        [TestMethod]
        public void TestAddActivityShouldReturnActivityIdWithCorrectInformations()
        {
            //Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User,bool>>())).Returns(()=>null);
            //Mock.Get(_repository).Setup(m => m.Find(It.IsAny<Func<User, bool>>())).Returns(() => null);
            //int? userId = _authenticationService.Register("username", "password", "username@email.fr");
            //Assert.IsNotNull(userId);
        }


    }
}
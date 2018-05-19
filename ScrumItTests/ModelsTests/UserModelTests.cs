using NUnit.Framework;
using ScrumIt;
using ScrumIt.Models;
using Assert = NUnit.Framework.Assert;

namespace ScrumItTests.ModelsTests
{
    [TestFixture]
    public class UserModelTests
    {
        private AppStateProvider _state;

        [OneTimeSetUp]
        public void SetUp()
        {
            _state = AppStateProvider.Instance;
        }

        [Test]
        public void LogOutShouldUnsetUser()
        {
            _state.CurrentUser = new UserModel
            {
                UserId = 5,
                Role = UserRoles.Developer
            };

            var loggedOutSuccessful = UserModel.Logout();

            Assert.That(loggedOutSuccessful, Is.EqualTo(true), "Logging out was unsuccessful.");
            Assert.That(_state.CurrentUser.UserId, Is.EqualTo(0), "Previous user Id is present after log out");
            Assert.That(_state.CurrentUser.Role, Is.EqualTo(UserRoles.Guest), "Previous user role is present after log out");
        }
    }
}

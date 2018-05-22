using NUnit.Framework;
using ScrumIt;
using ScrumIt.DataAccess;
using ScrumIt.Models;

namespace ScrumItTests.UnitTests.DataAccessTests
{
    public class UserAccessTests
    {
        private UserModel _user;

        [OneTimeSetUp]
        public void SetUp()
        {
            _user = new UserModel();
        }

        [Test]
        public void LoginAsWithEmptyPasswordShouldFail()
        {
            var user = UserAccess.LoginAs("admin", "");

            Assertion.Equals(user, _user);
        }

        [Test]
        public void LoginAsWithEmptyLoginShouldFail()
        {
            var user = UserAccess.LoginAs("", "admin");

            Assertion.Equals(user, _user);
        }

        [Test]
        public void LoginAsWithEmptyCredentialsShouldFail()
        {
            var user = UserAccess.LoginAs("", "");

            Assertion.Equals(user, _user);
        }
    }
}

using Npgsql;
using NUnit.Framework;
using ScrumIt.DataAccess;

namespace ScrumItTests.IntegrationTests.DataAccessTests
{
    [TestFixture, IntegrationTest]
    public class ConnectionIntegrationTests
    {
        [Test]
        public void Connect()
        {
            bool isConnectionAvailable = false;
            using (new Connection())
            {
                var cmd = new NpgsqlCommand("select * from projects")
                {
                    Connection = Connection.Conn
                };
            }

            isConnectionAvailable = true;
            Assert.That(isConnectionAvailable, Is.True, "Connection to DB is not available");
        }

        [Test]
        public void ConnExcl()
        {
            bool isConnectionAvailable = false;
            using (var c = new Connection(true))
            {
                var cmd = new NpgsqlCommand("select * from projects")
                {
                    Connection = c.ConnExcl
                };
            }

            isConnectionAvailable = true;
            Assert.That(isConnectionAvailable, Is.True, "Exclusive connection to DB is not available");
        }
    }
}

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
                var cmd = new NpgsqlCommand("select * from users")
                {
                    Connection = Connection.Conn
                };
                using (var reader = cmd.ExecuteReader())
                {
                    var user = 0;
                    while (reader.Read())
                    {
                        user++;
                        if (user <= 0) continue;
                        isConnectionAvailable = true;
                        break;
                    }
                }
            }
            Assert.That(isConnectionAvailable, Is.True, "Connection to DB is not available");
        }
    }
}

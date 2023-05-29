using Nexus.Data;
namespace UnitTests
{
    public class NexusContextTests
    {
        [Fact]
        public void DatabaseConnectionTest()
        {
            using (NexusContext db = new())
            {
                Assert.True(db.Database.CanConnect());
            }
        }

    }
}


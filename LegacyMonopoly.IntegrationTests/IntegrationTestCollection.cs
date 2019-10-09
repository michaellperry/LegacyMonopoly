using Xunit;

namespace LegacyMonopoly.IntegrationTests
{
    [CollectionDefinition("Integration test collection")]
    public class IntegrationTestCollection : ICollectionFixture<TestSetup>
    {
    }
}
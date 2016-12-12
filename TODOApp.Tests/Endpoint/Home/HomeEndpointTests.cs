using FubuTestingSupport;
using NUnit.Framework;
using TODOApp.Endpoints.Home;

namespace TODOApp.Tests.Endpoint.Home
{
    [TestFixture]
    public class HomeEndpointTests : InteractionContext<HomeEndpoint>
    {
        [Test]
        public void GetIndexReturnsHomeViewModel()
        {
            var result = ClassUnderTest.get_index(new HomeViewModel());
            result.ShouldNotBeNull();
            result.ShouldBeOfType<HomeViewModel>();
        }
    }
}
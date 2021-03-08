using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WpfTests.Infrastructure.Services.InMemory;


namespace WpfTests.Tests.Infrastructure.Services.InMemory
{
    [TestClass]
    class ServersRepositoryTests
    {

        [TestMethod]
        public void GetAll_Servers_Test()
        {
            var repository = new ServersRepository();

            var all = repository.GetAll();

            Assert.IsTrue(all.Any());
        }

    }

    
}

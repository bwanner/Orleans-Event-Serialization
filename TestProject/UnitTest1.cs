using System;
using System.Threading.Tasks;
using GrainProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orleans;
using Orleans.TestingHost;

namespace TestProject
{
    [TestClass]
    public class UnitTest1 : TestingSiloHost
    {
        private async Task DefaultTestMethod()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.SubscribeEventAndEmitMyObject();
            Assert.IsTrue(await g2.EventHasNoSubscribers());
        }

        [TestMethod]
        public async Task TestMethod1()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod3()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod4()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod5()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod6()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod7()
        {
            await DefaultTestMethod();
        }

        [TestMethod]
        public async Task TestMethod8()
        {
            await DefaultTestMethod();
        }
    }
}

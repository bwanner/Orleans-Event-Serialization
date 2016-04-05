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
        [TestMethod]
        public async Task TestMethod1()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.SubscribeEventAndEmitMyObject();
            Assert.IsTrue(await g2.EventHasNoSubscribers());

        }

        [TestMethod]
        public async Task TestMethod2()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.SubscribeEventAndEmitMyObject();
            Assert.IsTrue(await g2.EventHasNoSubscribers());

        }

        [TestMethod]
        public async Task TestMethod3()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.SubscribeEventAndEmitMyObject();
            Assert.IsTrue(await g2.EventHasNoSubscribers());

        }

        [TestMethod]
        public async Task TestMethod4()
        {
            var g1 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());
            var g2 = GrainClient.GrainFactory.GetGrain<IMyGrain>(Guid.NewGuid());

            Assert.IsTrue(await g1.EventHasNoSubscribers());

            await g2.SubscribeTo(g1.GetPrimaryKey());

            await g1.SubscribeEventAndEmitMyObject();
            Assert.IsTrue(await g2.EventHasNoSubscribers());

        }
    }
}
